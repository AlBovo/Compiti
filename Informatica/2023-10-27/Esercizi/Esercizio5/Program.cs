using System;

namespace Esercizio5
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
                    Console.WriteLine("Il numero inserito deve essere positivo, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            return result;
        }
        #endregion

        static void Main(string[] args)
        {
            int n = readInt("Inserisci la base del quadrato: ");
            int somma = 0;

            #region Calcolo del quadrato di n
            for (int i = 1, count = 0; count < n; i+=2, count++)
            {
                somma += i;
            }
            #endregion

            Console.WriteLine($"Il quadrato di {n} è {somma}"); // stampa del risultato

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
