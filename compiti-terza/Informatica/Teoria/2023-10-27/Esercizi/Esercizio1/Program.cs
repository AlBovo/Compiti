using System;

namespace Esercizi
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
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
            } while (!inputOK);

            return result;
        }
        #endregion

        static void Main(string[] args)
        {
            int primoNumero = readInt("Inserisci il primo numero: ");
            int secondoNumero = readInt("Inserisci il secondo numero: ");

            int moltiplicazione = 0;

            #region Calcolo della moltiplicazione con un ciclo for
            for (int i = 0; i < Math.Abs(primoNumero); i++)
            {
                if (primoNumero < 0)
                {
                    moltiplicazione -= secondoNumero;
                }
                else
                {
                    moltiplicazione += secondoNumero;
                }
            }
            #endregion

            Console.WriteLine("Il risultato della moltiplicazione è: " + moltiplicazione);

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
