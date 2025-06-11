/*********************************
* Alan Davide Bovo 3H 2023-10-24 *
*  Da numero a parole (da 0 a 9) *
*********************************/
using System;

namespace ConsoleNumeriParole
{
    internal class Program
    {
        const int MAX_NUMBER = 9, MIN_NUMBER = 0; // numero massimo e minimo elaborabile
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            //string[] unita = { "zero", "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove" };
            int number;
            string numberAsString;
            bool inputOK;
            #endregion

            Console.Title = "Alan Davide Bovo 3H 2023-10-24";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-24");

            #region Lettura del numero e conversione a stringa
            do
            {
                Console.Write($"Inserisci il numero da convertire a parole (tra {MAX_NUMBER} e {MIN_NUMBER}): ");
                numberAsString = Console.ReadLine();
                inputOK = int.TryParse(numberAsString, out number);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
                else if (number > MAX_NUMBER || number < MIN_NUMBER) // input fuori dal range
                {
                    inputOK = false;
                    Console.WriteLine($"Il numero inserito non è nel range {MAX_NUMBER}/{MIN_NUMBER}, riprova ...");
                }
            } while (!inputOK);
            #endregion

            #region Conversione a parola
            //Console.WriteLine($"Il numero convertito a parola è: {unita[number]}"); // uso dell'array

            Console.Write($"Il numero convertito a parola usando l'if è: ");
            if (number == 0) // sequenza di if
            {
                Console.WriteLine("zero");
            }
            else if (number == 1)
            {
                Console.WriteLine("uno");
            }
            else if (number == 2)
            {
                Console.WriteLine("due");
            }
            else if (number == 3)
            {
                Console.WriteLine("tre");
            }
            else if (number == 4)
            {
                Console.WriteLine("quattro");
            }
            else if (number == 5)
            {
                Console.WriteLine("cinque");
            }
            else if (number == 6)
            {
                Console.WriteLine("sei");
            }
            else if (number == 7)
            {
                Console.WriteLine("sette");
            }
            else if (number == 8)
            {
                Console.WriteLine("otto");
            }
            else
            {
                Console.WriteLine("nove");
            }

            Console.Write($"Il numero convertito a parola usando lo switch è: ");
            switch (number) // sequenza usando lo switch
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("uno");
                    break; 
                case 2:
                    Console.WriteLine("due");
                    break;
                case 3:
                    Console.WriteLine("tre");
                    break;
                case 4:
                    Console.WriteLine("quattro");
                    break;
                case 5:
                    Console.WriteLine("cinque");
                    break;
                case 6:
                    Console.WriteLine("sei");
                    break;
                case 7:
                    Console.WriteLine("sette");
                    break;
                case 8:
                    Console.WriteLine("otto");
                    break;
                case 9:
                    Console.WriteLine("nove");
                    break;
            }
            #endregion

            Console.Write("Premi un tasto per terminare il programma ... ");
            Console.ReadKey();
        }
    }
}
