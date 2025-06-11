/**********************************
 * Alan Davide Bovo 3H 2023-10-25 *
 * Conversione da base 16 a 2 e 10*
 *********************************/
using System;
using System.Collections.Generic;

namespace ConsoleApp_ConversioniEsadecimale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-10-25";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-25");

            #region Dichiarazione delle variabili
            string inputEsadecimale;
            int outputDecimale = 0;
            bool inputOK;
            Dictionary<char, string> ESADECIMALE_BINARIO = new Dictionary<char, string>() // "tabella" per convertire da esadecimale a binario
            {
                {'0', "0000"}, {'1', "0001"}, {'2', "0010"}, {'3', "0011"}, {'4', "0100"},
                {'5', "0101"}, {'6', "0110"}, {'7', "0111"}, {'8', "1000"}, {'9', "1001"},
                {'A', "1010"}, {'B', "1011"}, {'C', "1100"}, {'D', "1101"}, {'E', "1110"},
                {'F', "1111"}
            };
            #endregion

            #region Lettura del numero esadecimale
            do
            {
                inputOK = true;
                Console.Write("Inserisci un numero esadecimale con al più 2 cifre: ");
                inputEsadecimale = Console.ReadLine().ToUpper();
                if(inputEsadecimale.Length > 2 || inputEsadecimale.Length <= 0) // l'input è troppo lungo o troppo corto
                {
                    Console.WriteLine("L'input inserito è troppo lungo, riprova ...");
                    inputOK = false;
                }
                else
                {
                    #region Conversione a base 10
                    outputDecimale = 0;
                    for(int i = 0, potenza = inputEsadecimale.Length-1; i < inputEsadecimale.Length; i++, potenza--)
                    {
                        if ((inputEsadecimale[i] >= '0' && inputEsadecimale[i] <= '9') || (inputEsadecimale[i] >= 'A' && inputEsadecimale[i] <= 'F')) // se non è nel range vuol dire che non è valido
                        {
                            if (inputEsadecimale[i] >= '0' && inputEsadecimale[i] <= '9')
                            {
                                outputDecimale += int.Parse(inputEsadecimale[i].ToString()) * (int)Math.Pow(16, potenza); // converto normalmente in base 10
                            }
                            else
                            {
                                outputDecimale += (inputEsadecimale[i] - 'A' + 10) * (int)Math.Pow(16, potenza); // calcolo il valore usando le tabelle ascii
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'input inserito non è un numero esadecimale valido, riprova ...");
                            inputOK = false;
                            break;
                        }
                    }
                    #endregion
                }
            } while (!inputOK);
            #endregion

            #region Stampa del numero decimale
            Console.WriteLine($"Il numero in base 16 {inputEsadecimale} equivale al numero in base 10 {outputDecimale}");
            #endregion

            #region Conversione in base 2 e stampa del risultato
            Console.Write($"Il numero in base 16 {inputEsadecimale} equivale al numero in base 2 ");
            for(int i = 0; i < inputEsadecimale.Length; i++)
            {
                Console.Write($"{ESADECIMALE_BINARIO[inputEsadecimale[i]]} "); // uso la "tabella" per stampare l'equivalente binario
            }
            Console.WriteLine();
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
