using System;

namespace Compito6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di elementi da calcolare: ");
            bool[] nums = new bool[int.Parse(Console.ReadLine())];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = true;
            nums[1] = true;
            nums[2] = true;

            for (int i = 2; i < nums.Length; i++)
            {
                if (!nums[i])
                    continue;
                for (int e = 2; e * i < nums.Length; e++)
                    nums[e*i] = false;
            }

            Console.Write("I numeri primi sono: ");
            for (int i = 2; i < nums.Length; i++)
                if (nums[i])
                    Console.Write(i + " ");

            Console.ReadKey();
        }
    }
}
