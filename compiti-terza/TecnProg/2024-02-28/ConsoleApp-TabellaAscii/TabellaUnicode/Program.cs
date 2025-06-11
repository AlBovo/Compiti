/*********************************
* Alan Davide Bovo 3H 2024-02-21 *
*    Console Tabella Unicode     *
*********************************/
using System;
using System.Collections.Generic;

namespace TabellaUnicode
{
    internal class Program
    {
        static int readInt(string message)
        {
            bool inputOK;
            int input;
            string inputStr;

            do
            {
                Console.Write(message);
                inputStr = Console.ReadLine();
                inputOK = int.TryParse(inputStr, out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                }
            } while (!inputOK);
            return input;
        }

        static int GCD(int p, int q)
        {
            if (q == 0)
            {
                return p;
            }

            int r = p % q;

            return GCD(q, r);
        }

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2024-02-21";
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int left = readInt("Enter the start of the range to print: "), right = readInt("Enter the end of the range to print: ");
            int SIZE_TABLE = right - left;
            Console.Write("┌");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(new string('─', 20));
                if (i < 7)
                    Console.Write("┬");
            }
            Console.WriteLine("┐");

            for (int i = 0; i < SIZE_TABLE / 8; i++)
            {
                List<string> chars = new List<string>();
                for (int e = i+left; e < SIZE_TABLE+left; e += SIZE_TABLE / 8)
                    chars.Add($"{(char)e}".Replace(" ", "Spc"));

                for (int e = 0; e < chars.Count; e++)
                    chars[e] = (char.IsControl(chars[e][0])) ? "Controllo" : chars[e];

                Console.Write("│");
                for (int e = i+left; e < SIZE_TABLE+left; e += SIZE_TABLE / 8)
                    Console.Write($" {e.ToString().PadLeft(4)}  :  {chars[(e - i - left) / (SIZE_TABLE / 8)].PadLeft(9)} │");
                Console.WriteLine();
            }

            Console.Write("└");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(new string('─', 20));
                if (i < 7)
                    Console.Write("┴");
            }
            Console.WriteLine("┘");

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
