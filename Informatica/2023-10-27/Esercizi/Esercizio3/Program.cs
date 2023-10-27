using System;

namespace Esercizio5
{
    internal class Program
    {
        #region Funzione per la lettura di un numero reale
        static double readDouble(string message)
        {
            double result;
            string input;
            bool inputOK;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                inputOK = double.TryParse(input, out result);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero reale, riprova ...");
                }
            } while (!inputOK);

            return result;
        }
        #endregion

        #region Funzione per la lettura di una stringa
        static string readString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        #endregion

        static void Main(string[] args)
        {
            string nomeProdotto, nomeProdottoCostoso = "";
            double prezzoProdotto, prezzoProdottoCostoso = double.MinValue;

            #region Lettura di tutti i prodotti e calcolo del più costoso
            while (true)
            {
                nomeProdotto = readString("Inserisci il nome del prodotto: ");

                if (nomeProdotto == "") break;

                prezzoProdotto = readDouble("Inserisci il prezzo del prodotto: ");

                if (prezzoProdotto > prezzoProdottoCostoso)
                {
                    prezzoProdottoCostoso = prezzoProdotto;
                    nomeProdottoCostoso = nomeProdotto;
                }
                Console.Clear();
            }
            #endregion

            Console.WriteLine("Il prodotto più costoso è {0} e costa {1:0.0}", nomeProdottoCostoso, prezzoProdottoCostoso); // stampo i dati del più costoso

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
