using System;
using System.Runtime.Remoting.Lifetime;

namespace Esercizio2
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
            int dividendo = readInt("Inserisci il dividendo: ");
            int divisore = readInt("Inserisci il divisore: ");

            int quoziente = 0, resto;

            #region Calcolo del quoziente e del resto
            if ((dividendo <0 && divisore > 0) || (dividendo > 0 && divisore < 0)) // se sono di diverso segno allora il quoziente è negativo
            {
                dividendo = Math.Abs(dividendo);
                divisore = Math.Abs(divisore);

                while (Math.Abs(dividendo) >= Math.Abs(divisore))
                {
                    dividendo -= divisore;
                    quoziente++;
                }
                quoziente = -quoziente;
                resto = dividendo;
            }
            else // altrimenti il quoziente è positivo
            {
                while (Math.Abs(dividendo) >= Math.Abs(divisore))
                {
                    dividendo -= divisore;
                    quoziente++;
                }
                resto = dividendo;
            }
            #endregion

            Console.WriteLine("Il quoziente è {0} e il resto è {1}", quoziente, resto); // stampa del risultato

            Console.WriteLine("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
