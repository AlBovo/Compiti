/*********************************
* Alan Davide Bovo 3H 2023-11-28 *
*        Tombola Natalizia       *
*********************************/
using System;
using System.Threading;

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
                else if (input < 1 || input > DIMENSIONE_TABELLONE) // input non valido
                {
                    Console.WriteLine("L'input inserito non rientra nel range del tabellone, riprova ...");
                    inputOK = false;
                }

            } while (!inputOK);
            return input;
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
                        Console.Write($"   {i + j + 1:00}"); // stampo il numero con due cifre formattato
                    else
                        Console.Write("   ##"); // stampo la posizione senza numero (non ancora uscito)
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

            ConsoleKeyInfo key = Console.ReadKey(true); // lettura del tasto premuto senza stamparlo a video
            return key.KeyChar;
        }
        #endregion

        #region Funzione per stampare il menu e leggere la scelta
        static void StampaMenu(out char scelta)
        {
            #region Stampa di tutte le scelte possibili
            Console.WriteLine(" Estrai un numero\t[E]");
            Console.WriteLine(" + Verifica Cinquina\t[C]");
            Console.WriteLine(" + Verifica Decina\t[D]");
            Console.WriteLine(" + Verifica Tombola\t[T]");
            Console.WriteLine(" Genera Schedina\t[S]");
            Console.WriteLine(" Termina Esecuzione\t[Q]\n");
            #endregion

            Console.Write("Inserisci la tua Scelta [ ]");
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop); // sposto il cursore indietro di due posizioni
            while ((scelta = LeggiTasto()) == '\0' || 
                (scelta != 'E' && scelta != 'C' && scelta != 'D' && 
                scelta != 'T' && scelta != 'S' && scelta != 'Q')) ; // leggo da console finchè non ricevo una scelta corretta
            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop); // resetto la posizione del cursore
            Console.Write('\n');
        }
        #endregion

        #region Funzione per generare un numero nuovo e aggiornare il tabellone
        static int GeneraNumero(bool[] tabellone)
        {
            Random rand = new Random();
            int valore;
            while (tabellone[valore = rand.Next(tabellone.Length)]) ; // genero numeri finchè non ne esce uno mai uscito
            tabellone[valore] = true; // aggiorno il valore
            return valore;
        }
        #endregion

        #region Funzione per verificare una vincita
        static bool VerificaVincita(bool[] tabellone, Scelta scelta)
        {
            int scelte, times;
            string type;

            #region Calcolo dei numeri da leggere e del tipo di vincita
            if (scelta == Scelta.Cinquina) 
            { 
                times = 5; 
                type = "cinquina"; 
            }
            else if (scelta == Scelta.Decina)
            {
                times = 10; 
                type = "decina"; 
            }
            else
            {
                times = 15; 
                type = "tombola"; 
            }
            #endregion

            for (int i = 0; i < times; i++)
            {
                scelte = LetturaIntero($"Inserisci il numero {i + 1}: "); // leggo il numero alla posizione i
                if (!tabellone[scelte - 1]) // non è ancora uscito
                {
                    Console.WriteLine("Il numero inserito non è ancora uscito");
                    Thread.Sleep(1000);
                    return false;
                }
            }
            Console.WriteLine($"Hai fatto {type} complimenti!");
            Thread.Sleep(1000);
            return false;
        }
        #endregion

        #region Funzione per generare una nuova schedina
        static void GeneraSchedina()
        {

        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-28");
            Console.Title = "Alan Davide Bovo 3H 2023-11-28";

            #region Dichiarazione delle variabili e inizializzazione
            bool[] tabellone = new bool[DIMENSIONE_TABELLONE];
            bool keep = true;
            string data = ""; // stringa da stampare prima del menu
            char scelta;
            int iterazioni = 0;
            #endregion

            do
            {
                Console.WriteLine("\t+---------------------------------+"); // ascii art del titolo
                Console.WriteLine("\t|T O M B O L A   N A T A L I Z I A|");
                Console.WriteLine("\t+---------------------------------+");

                StampaTabellone(tabellone); // stampa del tabellone della tombola
                if (data != "") // se è presente una stringa da stampare la stampo
                    Console.WriteLine(data + "\n");
                StampaMenu(out scelta); // stampa del menu e lettura della scelta

                switch (scelta)
                {
                    case 'E': // estrazione di un numero casuale
                        int numero = GeneraNumero(tabellone);
                        data = $"Il numero generato è {numero + 1}";
                        iterazioni++;
                        break;

                    case 'C': // verifica se è stata fatta una cinquina
                        VerificaVincita(tabellone, Scelta.Cinquina);
                        break;

                    case 'D': // verifica se è stata fatta una decina
                        VerificaVincita(tabellone, Scelta.Decina);
                        break;

                    case 'T': // verifica se è stata fatta una tombola
                        if (VerificaVincita(tabellone, Scelta.Tombola))
                            keep = false;
                        break;

                    case 'S': // generazione di una nuova schedina
                        // schedina
                        break;

                    case 'Q': // uscita dal programma
                        keep = false;
                        break;
                }

                if (iterazioni == DIMENSIONE_TABELLONE) // se i numeri sono finiti
                {
                    Console.WriteLine("Hai esaurito tutti i numeri, non puoi più estrarre numeri ...");
                    Thread.Sleep(1000);
                }

                Console.Clear();
            } while (keep && iterazioni != DIMENSIONE_TABELLONE);

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ..."); // terminazione del programma
            Console.ReadKey();
        }
    }
}
