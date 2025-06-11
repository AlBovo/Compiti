using System;

namespace Esercizio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            Random rand = new Random();
            int input = -1, numeroVincente = rand.Next(1, 101);
            string inputStr;
            bool inputOK;
            #endregion

            #region Gioco con interazione con l'utente
            do
            {
                #region Stampa del risultato dei tentativi
                if (input != -1) Console.WriteLine($"Il numero inserito è {((input > numeroVincente) ? '>' : '<')}");
                #endregion

                #region Lettura e parse dell'input
                do
                {
                    Console.Write("Inserisci il numero che vuoi provare a indovinare: ");
                    inputStr = Console.ReadLine();
                    inputOK = int.TryParse(inputStr, out input);

                    if (!inputOK)
                    {
                        Console.WriteLine("L'input inserito non è un numero intero, riprova ... ");
                    }
                    else if(input < 1 || input > 100)
                    {
                        Console.WriteLine("Il numero inserito è fuori dal range da 1 a 100, riprova ...");
                        inputOK = false;
                    }
                } while (!inputOK);
                #endregion
            } while (input != numeroVincente);
            Console.WriteLine("Hai indovinato il numero complimenti !");
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
