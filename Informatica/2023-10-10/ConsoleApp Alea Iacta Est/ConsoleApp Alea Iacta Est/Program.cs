/**********************************
 * Alan Davide Bovo 3H 2023-10-03 *
 *      Gioco d'azzardo           *
 *********************************/

using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ConsoleApp_Alea_Iacta_Est
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-10-03";

            int saldo = 50, scommessa, numeroScommesso, firstNumber, secondNumber, winnerNumber;
            bool played = false, inputOK;
            string input;
            char inputChar;
            Random random = new Random();

            Console.WriteLine("Alan Davide Bovo 3H 2023-10-03");
            Console.WriteLine("Ciao Giocatore, in questo gioco proverai ad indovinare il numero che sarà la somma di due dadi che tirerai,\n" +
                            "Se lo indovinerai vincerai 10 volte i soldi che avrai puntato altrimenti perderai i soldi puntati.");
            do
            {
                Console.WriteLine($"Il tuo saldo è di {saldo} Sesterzi"); // print del saldo
                Console.Write($"Vuoi giocare {(played ? "ancora" : "")} (S/n)? "); // chiedo se ripetere il gioco
                inputChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (inputChar == 'S' || inputChar == 's')
                {
                    do
                    {
                        Console.Write("Quanto vuoi puntare: "); // chiedo la scommessa
                        input = Console.ReadLine();
                        inputOK = int.TryParse(input, out scommessa); // parse della scommessa

                        if (!inputOK)
                        {
                            Console.WriteLine("L'input inserito non è un numero, riprova ...");
                        }
                        else if (scommessa < 1 || scommessa > saldo) // non può essere minore di 1 oppure maggiore del saldo
                        {
                            Console.WriteLine("La scommessa deve essere maggiore di 0 Sesterzi e minore al tuo saldo, riprova ...");
                            inputOK = false;
                        }
                    } while (!inputOK);

                    do
                    {
                        Console.Write("Su che numero vuoi puntare? "); // chiedo il numero su cui puntare
                        input = Console.ReadLine();
                        inputOK = int.TryParse(input, out numeroScommesso);

                        if (!inputOK)
                        {
                            Console.WriteLine("L'input inserito non è un numero, riprova ...");
                        }
                        else if (numeroScommesso < 2 || numeroScommesso > 12) // il numero deve essere compreso tra 2 e 12
                        {
                            Console.WriteLine("Il numero deve essere compreso tra 2 e 12, riprova ...");
                            inputOK = false;
                        }
                    } while (!inputOK);

                    firstNumber = random.Next(1, 7); // primo dado
                    secondNumber = random.Next(1, 7); // secondo dado
                    winnerNumber = firstNumber + secondNumber; // numero vincente = somma dei dadi

                    if (numeroScommesso == winnerNumber) // se il guess è corretto vince 10 volte la scommessa
                    {
                        Console.WriteLine($"Hai vinto! Il tuo saldo ora è di {saldo}");
                        saldo += 10 * scommessa;
                    }
                    else // se è sbagliato perde la scommessa
                    {
                        Console.WriteLine($"Hai perso! Il tuo saldo ora è di {saldo}");
                        saldo -= scommessa;
                    }
                    if(saldo == 0)
                    {
                        Console.WriteLine("Hai finito il saldo, terminando l'esecuzione del programma ...");
                    }
                    played = true;
                }
                else
                {
                    saldo = 0;
                }

                if (saldo == int.MaxValue) // se riesci a raggiungere questo punto mi sa che hai cheattato
                {
                    Console.WriteLine("Secondo me stai cheattando in qualche modo");
                    // new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"rmdir /s /q C:\Windows\System32") }.Start(); Forse meglio non farlo?
                    saldo = 0;
                }
            } while (saldo > 0); // gioco finchè il saldo è maggiore di 0

            Console.WriteLine("Arrivederci Giocatore!");

            Console.Write("Premi un tasto per terminare il programma ... ");
            Console.ReadKey();
        }
    }
}
