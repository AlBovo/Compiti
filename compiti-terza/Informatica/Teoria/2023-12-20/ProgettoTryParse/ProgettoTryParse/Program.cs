using System;

namespace ProgettoTryParse
{
    internal class Program
    {
        static int Parse(string input)
        {
            int result = 0;
            foreach(char i in input)
            {
                if (i < '0' || i > '9') throw new ArgumentException();
                result = result * 10 + i - '0';
            }
            return result;
        }

        static bool TryParse(string input, out int output)
        {
            output = 0;
            try
            {
                output = Parse(input);
            }
            catch
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int output;
            bool inputOK;

            while (true)
            {
                Console.Write("Inserisci un valore da convertire: ");
                inputOK = TryParse(Console.ReadLine(), out output);
                if (inputOK)
                    Console.WriteLine($"Non è esploso: {output}");
                else
                    Console.WriteLine("È esploso");
            }
        }
    }
}
