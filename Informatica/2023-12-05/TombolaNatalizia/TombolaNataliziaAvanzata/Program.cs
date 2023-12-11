/**********************************
* Alan Davide Bovo 3H 2023-11-28 *
*       Gioco della tombola      *
*********************************/
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

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
                    if (tabellone[i + j])
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
        static int GeneraNumero()
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
            int[,] usciti = new int[9, 3];
            int[] numUsciti = new int[9];
            bool[] valUsciti = new bool[DIMENSIONE_TABELLONE];

            //for (int i = 0; i < 9; i++)
            //    numUsciti[i] = 0;
            // Il valore default di una variabile inizializzata è 0

            for (int i = 0; i < NUMERI_SCHEDINA; i++)
            {
                bool continua = true;
                while (continua)
                {
                    int valore = rand.Next(90) + 1; // genero un numero randomico
                    if (valore == 90) // edge case poiché 90/10 != 8
                    {
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
                    else
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
                }
            }

            #region Ordinamento delle righe della matrice
            for (int i = 0; i < 9; i++)
            {
                int swap;

                if (usciti[i, 0] > usciti[i, 1])
                {
                    swap = usciti[i, 0];
                    usciti[i, 0] = usciti[i, 1];
                    usciti[i, 1] = swap;
                }

                if (usciti[i, 1] > usciti[i, 2])
                {
                    swap = usciti[i, 1];
                    usciti[i, 1] = usciti[i, 2];
                    usciti[i, 2] = swap;

                    if (usciti[i, 0] > usciti[i, 1])
                    {
                        swap = usciti[i, 0];
                        usciti[i, 0] = usciti[i, 1];
                        usciti[i, 1] = swap;
                    }
                }

                if (usciti[i, 0] == 0 && rand.Next(4) != 1) // shifto in su la colonna
                {
                    if (usciti[i, 1] == 0 && rand.Next(2) == 1) // unico valore in mezzo alla colonna
                    {
                        usciti[i, 0] = usciti[i, 2];
                        usciti[i, 2] = 0;
                    }
                    else if (rand.Next(2) == 1) // un valore su, vuoto in mezzo, un valore sotto
                    {
                        usciti[i, 0] = usciti[i, 1];
                        usciti[i, 1] = 0;
                    }
                    else // valore su e in mezzo
                    {
                        usciti[i, 0] = usciti[i, 1];
                        usciti[i, 1] = usciti[i, 2];
                        usciti[i, 2] = 0;
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
            string[] righe = new string[4];

            for (int x = 0; x < 3; x++)
            {
                righe[x] = "|";
                for (int y = 0; y < 9; y++)
                {
                    if (schedina[y, x] == 0)    // valore non uscito
                        righe[x] += "  ##";     // simbolo di default per valore non uscito
                    else
                        righe[x] += $"  {schedina[y, x]:00}";   // valore uscito
                }
            }


            return "+--------------------------------------+\n" +
                                    string.Join("  |\n", righe) +
                   "+--------------------------------------+";  // formattazione della stringa
        }
        #endregion

        #region Funzione per salvare una schedina su file
        static void SalvaSchedina(int[,] schedina, int ID)
        {
            string path = $"schedina{ID}.txt";
            string righe = J

            byte[] plaintext = Encoding.UTF8.GetBytes(righe);

            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);

                File.WriteAllBytes(path, encryptedBytes);
            }
        }
        #endregion

        #region Funzione per caricare una schedina da file
        static void SalvaSchedina(int[,] schedina, int ID)
        {
            string path = $"schedina{ID}.txt";
            string righe = StampaSchedina(schedina);

            byte[] plaintext = Encoding.UTF8.GetBytes(righe);

            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);

                File.WriteAllBytes(path, encryptedBytes);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            bool keep = true;
            string data = ""; // stringa da stampare prima del menu
            char scelta;
            int id = 0;

            Console.Title = "Alan Davide Bovo 3H 2023-11-28";

            SetUpUrna();
            while (keep)
            {
                Console.WriteLine("\t+-----------------------------------+");
                Console.WriteLine("\t| T O M B O L A   N A T A L I Z I A |");
                Console.WriteLine("\t+-----------------------------------+");

                StampaTabellone();
                if (data != "")
                {
                    Console.WriteLine(data + "\n");
                    data = "";
                }
                if (numeroPalline < 0)
                    break;
                StampaMenu(out scelta);
                Console.Write('\n');

                switch (scelta)
                {
                    case 'E':
                        int numero = GeneraNumero();
                        tabellone[numero] = true;
                        data = $"Il numero uscito è {numero + 1}";

                        if (numeroPalline < 0)
                            data += "\nHai estratto tutti i numeri nel tabellone.";
                        break;

                    case 'C':
                        if (VerificaVincita(Scelta.Cinquina))
                            data = "Complimenti hai fatto cinquina!";
                        else
                            data = "Non hai fatto cinquina, mi dispiace.";
                        break;

                    case 'D':
                        if (VerificaVincita(Scelta.Decina))
                            data = "Complimenti hai fatto decina!";
                        else
                            data = "Non hai fatto decina, mi dispiace.";
                        break;

                    case 'T':
                        if (keep = VerificaVincita(Scelta.Tombola))
                            data = "Complimenti hai fatto tombola!";
                        else
                            data = "Non hai fatto tombola, mi dispiace.";
                        break;

                    case 'S':
                        int[,] schedina = GeneraSchedina();
                        data = "La schedina generata è:\n\n" + StampaSchedina(schedina);
                        SalvaSchedina(schedina, id++);
                        break;

                    case 'Q':
                        keep = false;
                        break;
                }

                if (keep)
                    Console.Clear();
            }

            Console.WriteLine("Grazie di aver giocato a Tombola, arrivederci!");
            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
