/*********************************
* Alan Davide Bovo 3H 2024-02-06 *
*        Progetto Bitwise        *
*********************************/

using System;
using System.Collections.Generic;

namespace ProgettoBitwise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 60;
            int b = 13;
            int c;

            c = a & b;
            Console.WriteLine("Line 1 - Value of c is {0}", c);

            c = a | b;
            Console.WriteLine("Line 2 - Value of c is {0}", c);

            c = a ^ b;
            Console.WriteLine("Line 3 - Value of c is {0}", c);

            c = ~a;
            Console.WriteLine("Line 4 - Value of c is {0}", c);

            c = a << 2;
            Console.WriteLine("Line 5 - Value of c is {0}", c);

            c = a >> 2;
            Console.WriteLine("Line 6 - Value of c is {0}", c);
            Console.ReadLine();
        }
    }
}
