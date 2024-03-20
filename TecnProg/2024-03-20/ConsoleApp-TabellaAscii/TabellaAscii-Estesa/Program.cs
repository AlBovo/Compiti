/*********************************
* Alan Davide Bovo 3H 2024-02-21 *
*  Console Tabella Ascii Estesa  *
*********************************/
using System;
using System.Collections.Generic;

namespace TabellaAscii_Standard
{
    internal class Program
    {
        const int SIZE_TABLE = 256; // size fissa della table

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // imposto l'encoding per poter stampare tutti i caratteri
            Console.Title = "Alan Davide Bovo 3H 2024-02-21";   // intestazione del programma
            for (int i = 0; i < SIZE_TABLE / 8; i++)
            {
                List<string> chars = new List<string>();        // lista dei caratteri da stampare
                for (int e = i; e < SIZE_TABLE; e += 32)
                    chars.Add($"{(char)e}".Replace(" ", "Spc"));// se il carattere è uno spazio lo scambio con "Spc"

                for (int e = 0; e < chars.Count; e++)
                    chars[e] = (char.IsControl(chars[e][0])) ? "Controllo" : chars[e]; // se il carattere è un controllo lo scambio con "Controllo"

                for (int e = i; e < SIZE_TABLE; e += 32)
                    Console.Write($" {e.ToString().PadLeft(4)}  :  {chars[(e-i)/32].PadLeft(9)} "); // stampo i caratteri paddati
                Console.WriteLine();
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
