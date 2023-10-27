/*********************************
* Alan Davide Bovo 3H 2023-10-24 *
*     Massimo, Minimo e Media    *
*********************************/

using System;

namespace MinimoMassimoMediaConsole
{
    internal class Program
    {
        const string FINE = "fine";
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-10-24";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-24");

            #region Dichiarazione delle variabili
            int massimo = int.MinValue, minimo = int.MaxValue-1, somma = 0, numeri = 0, inputNum;
            string input;
            bool inputOK = true, continua = true;
            #endregion

            #region Calcolo del minimo, massimo e media
            do
            {
                #region Lettura dell'input
                do
                {
                    Console.Write("Inserisci un numero oppure inserisci \"" + FINE + "\" per richiedere i risultati: ");
                    input = Console.ReadLine();
                    inputOK = int.TryParse(input, out inputNum);

                    if (!inputOK && input != FINE)
                    {
                        Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                    }
                    else if (input == FINE)
                    {
                        continua = false;
                        break;
                    }
                } while (!inputOK);
                #endregion

                if (input != FINE) // se l'input non è FINE allora posso contarlo come numero
                {
                    massimo = Math.Max(massimo, inputNum);
                    minimo = Math.Min(minimo, inputNum);
                    somma += inputNum;
                    numeri++;
                }
            } while (continua);
            #endregion

            #region Stampo dei risultati
            if (numeri == 0)
            {
                Console.WriteLine("Hai inserito 0 numeri, risultato non disponibile ...");
            }
            else
            {
                Console.WriteLine($"Ecco i risultati: \nMassimo: {massimo}\nMinimo: {minimo}\nMedia: {(double)(somma) / (double)(numeri):0.000}.");
            }
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
