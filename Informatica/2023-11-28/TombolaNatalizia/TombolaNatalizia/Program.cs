using System;

namespace TombolaNatalizia
{
    internal class Program
    {
        enum Scelta { Cinquina = 0, Decina = 1, Tombola = 2 };
        const int DIMENSIONE_TABELLONE = 90;

        #region Funzione per la lettura di un intero
        static int LetturaIntero(string message)
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
                else if (input < 0 || input > DIMENSIONE_TABELLONE - 1)
                {
                    Console.WriteLine("L'input inserito non rientra nel range del tabellone, riprova ...");
                    inputOK = false;
                }

            } while (!inputOK);
            return input + 1;
        }
        #endregion

        #region Funzione per stampare il tabellone
        static void StampaTabellone(bool[] tabellone)
        {
            for (int i = 0; i < tabellone.Length; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tabellone[i+j])
                        Console.Write($"   {i + j + 1:00}");
                    else
                        Console.Write("   ##");
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }
        #endregion

        #region Funzione per lettura dell'input non bloccante
        static char LeggiTasto()
        {
            if (!Console.KeyAvailable)
                return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.KeyChar;
        }
        #endregion

        #region Funzione per stampare il menu e leggere la scelta
        static void StampaMenu(out char scelta)
        {
            Console.WriteLine(" Estrai un numero\t[E]");
            Console.WriteLine(" + Verifica Cinquina\t[C]");
            Console.WriteLine(" + Verifica Decina\t[D]");
            Console.WriteLine(" + Verifica Tombola\t[T]");
            Console.WriteLine(" Genera Schedina\t[S]");
            Console.WriteLine(" Termina Esecuzione\t[Q]\n");

            Console.Write("Inserisci la tua Scelta [ ]");
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            while ((scelta = LeggiTasto()) == '\0' || 
                (scelta != 'E' && scelta != 'C' && scelta != 'D' && 
                scelta != 'T' && scelta != 'S' && scelta != 'Q')) ; // leggo da console finchè non ricevo una scelta corretta
            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
        }
        #endregion

        #region Funzione per generare un numero nuovo e aggiornare il tabellone
        static int GeneraNumero(bool[] tabellone)
        {
            Random rand = new Random();
            int valore;
            while (tabellone[valore = rand.Next(tabellone.Length)]) ;
            tabellone[valore] = true;
            return valore;
        }
        #endregion

        #region Funzione per verificare una vincita
        static bool VerificaVincita(bool[] tabellone, Scelta scelta)
        {
            int[] scelte;
            switch (scelta)
            {
                case Scelta.Cinquina:
                    scelte = new int[5];
                    break;

                case Scelta.Decina:
                    scelte = new int[10];
                    break;

                case Scelta.Tombola:
                    scelte = new int[15];
                    break;
            }
            return false;
        }
        #endregion

        static void Main(string[] args)
        {
            bool[] tabellone = new bool[90];
            bool keep = true;
            string data = ""; // stringa da stampare prima del menu
            char scelta;

            do
            {
                Console.WriteLine("\t+---------------------------------+");
                Console.WriteLine("\t|T O M B O L A   N A T A L I Z I A|");
                Console.WriteLine("\t+---------------------------------+");

                StampaTabellone(tabellone);
                if (data != "")
                    Console.WriteLine(data + "\n");
                StampaMenu(out scelta);

                switch (scelta)
                {
                    case 'E':
                        int numero = GeneraNumero(tabellone);
                        data = $"Il numero generato è {numero + 1}";
                        break;

                    case 'C':
                        VerificaVincita(tabellone, Scelta.Cinquina);
                        break;

                    case 'D':
                        VerificaVincita(tabellone, Scelta.Decina);
                        break;

                    case 'T':
                        VerificaVincita(tabellone, Scelta.Tombola);
                        break;

                    case 'S':
                        // schedina
                        break;

                    case 'Q':
                        keep = false;
                        break;
                }
                Console.Clear();
                // TODO: Controllare che tutto il tabellone sia uscito
            } while (keep);

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
