/*********************************
* Alan Davide Bovo 3H 2024-02-21 *
*    Console Tabella Unicode     *
*********************************/
using System;
using System.Collections.Generic;

namespace TabellaUnicode
{
    internal class Program
    {
        #region Funzione per parsare un intero da console
        static int readInt(string message)
        {
            bool inputOK;
            int input;
            string inputStr;

            do
            {
                Console.Write(message);
                inputStr = Console.ReadLine();
                inputOK = int.TryParse(inputStr, out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                }
            } while (!inputOK);
            return input;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2024-02-21";       // intestazione del programma
            Console.OutputEncoding = System.Text.Encoding.Unicode;  // encoding della console per poter stampare tutti i caratteri

            int left = readInt("Enter the start of the range to print: "), right = readInt("Enter the end of the range to print: "); // leggo gli estremi del range
            int SIZE_TABLE = right - left;  // la size della table
            Console.Write("┌");             // estremo della table
            for (int i = 0; i < 8; i++)
            {
                Console.Write(new string('─', 20)); // scrivo i caratteri della prima riga
                if (i < 7)
                    Console.Write("┬");             // stampo un carattere divisore
            }
            Console.WriteLine("┐");         // estremo della table

            for (int i = 0; i < (int)Math.Ceiling(SIZE_TABLE / 8.0); i++)
            {
                List<string> chars = new List<string>();    // lista in cui salvo tutti i caratteri della riga corrente
                for (int e = 0; e < 8; e++)
                    chars.Add($"{(char)(i * 8 + e + left)}".Replace(" ", "Spc")); // salvo il carattere, se è uno spazio lo scambio con "Spc"

                for (int e = 0; e < chars.Count; e++)
                    chars[e] = (char.IsControl(chars[e][0])) ? "Controllo" : chars[e]; // se il carattere è un controllo cambio il carattere con "Controllo"

                Console.Write("│");                     // stampo divisore tra le colonne
                for (int e = 0; e < 8; e++)
                    if (i * 8 + left + e > right)
                        Console.Write("│".PadLeft(21)); // se non è un carattere nel range stampo un buco vuoto
                    else
                        Console.Write($" {i * 8 + left + e ,4}  :  {chars[e].PadLeft(9)} │"); // stampo valore decimale : char
                Console.WriteLine(); // vado a capo
            }

            Console.Write("└"); // estremo della table
            for (int i = 0; i < 8; i++)
            {
                Console.Write(new string('─', 20)); // stampo la riga
                if (i < 7)
                    Console.Write("┴"); // stampo divisore della colonna
            }
            Console.WriteLine("┘"); // estremo della table

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
