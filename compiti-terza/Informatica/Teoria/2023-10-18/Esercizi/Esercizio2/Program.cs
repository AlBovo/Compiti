using System;

namespace Esercizio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            int left = 1, right = 100, mid; // [left, right)
            char input;
            #endregion

            #region Stampa delle regole di gioco
            Console.WriteLine("Questo programma cercherà di indovinare un numero nel range da 1 a 100");
            Console.WriteLine("Ogni volta che il programma proverà un numero dire se è maggiore (>), minore(<) o uguale(=)");
            Console.WriteLine("");
            #endregion

            #region Gioco con controllo e binary search
            do
            {
                mid = left + (right - left) / 2;

                #region Lettura e controllo dell'input
                do
                {
                    Console.Write($"Il programma ha provato il numero {mid}, inserisci il risultato: ");
                    input = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if(!(input == '>' || input == '<' || input == '='))
                    {
                        Console.WriteLine("L'input inserito non è valido, riprova ... ");
                    }
                } while (!(input == '>' || input == '<' || input == '='));
                #endregion

                #region Caso in cui il giocatore stia cercando di barare
                if (input != '=' && left > right)
                {
                    Console.WriteLine($"L'input inserito non può essere valido poichè il range è composto da un solo elemento ({left})...");
                    break;
                }
                #endregion

                #region Modifica del range della binary search
                if (input == '>')
                {
                    left = mid + 1;
                }
                else if(input == '<')
                {
                    right = mid - 1;
                }
                #endregion
            } while (input != '=');
            Console.WriteLine("Arrivederci giocatore ...");
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
