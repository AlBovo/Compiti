using System;

namespace Esercizio4
{
    internal class Program
    {
        #region Funzione per la lettura di un numero intero
        static int readInt(string message)
        {
            int result;
            string input;
            bool inputOK;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                inputOK = int.TryParse(input, out result);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero positivo, riprova ...");
                }
                else if(result < 0)
                {
                    Console.WriteLine("Il numero inserito non è positivo, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            return result;
        }
        #endregion

        static void Main(string[] args)
        {
            int n = readInt("Inserisci il numero di righe (numero intero positivo): ");
            int m = readInt("Inserisci il numero di colonne (numero intero positivo): ");

            #region Stampa del rettangolo n * m
            for (int i = 0; i < n; i++)
            {
                for(int e = 0; e < m; e++)
                {
                    Console.Write('#');
                }
                Console.Write('\n');
            }
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
