using System;

namespace Compito5
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di primi da calcolare: ");
            int[] primes = new int[int.Parse(Console.ReadLine())];
            int vett_count = 0;
            for(int i=2; vett_count < primes.Length; i++)
            {
                if (isPrime(i, primes))
                    primes[vett_count++] = i;
            }

            Console.WriteLine("Questi sono i primi calcolati: ");
            foreach (int prime in primes)
                Console.Write($"{prime} ");
            
            Console.ReadKey();
        }
    }
}
