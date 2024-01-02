using System;
using System.Diagnostics;

namespace Compito7
{
    internal class Program
    {
        #region Funzione O(N * log(log(N))) per trovare i numeri primi
        static void isPrimeEratostene(int n)
        {
            bool[] nums = new bool[n];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = true;
            nums[1] = true;
            nums[2] = true;

            for (int i = 2; i < nums.Length; i++)
            {
                if (!nums[i])
                    continue;
                for (int e = 2; e * i < nums.Length; e++)
                    nums[e * i] = false;
            }
        }
        #endregion

        #region Funzione O(N^2) per trovare i numeri primi
        static bool isPrime(int n, int[] primes)
        {
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == 0)
                    break;
                if (n % primes[i] == 0)
                    return false;
            }
            return true;
        }

        static void isPrimePersonale(int n)
        {
            int[] primes = new int[n];
            int vett_count = 0;
            for (int i = 2; vett_count < primes.Length; i++)
            {
                if (isPrime(i, primes))
                    primes[vett_count++] = i;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Stopwatch cronometro = new Stopwatch();
            int[] times = { 10, 100, 1000, 10000, 100000, 1000000 };
            foreach (int time in times)
            {
                Console.WriteLine($"Tempo di esecuzione per {time} numeri:");
                cronometro.Restart();
                isPrimeEratostene(time);
                cronometro.Stop();
                Console.WriteLine($"Eratostene: {cronometro.ElapsedMilliseconds}ms");
                cronometro.Restart();
                isPrimePersonale(time);
                cronometro.Stop();
                Console.WriteLine($"Personale: {cronometro.ElapsedMilliseconds}ms");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
