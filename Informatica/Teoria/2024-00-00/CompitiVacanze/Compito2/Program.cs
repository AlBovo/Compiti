using System;
using System.Collections.Generic;

namespace Compito2
{
    internal class Program
    {
        static void ShiftRight(int[] vett, ref int vett_count, int idx)
        {
            for (int k = vett_count; k >= idx; --k)
                vett[k+1] = vett[k];
            ++vett_count;
        }

        static int RicercaBinaria(int[] v, int valore)
        {
            int i_sx = 0, i_dx = v.Length - 1;

            while (i_sx <= i_dx)
            {
                int i_mid = (i_sx + i_dx) / 2;

                if (v[i_mid] > valore)
                    i_dx = i_mid - 1;
                else if (v[i_mid] < valore)
                    i_sx = i_mid + 1;
                else
                    return i_mid;
            }

            return i_sx;
        }

        static void Main(string[] args)
        {
            int vett_count = -1, numero;
            List<int> sr = new List<int>();

            while (true)
            {
                Console.Write("Inserisci un numero: ");
                numero = int.Parse(Console.ReadLine());
                if (numero < 0)
                    break;
                sr.Add(numero);
            }
            
            int[] vett = new int[sr.Count];
            for(int i=0; i<vett.Length; i++)
                vett[i] = int.MaxValue;
            for (int i = 0; i < sr.Count; i++)
            {
                int pos = RicercaBinaria(vett, sr[i]);
                ShiftRight(vett, ref vett_count, pos);
                vett[pos] = sr[i];
            }
            Console.Write("This is the sorted array: ");
            foreach(int i in vett)
                Console.Write($"{i} ");
            Console.Write('\n');

            Console.ReadKey();
        }
    }
}
