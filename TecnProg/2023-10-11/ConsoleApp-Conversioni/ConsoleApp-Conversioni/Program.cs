/**********************************
 * Alan Davide Bovo 3H 2023-10-03 *
 * Conversione da base 10 a 2 e 16*
 *********************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_Conversioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-10-10";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-10");

            #region Dichiarazione delle variabili
            int numberBase10, tempNumber;
            string input, numberBase2 = "", numberBase16 = "";
            bool inputOK;
            #endregion

            #region Lettura del numero in base 10
            do
            {
                Console.Write("Inserisci il numero in base 10 (maggiore o uguale a 0): ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out numberBase10);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if(numberBase10 < 0)
                {
                    Console.WriteLine("Il numero deve essere maggiore o uguale a 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            #endregion

            #region Conversione del numero in base 2
            tempNumber = numberBase10;
            do
            {
                numberBase2 += (tempNumber % 2).ToString();
                tempNumber /= 2;
            } while (tempNumber > 0);
            numberBase2 = new string(numberBase2.ToCharArray().Reverse().ToArray());
            Console.WriteLine($"Il numero inserito in base 2 equivale a : {numberBase2}");
            #endregion

            #region Conversione del numero in base 16
            tempNumber = numberBase10;
            do
            {
                if (tempNumber % 16 >= 10)
                {
                    numberBase16 += (char)((tempNumber % 16) - 10 + 'A');
                }
                else
                {
                    numberBase16 += $"{tempNumber % 16}";
                }

                if (tempNumber < 16) break;

                tempNumber /= 16;
            } while (tempNumber > 0);
            numberBase16 = new string(numberBase16.ToCharArray().Reverse().ToArray());
            Console.WriteLine($"Il numero inserito in base 16 equivale a : {numberBase16}");
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
