using System;
using System.Collections.Generic;
//https://www.sandordargo.com/blog/2023/11/15/most-important-complexities
//https://www.programiz.com/cpp-programming/online-compiler/

namespace dotnet
{
    public class BitManips
    {
        public BitManips()
        {
        }

        static void PrintBits(int num)
        {
            const int IntSize = sizeof(int) * 8;
            for (int i = IntSize - 1; i >= 0; i--)
            {
                int mask = 1 << i;
                int bit = (num & mask) == 0 ? 0 : 1;
                Console.Write(bit);
            }
            Console.WriteLine("");
        }

        static Func<int, string> printBits = (int k) => {
            int numsetbits = 0;
            Stack<int> st = new();

            int i = sizeof(int) * 8;
            while (k != 0 && i-- > 0)
            {
                st.Push(k & 1);
                k >>= 1; //same as k = k / 2;
            }

            string bits = "";
            foreach (var number in st)
            {
                bits += number;
            }

            return bits;
        };

        static Func<int, int> setBitCounter = (int k) => {
            int numsetbits = 0;
            while (k > 0)
            {
                if ((k & 1) == 1)
                    numsetbits++;

                k >>= 1; //same as k = k / 2;
            }
            return numsetbits;
        };

        static Func<int, int> allBitCounter = (int k) => {
            int numbits = 0;
            while (k > 0)
            {
                numbits++;

                k >>= 1;
            }
            return numbits;
        };

        static Func<int, int> allBitCounterMethod2 = (int k) => {
            int numbits = 0;
            while ((1 << numbits) <= k)
            {
                numbits++;
            }
            return numbits;
        };

        static Func<int, int, int> minusUsingBits = (int j, int k) => {
            int twosComplement = ~k + 1;
            int answer = j + twosComplement;
            return answer;
        };

        static Func<int, bool> isOdd = (int k) => { return (k & 1) == 1; };

        static Func<int, int, (int, int)> swap = (int a, int b) => {
            a = a ^ b;
            b = a ^ b; //(a^b^b) is 1 as b^b is 0; 0^a = a
            a = a ^ b; //a^b^a leaves b
            return (a, b);
        };

        public static void TestMain(string[] args)
        {
            int num = 125; //for negative, inverse the bits and add 1
            int switchSign = ~num + 1;
            Console.WriteLine("numsetbits for " + num + " are " + setBitCounter(num));

            Console.WriteLine("allsetbits for " + num + " are " + allBitCounter(num));

            Console.WriteLine("allsetbits for " + num + " are " + allBitCounterMethod2(num));

            Console.WriteLine("printing bits for the number " + num + ": " + printBits(num));

            Console.WriteLine("is number odd " + num + ": " + isOdd(num));

            Console.WriteLine(minusUsingBits(19, 7));

            var (a, b) = swap(10, 15);
            Console.WriteLine("a " + a + ", b " + b);

            //create a bit mask
            //4th bit from left
            int bit = 4;
            int mask = 1 << (bit - 1); //4th bit, 1000

            //use this mask to check if 4th (Ith) bit is set
            Console.WriteLine("is " + bit + "th bit is set for " + num + ": " + ((num & mask) > 0));

            //toggling ith bit using mask - use XOR to toggle
            Console.WriteLine("toggled ith bit for " + num + ": " + (num ^ mask));
            Console.WriteLine("printing bits: " + printBits(num ^ mask));
            //set Ith bit again
            int newnum = (num ^ mask) | mask;
            Console.WriteLine("new number is " + newnum);

            //clear Ith bit
            //create a mask where all bits are 1 except ith bit.
            //xor will toggle but & will clear a set bit
            int newmask = ~0; //inverse all 0 bits
            PrintBits(newmask);
            newmask = newmask ^ mask; /// 11111 ^ 00100
            PrintBits(newmask);

            //mask is 0001000
            newmask = ~mask; /// 1110111

            Console.WriteLine("After setting Ith to 0: ");
            PrintBits(newmask);
            num = 256;
            Console.WriteLine("printing bits before clearing: " + num + " : " + printBits(num ^ mask));
            Console.WriteLine("printing bits after: " + newnum + " : ");
            PrintBits(num & newmask);

            //Find how m any bits need to be changed
            //to convert a to b
            //Starategy: do a^b; the bits which are same will become 0
            //those that need to be flipped will become 1; count 1 bits for answer

            //n = n & (n-1) will change the LSB to 0;
            //if there are 4 set bits, n will be 0 in 4 steps
            int n = 125;
            int numsetbits = 0;
            while (n > 0)
            {
                numsetbits++;
                n = n & (n - 1);
            }
            Console.WriteLine("num set bits are : " + numsetbits);

            //for any number whoch is a power of 2, n&(n-1) will be 0
            PrintBits(125);
            PrintBits(-125);

            int num1 = 0b1010;  // Binary literal representation of 10

            // Bitwise complement
            int resultComplement = ~num1; // resultComplement = 0b11111111111111111111111111110101 (-11 in decimal)
            Console.WriteLine($"Bitwise Complement: {Convert.ToString(resultComplement, 2)}");
        }
    }
}

