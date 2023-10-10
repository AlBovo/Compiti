/**********************************
 * Alan Davide Bovo 3H 2023-10-03 *
 * Lettura e stampa di una string *
 *********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN_STUDS = 10, MAX_STUDS = 35; // limiti per il numero di studenti
            const double MIN_HEIGHT = 0.24, MAX_HEIGHT = 2.72; // limiti per il l'altezza massima e minima di un essere umano
            string stInput, tempString;
            int inInput, numStudents;
            double dbInput, height;
            bool inputOK = false;

            Console.Title = "Alan Davide Bovo 3H 2023-10-03";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-03");

            #region Lettura e stampa di una stringa
            Console.Write("Input Stringa -> ");
            stInput = Console.ReadLine(); // lettura della stringa
            Console.WriteLine("Stinga Letta -> " + stInput); // scrittura della stringa
            #endregion

            #region Lettura e stampa di un intero
            do
            {
                Console.Write("Input Intero -> ");
                tempString = Console.ReadLine(); // lettura della stringa
                inputOK = int.TryParse(tempString, out inInput); // parse del numero
                if (!inputOK) // controllo se il parse è andato a buon fine
                {
                    Console.WriteLine("L'input inserito non è un intero, riprova ...");
                }
            } while (!inputOK);
            Console.WriteLine("Intero Letto -> " + inInput.ToString()); // scrittura dell'intero
            #endregion

            #region Lettura e stampa di un double
            do
            {
                Console.Write("Input Numero Reale -> ");
                tempString = Console.ReadLine(); // lettura della stringa
                inputOK = double.TryParse(tempString, out dbInput); // parse del numero reale
                if (!inputOK) // se il parse non è andato a buon fine
                {
                    Console.WriteLine("L'input inserito non è un numero reale, riprova ...");
                }
            } while (!inputOK);
            Console.WriteLine("Numero Reale Letto -> {0}", dbInput); // scrittura del numero reale letto
            #endregion

            #region Lettura e stampa di un numero di studenti
            do
            {
                Console.Write("Numero di Studenti (tra 10 e 35) -> ");
                tempString = Console.ReadLine(); // lettura della stringa
                inputOK = int.TryParse(tempString, out numStudents); // parse del numero intero di studenti
                if (!inputOK) // se l'input non è un numero intero
                {
                    Console.WriteLine("L'input inserito non è un intero, riprova ...");
                }
                else if(numStudents < MIN_STUDS || numStudents > MAX_STUDS) // se il numero di studenti non rispetta i limiti
                {
                    Console.WriteLine("Il numero degli studenti può essere solo tra 10 e 35 studenti, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            Console.WriteLine("Numero di Studenti Letto -> " + numStudents.ToString()); // print del numero di studenti
            #endregion

            #region Lettura e stampa dell'altezza di un essere umano
            do
            {
                Console.Write("Altezza di un essere umano (tra 0,24 e 2,72) -> ");
                tempString = Console.ReadLine(); // lettura della stringa
                inputOK = double.TryParse(tempString, out height); // parse del numero reale (altezza di un essere umano)
                if (!inputOK) // se l'input non è un numero reale
                {
                    Console.WriteLine("L'input inserito non è un numero reale, riprova ...");
                }
                else if (height < MIN_HEIGHT || height > MAX_HEIGHT) // se l'altezza non rispetta i limiti
                {
                    Console.WriteLine("L'altezza di un essere umano può essere solo tra 0,24 metri e 2,72 metri, riprova...");
                    inputOK = false;
                }
            } while (!inputOK);
            Console.WriteLine("Altezza di un essere umano Letto -> " + height.ToString()); // print dell'altezza di un essere umano
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione ...");
            Console.ReadKey();
        }
    }
}
