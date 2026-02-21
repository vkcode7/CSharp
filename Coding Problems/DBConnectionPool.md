Here's a clean, thread-safe implementation of a **DB Connection Pool** in C# that maintains up to 20 connections and supports borrowing & returning connections.

```csharp
using System;
using System.Collections.Concurrent;
using System.Threading;

public class DBConnectionPool : IDisposable
{
    private const int MAX_POOL_SIZE = 20;
    
    // Queue of available (idle) connections
    private readonly ConcurrentQueue<DBConnection> _availableConnections 
        = new ConcurrentQueue<DBConnection>();
    
    // Tracks all connections ever created (for cleanup)
    private readonly List<DBConnection> _allConnections = new List<DBConnection>();
    
    private readonly object _creationLock = new object();
    private readonly string _connectionString;
    private bool _disposed;

    public DBConnectionPool(string connectionString, int initialSize = 5)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string cannot be empty", nameof(connectionString));

        _connectionString = connectionString;

        // Pre-create initial connections (optional warm-up)
        for (int i = 0; i < Math.Min(initialSize, MAX_POOL_SIZE); i++)
        {
            var conn = CreateNewConnection();
            _availableConnections.Enqueue(conn);
        }
    }

    /// <summary>
    /// Gets a connection from the pool. Blocks if none available and pool is full.
    /// </summary>
    public DBConnection GetConnection()
    {
        ThrowIfDisposed();

        // Fast path: try to get an existing idle connection
        if (_availableConnections.TryDequeue(out var connection))
        {
            if (connection.IsValid())
            {
                return connection;
            }
            // If connection is broken → discard and continue
            connection.Dispose();
        }

        // No idle connection available → try to create new one (with limit)
        lock (_creationLock)
        {
            if (_allConnections.Count < MAX_POOL_SIZE)
            {
                var newConn = CreateNewConnection();
                _allConnections.Add(newConn);
                return newConn;
            }
        }

        // Pool is at max size → wait for someone to return a connection
        // (in real systems you might add timeout here)
        while (true)
        {
            if (_availableConnections.TryDequeue(out connection))
            {
                if (connection.IsValid())
                {
                    return connection;
                }
                connection.Dispose();
            }

            // Brief sleep to avoid tight loop (you can use a BlockingCollection instead)
            Thread.Sleep(50);
        }
    }

    /// <summary>
    /// Returns a connection to the pool
    /// </summary>
    public void ReturnConnection(DBConnection connection)
    {
        if (connection == null) return;
        if (_disposed) 
        {
            connection.Dispose();
            return;
        }

        // In real-world code you might:
        // - reset connection state
        // - check if it's still usable (test query / state)
        // - close transactions if any are open

        if (connection.IsValid())
        {
            _availableConnections.Enqueue(connection);
        }
        else
        {
            connection.Dispose();
            // Optionally try to replace broken connection
            TryReplaceBrokenConnection();
        }
    }

    private DBConnection CreateNewConnection()
    {
        var conn = new DBConnection(_connectionString);
        // You can open it here or let the client open it
        // conn.Open();   ← common pattern in some pools
        return conn;
    }

    private void TryReplaceBrokenConnection()
    {
        lock (_creationLock)
        {
            if (_allConnections.Count < MAX_POOL_SIZE)
            {
                var replacement = CreateNewConnection();
                _allConnections.Add(replacement);
                _availableConnections.Enqueue(replacement);
            }
        }
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(DBConnectionPool));
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        // Dispose all connections
        foreach (var conn in _allConnections)
        {
            try { conn.Dispose(); }
            catch { /* log */ }
        }

        _allConnections.Clear();
        while (_availableConnections.TryDequeue(out var c))
        {
            try { c.Dispose(); }
            catch { /* log */ }
        }
    }

    public int CurrentSize => _allConnections.Count;
    public int AvailableCount => _availableConnections.Count;
}

// ────────────────────────────────────────────────
//          Simulated / Mock DBConnection
// ────────────────────────────────────────────────

public class DBConnection : IDisposable
{
    private readonly string _connectionString;
    private bool _isOpen;
    private bool _disposed;

    public DBConnection(string connectionString)
    {
        _connectionString = connectionString;
        // In real code: SqlConnection, NpgsqlConnection, etc.
    }

    public void Open()
    {
        ThrowIfDisposed();
        if (!_isOpen)
        {
            // Simulate opening
            _isOpen = true;
            Console.WriteLine($"[Connection] Opened: {_connectionString}");
        }
    }

    public bool IsValid() => !_disposed && _isOpen; // + real health check in production

    public void Execute(string query)
    {
        ThrowIfDisposed();
        if (!_isOpen) throw new InvalidOperationException("Connection is not open");
        Console.WriteLine($"[Query] {query}");
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(DBConnection));
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _isOpen = false;
        Console.WriteLine("[Connection] Disposed");
    }
}
```

### Recommended Usage Pattern (with `using`)

```csharp
using (var pool = new DBConnectionPool("Server=...;Database=...;..."))
{
    using (var conn = pool.GetConnection())
    {
        conn.Open();
        conn.Execute("SELECT * FROM Users");
        // work...
    } // ← connection automatically returned when `using` ends

    // or manually:
    var conn2 = pool.GetConnection();
    try
    {
        conn2.Open();
        // ...
    }
    finally
    {
        pool.ReturnConnection(conn2);
    }
}
```

### Even Better – Disposable Wrapper (recommended in production)

```csharp
public class PooledConnection : IDisposable
{
    private readonly DBConnectionPool _pool;
    public DBConnection Connection { get; }

    internal PooledConnection(DBConnection conn, DBConnectionPool pool)
    {
        Connection = conn;
        _pool = pool;
    }

    public void Dispose()
    {
        _pool.ReturnConnection(Connection);
    }
}

// In DBConnectionPool:
public PooledConnection Borrow()
{
    var conn = GetConnection();
    return new PooledConnection(conn, this);
}
```

Then usage becomes very clean:

```csharp
using (var pooled = pool.Borrow())
{
    pooled.Connection.Open();
    pooled.Connection.Execute("...");
}   // ← automatically returned to pool
```
