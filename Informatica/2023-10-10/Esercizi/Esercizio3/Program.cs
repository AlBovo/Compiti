using System;

namespace Esercizio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            int ore1, minuti1, secondi1;
            int ore2, minuti2, secondi2;
            int ore3, minuti3, secondi3;
            int secondiTotali1, secondiTotali2, differenza;
            string input;
            bool inputOK;
            #endregion

            #region Lettura del primo orario
            do
            {
                Console.Write("Inserisci le ore del primo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out ore1);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (ore1 < 0 || ore1 > 24)
                {
                    Console.WriteLine("Le ore non possono essere maggiori di 24 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            do
            {
                Console.Write("Inserisci i minuti del primo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out minuti1);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (minuti1 < 0 || minuti1 > 60)
                {
                    Console.WriteLine("I minuti non possono essere maggiori di 60 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            do
            {
                Console.Write("Inserisci i secondi del primo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out secondi1);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (secondi1 < 0 || secondi1 > 60)
                {
                    Console.WriteLine("I secondi non possono essere maggiori di 60 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            #endregion

            #region Lettura del secondo orario
            do
            {
                Console.Write("Inserisci le ore del secondo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out ore2);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (ore2 < 0 || ore2 > 24)
                {
                    Console.WriteLine("Le ore non possono essere maggiori di 24 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            do
            {
                Console.Write("Inserisci i minuti del secondo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out minuti2);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (minuti2 < 0 || minuti2 > 60)
                {
                    Console.WriteLine("I minuti non possono essere maggiori di 60 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);

            do
            {
                Console.Write("Inserisci i secondi del secondo orario: ");
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out secondi2);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero, riprova ...");
                }
                else if (secondi2 < 0 || secondi2 > 60)
                {
                    Console.WriteLine("I secondi non possono essere maggiori di 60 o minori di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            #endregion

            #region Calcolo della differenza di orario
            secondiTotali1 = ore1 * 3600 + minuti1 * 60 + secondi1;
            secondiTotali2 = ore2 * 3600 + minuti2 * 60 + secondi2;

            differenza = Math.Abs(secondiTotali2 - secondiTotali1);
            #endregion

            #region Scrittura dell'orario formattato
            ore3 = differenza / 3600;
            differenza %= 3600;
            minuti3 = differenza / 60;
            differenza %= 60;
            secondi3 = differenza;

            Console.WriteLine($"La differenza tra i due orari è di {ore3} ore, {minuti3} minuti e {secondi3} secondi");
            #endregion

            Console.WriteLine("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
