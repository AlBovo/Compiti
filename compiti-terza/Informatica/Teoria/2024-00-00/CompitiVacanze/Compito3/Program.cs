using System;

namespace Compito3
{
    internal class Program
    {
        static bool isOrdered(int[] vett)
        {
            for(int i=0; i<vett.Length-1; i++)
                if (vett[i] > vett[i+1])
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Inserisci la lunghezza del vettore: ");
            int[] vett = new int[int.Parse(Console.ReadLine())];
            for(int i=0; i<vett.Length; i++)
            {
                Console.Write("Inserisci un numero: ");
                vett[i] = int.Parse(Console.ReadLine());
            }
            if(isOrdered(vett))
                Console.WriteLine("Il vettore è ordinato");
            else
                Console.WriteLine("Il vettore non è ordinato");

            Console.ReadKey();
        }
    }
}
