/**********************************
 * Alan Davide Bovo 3H 2023-10-04 *
 *      Conversione di base       *
 *********************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ConversioneDiBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, newBase;
            bool inputOK;
            Console.Title = "Alan Davide Bovo 3H 2023-10-04";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-04");

            #region Conversione da base 10 a base 2, 10 e 16
            do // parse dell'input
            {
                Console.Write("Inserisci un numero in base 10 da convertire: ");
                inputOK = int.TryParse(Console.ReadLine(), out numero);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non era un numero, riprova ...");
                }
            } while (!inputOK);

            Console.WriteLine($"Numero in base 2: {Convert.ToString(numero, 2)}"); // conversione a base 2
            Console.WriteLine($"Numero in base 10: {numero}"); // conversione da base 10 a base 10
            Console.WriteLine($"Numero in base 16: {Convert.ToString(numero, 16)}"); // conversione a base 16
            #endregion

            #region Conversione da base 10 a base X
            do // parse del numero da convertire
            {
                Console.Write("Inserisci un numero in base 10 da convertire: ");
                inputOK = int.TryParse(Console.ReadLine(), out numero);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non era un numero, riprova ...");
                }
            } while (!inputOK);
            do // parse della base a cui convertire
            {
                Console.Write("Inserisci la nuova base in cui convertire il numero (solo 16, 10, 8 e 2): ");
                inputOK = int.TryParse(Console.ReadLine(), out newBase);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non era un numero");
                }
                else if (newBase != 16 && newBase != 8 && newBase != 2 && newBase != 10) // accetto solo basi 2, 8, 10 e 16
                {
                    Console.WriteLine("La base deve essere per forza solo 16, 10, 8 o 2, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            Console.WriteLine($"Numero in base {newBase}: {Convert.ToString(numero, newBase)}"); // conversione di base
            #endregion

            Console.Write("Premi un tasto per terminare il programma ... ");
            Console.ReadKey();
        }
    }
}
