using System;

namespace OrdinamentoDiArray
{
    internal class Program
    {
        #region Funzione per la lettura di un numero intero
        static int ReadInt(string message)
        {
            bool inputOK;
            int input;

            do
            {
                Console.Write(message);
                inputOK = int.TryParse(Console.ReadLine(), out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
                else if(input <= 0)
                {
                    Console.WriteLine("Il numero inserito non è un intero positivo, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            return input;
        }
        #endregion

        #region Ordinamento dell'array con Bubble Sort
        static void BubbleSort(int[] array)
        {
            int swap, minore;

            for (int i = 0; i < array.Length; i++)
            {
                minore = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minore])
                        minore = j;
                }

                if (minore != i)
                {
                    swap = array[i];
                    array[i] = array[minore];
                    array[minore] = swap;
                }                
            }
        }
        #endregion

        static void Main(string[] args)
        {
            int N = ReadInt("Inserisci il numero di elementi: ");
            int[] array = new int[N];

            for (int i = 0; i < N; i++)
                array[i] = ReadInt($"Inserisci il numero all'indice {i}: ");

            BubbleSort(array);

            for (int i = 0; i < N; i++)
                Console.WriteLine($"L'elemento all'indice {i} ora è: {array[i]}");

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
