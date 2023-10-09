/**********************************
 * Alan Davide Bovo 3H 2023-09-27 *
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
            string stInput, tempString;
            int inInput;
            double dbInput;
            bool inputOK = false;

            Console.Title = "Alan Davide Bovo 3H 2023-09-27";
            Console.WriteLine("Alan Davide Bovo 3H 2023-09-27");

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

            Console.Write("Premi un tasto per terminare l'esecuzione ...");
            Console.ReadKey();
        }
    }
}
