using System;

namespace Compito4
{
    internal class Program
    {
        static void Sort(int[] eta, string[] nomi)
        {
            for (int i = 0; i < eta.Length - 1; i++)
            {
                int j_min = i;
                for (int j = i + 1; j < eta.Length; j++)
                {
                    if (eta[j_min] > eta[j])
                        j_min = j;
                }

                if (i != j_min)
                {
                    int aux = eta[i];
                    eta[i] = eta[j_min];
                    eta[j_min] = aux;

                    string aux2 = nomi[i];
                    nomi[i] = nomi[j_min];
                    nomi[j_min] = aux2;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Inserisci la lunghezza del vettore: ");
            int length = int.Parse(Console.ReadLine());
            int[] eta = new int[length];
            string[] nomi = new string[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write("Inserisci il nome della persona: ");
                nomi[i] = Console.ReadLine();
                Console.Write("Inserisci l'età della persona: ");
                eta[i] = int.Parse(Console.ReadLine());
            }

            Sort(eta, nomi);
            Console.Clear();
            Console.WriteLine("Questo è l'elenco delle persone ordinate per età: ");
            for(int i=0; i<length; i++)
            {
                Console.WriteLine($"{i+1}. {nomi[i]}: {eta[i]}");
            }

            Console.ReadKey();
        }
    }
}
