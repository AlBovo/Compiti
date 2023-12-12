/**********************************
* Alan Davide Bovo 3H 2023-11-28 *
*       Gioco della tombola      *
*********************************/
using System;
using System.Linq;

namespace TombolaNatalizia
{
    internal class Program
    {
        #region Dichiarazione di constanti e variabili globali
        enum Scelta { Cinquina = 5, Decina = 10, Tombola = 15 };    // enumeratore delle possibili vincite
        const int DIMENSIONE_TABELLONE = 90, NUMERI_SCHEDINA = 15;  // costanti per dimensione del tabellone e delle schedine
        static int numeroPalline = DIMENSIONE_TABELLONE - 1;        // inizializzo il contatore di palline uscite
        static int[] urna = new int[DIMENSIONE_TABELLONE];          // array per la generazione dei numeri non usciti nel tabellone
        static bool[] tabellone = new bool[DIMENSIONE_TABELLONE];   // array contenente true se il numero alla posizione i è uscito altrimenti false
        static Random rand = new Random();                          // oggetto per la generazione randomica di interi
        #endregion

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
                else if (input < 0 || input >= DIMENSIONE_TABELLONE) // il numero letto deve essere nel range [0; DIMENSIONE_TABELLONE]
                {
                    Console.WriteLine("L'input inserito non rientra nel range del tabellone, riprova ...");
                    inputOK = false;
                }

            } while (!inputOK);
            return input - 1; // returno il numero come indice dell'array da usare
        }
        #endregion

        #region Funzione per stampare il tabellone
        static void StampaTabellone()
        {
            for (int i = 0; i < tabellone.Length; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tabellone[i+j])
                        Console.Write($"   {i + j + 1:00}"); // stampa di un numero uscito
                    else
                        Console.Write("   ##"); // stampa del numero non ancora uscito
                }
                Console.Write('\n'); // nuova riga
            }
            Console.Write('\n'); // nuova riga
        }
        #endregion

        #region Funzione per lettura dell'input non bloccante
        static char LeggiTasto()
        {
            if (!Console.KeyAvailable) // se nessun tasto è premuto
                return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true); // lettura del carattere
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
            while ((scelta = LeggiTasto().ToString().ToUpper()[0]) == '\0' || // ToString().ToUpper() per leggere pure le scelte con caratteri minuscoli
                (scelta != 'E' && scelta != 'C' && scelta != 'D' && 
                scelta != 'T' && scelta != 'S' && scelta != 'Q')) ; // leggo da console finchè non ricevo una scelta corretta
            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
        }
        #endregion

        #region Funzione per generare un numero nuovo e aggiornare il tabellone
        static int EstraiNumero()
        {
            if (numeroPalline < 0) return -1; // estratti tutti i numeri
            int posizioneCasuale = rand.Next(numeroPalline); // nuovo numero randomico
            int numeroCasuale = urna[posizioneCasuale]; // valore alla posizione del numero randomico
            urna[posizioneCasuale] = urna[numeroPalline--];
            return numeroCasuale;
        }
        #endregion

        #region Funzione per verificare una vincita
        static bool VerificaVincita(Scelta scelta)
        {
            switch (scelta)
            {
                case Scelta.Cinquina: // controllo per la cinquina
                    for (int i = 0; i < (int)scelta; i++)
                        if (!tabellone[LetturaIntero($"Inserisci il {i + 1} numero: ")])
                            return false; // cinquina non valida
                    return true; // cinquina valida poiché tutti i numeri sono validi

                case Scelta.Decina:
                    for (int i = 0; i < (int)scelta; i++)
                        if (!tabellone[LetturaIntero($"Inserisci il {i + 1} numero: ")])
                            return false; // decina non valida
                    return true; // decina valida poiché tutti i numeri sono validi

                case Scelta.Tombola:
                    for (int i = 0; i < (int)scelta; i++)
                        if (!tabellone[LetturaIntero($"Inserisci il {i + 1} numero: ")])
                            return false; // tombola non valida
                    return true; // tombola valida poiché tutti i numeri sono validi

                default:
                    return false;
            }
        }
        #endregion

        #region Funzione per inizializzare l'urna
        static void SetUpUrna()
        {
            for (int i = 0; i < DIMENSIONE_TABELLONE; i++)
                urna[i] = i; // inizializzo urna_i con i
        }
        #endregion

        #region Funzione per generare una schedina
        static int[,] GeneraSchedina()
        {
            int[,] usciti = new int[9, 3];  // matrice della schedina
            int[] numUsciti = new int[9];   // contatore di numeri usciti per ogni colonna
            bool[] valUsciti = new bool[DIMENSIONE_TABELLONE]; // booleani per uscito/non uscito

            for (int i = 0; i < NUMERI_SCHEDINA; i++)
            {
                bool continua = true;
                while (continua)
                {
                    int valore = rand.Next(90) + 1; // genero un numero randomico
                    if (valore != 90) // edge case poiché 90/10 != 8
                    {
                        if (numUsciti[valore / 10] == 3 || valUsciti[valore - 1])   // se ho già generato 3 numeri per il range di quella decina continuo
                            continue;
                        numUsciti[valore / 10]++;                   // aumento il contatore di uno
                        valUsciti[valore - 1] = true;
                        for (int e = 0; e < 3; e++)
                        {
                            if (usciti[valore / 10, e] == 0)        // se non è inizializzato allora non è uscito
                            {
                                usciti[valore / 10, e] = valore;    // setto il valore
                                continua = false;                   // imposto il ciclo while di non continuare
                                break;
                            }
                        }
                    }
                    else
                    {
                        // per i commenti guardare la sezione sopra
                        if (numUsciti[8] == 3)
                            continue;
                        numUsciti[8]++;
                        valUsciti[valore - 1] = true;
                        for (int e = 0; e < 3; e++)
                        {
                            if (usciti[8, e] == 0)
                            {
                                usciti[8, e] = valore;
                                continua = false;
                                break;
                            }
                        }
                    }
                }
            }

            #region Ordinamento delle righe della matrice in modo random
            for (int i = 0; i < 9; i++)
            {
                int[] nuoviUsciti =
                    Enumerable.Range(0, 3)
                    .Select(x => usciti[i, x])
                    .ToArray();             // rendo usciti[i] un array
                Array.Sort(nuoviUsciti);    // sorto l'array
                for (int e = 0; e < 3; e++)
                    usciti[i, e] = nuoviUsciti[e]; // aggiorno la matrice alla riga i

                for (int e = 0; e < 3 - numUsciti[i]; e++)
                {
                    int t;
                    do
                        t = i * 10 + rand.Next(10) + 1;
                    while (nuoviUsciti.Any(f => f == t)); // genero un numero finchè è presente nell'array
                    nuoviUsciti[e] = t;
                }
                Array.Sort(nuoviUsciti); // sorto di nuovo l'array
                for (int e = 0; e < 3; e++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (usciti[i, j] == nuoviUsciti[e])
                        {
                            usciti[i, e] = nuoviUsciti[e]; // aggiorno la posizione del valore
                            break;
                        }

                        if (j == 2) // il valore prima era uno 0 quindi lo risetto a 0
                            usciti[i, e] = 0;
                    }
                }
            }
            #endregion

            return usciti;
        }
        #endregion

        #region Funzione per stampare una schedina
        static string StampaSchedina(int[,] schedina)
        {
            string[] righe = new string[3];

            #region Calcolo delle linee con i numeri estratti
            for (int x = 0; x < 3; x++)
            {
                righe[x] = "║"; // primo carattere della riga
                for (int y = 0; y < 9; y++)
                {
                    if (schedina[y, x] == 0)    // valore non uscito
                        righe[x] += $" ## ";    // simbolo di default per valore non uscito :3
                    else
                        righe[x] += $" {schedina[y, x]:00} ";   // valore uscito
                    righe[x] += "║";
                }
                righe[x] += "\n"; // ultimo carattere della riga (vado a capo)
            }
            #endregion

            return // schedina formattata per bene
                "╔════╦════╦════╦════╦════╦════╦════╦════╦════╗\n" +
                righe[0] +
                "╠════╬════╬════╬════╬════╬════╬════╬════╬════╣\n" +
                righe[1] +
                "╠════╬════╬════╬════╬════╬════╬════╬════╬════╣\n" +
                righe[2] +
                "╚════╩════╩════╩════╩════╩════╩════╩════╩════╝";
        }
        #endregion

        static void Main(string[] args)
        {
            bool keep = true; // devo continuare a giocare
            string data = ""; // stringa da stampare prima del menu
            char scelta;      // scelta letta dalla console

            Console.Title = "Alan Davide Bovo 3H 2023-11-28"; // intestazione

            SetUpUrna(); // inizializzo l'urna
            while (keep)
            {
                Console.WriteLine("\t+-----------------------------------+");
                Console.WriteLine("\t| T O M B O L A   N A T A L I Z I A |");
                Console.WriteLine("\t+-----------------------------------+");

                StampaTabellone();
                if (data != "") // se ho dei dati da scrivere li stampo
                {
                    Console.WriteLine(data + "\n");
                    data = "";
                }
                if (numeroPalline < 0)
                    break;
                StampaMenu(out scelta); // stampo il menu della tombola
                Console.Write('\n');    // padding

                switch (scelta) // switch per la scelta
                {
                    case 'E':   // caso per estrarre un numero
                        int numero = EstraiNumero();
                        tabellone[numero] = true;
                        data = $"Il numero uscito è {numero + 1}"; // aggiorno i dati da stampare

                        if (numeroPalline < 0)  // se il numero di palline da estrarre è minore di 0 esco
                            data += "\nHai estratto tutti i numeri nel tabellone.";
                        break;

                    case 'C':   // controllo per la cinquina
                        if (VerificaVincita(Scelta.Cinquina))
                            data = "Complimenti hai fatto cinquina!";       // la cinquina è valida
                        else
                            data = "Non hai fatto cinquina, mi dispiace.";  // la cinquina non è valida
                        break;

                    case 'D':   // controllo per la decina
                        if (VerificaVincita(Scelta.Decina))
                            data = "Complimenti hai fatto decina!";         // la decina è valida
                        else
                            data = "Non hai fatto decina, mi dispiace.";    // la decina non è valida
                        break;

                    case 'T':   // controllo per la tombola
                        if (keep = VerificaVincita(Scelta.Tombola))
                            data = "Complimenti hai fatto tombola!";        // la tombola è valida
                        else
                            data = "Non hai fatto tombola, mi dispiace.";   // la tombola non è valida
                        break;

                    case 'S':   // generazione di una schedina
                        int[,] schedina = GeneraSchedina();
                        data = "La schedina generata è:\n\n" + StampaSchedina(schedina); // stampa della schedina
                        break;

                    case 'Q':   // uscita dal ciclo
                        keep = false;
                        break;
                }

                if (keep)   // se non sono uscito pulisco la console
                    Console.Clear();
            }

            #region Saluti e terminazione del programma
            Console.WriteLine("\nGrazie di aver giocato a Tombola, arrivederci!");
            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
            #endregion
        }
    }
}
