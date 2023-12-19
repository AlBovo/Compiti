/**********************************
* Alan Davide Bovo 3H 2023-12-19 *
*      Gioco del Mastermind      *
*********************************/
using System;

namespace Mastermind
{
    internal class Program
    {
        #region Dichiarazione di constanti e variabili globali
        const int NUMERO_CIFRE = 4, NUMERO_VALORI = 10;                     // costanti globali contenenti le dimensioni decise
        static int numeroPalline = NUMERO_VALORI - 1, NUMERO_TENTATIVI;     // puntatore all'ultima cifra dell'urna
        static int[] urna = new int[NUMERO_VALORI];                         // array contenente l'urna da cui vengono estratti i numeri
        static Random rand = new Random();                                  // oggetto utilizzato per la generazione randomica di numeri interi
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
        
        #region Funzione per inizializzare l'urna
        static void SetUpUrna()
        {
            for (int i = 0; i < NUMERO_VALORI; i++)
                urna[i] = i; // inizializzo urna_i con i
        }
        #endregion

        #region Funzione per leggere un codice di un tentativo
        static int[] LeggiCodice()
        {
            int[] codice = new int[4]; // array del nuovo codice
            bool inputOK;
            do
            {
                inputOK = true;
                Console.Write("Inserisci il tentativo corrente nel formato XXXX: "); // stampo il messaggio per l'utente
                string input = Console.ReadLine(); // leggo l'input dell'utente
                if(input.Length != NUMERO_CIFRE) // se la lunghezza è diversa sicuramente non ha un formato corretto
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                    inputOK = false;
                    continue;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] < '0' || input[i] > '9') // il carattere non è una cifra
                    {
                        Console.WriteLine("L'input non contiene solo numeri interi, riprova ...");
                        inputOK = false;
                        break;
                    }
                    else
                        codice[i] = input[i] - '0'; // calcolo il numero come int
                }
            } while (!inputOK);
            return codice;
        }
        #endregion

        #region Funzione per leggere un tentativo e calcolare il numero di elementi corretti
        static bool ControllaTentativo(int[] codiceGenerato)
        {
            int[] codice = new int[codiceGenerato.Length], tentativo = LeggiCodice(); // array conteneti la copia del codice e il tentativo corrente
            Array.Copy(codiceGenerato, codice, codiceGenerato.Length); // copia del codice segreto
            int posizioniCorrette = 0, valoriCorretti = 0; // numero di valori alla posizione corretta e numero di valori alla posizione errata

            #region Prima passata per cercare i valori alla posizione corretta
            for (int i = 0; i < codice.Length; i++)
            {
                if (codice[i] == tentativo[i]) // il valore è alla posizione corretta
                {
                    posizioniCorrette++; // aumento il numero 
                    codice[i] = tentativo[i] = -1; // imposto come valori non più utilizzabili entrambi codice_i e tentativo_i
                }
            }
            #endregion

            #region Seconda passata per cercare i valori presenti in posizione errata
            for (int i = 0; i < tentativo.Length && posizioniCorrette < codice.Length; i++) // la seconda condizione serve ad evitare
            {                                                                               // il for se il tentativo è corretto
                if (tentativo[i] == -1) continue; // il valore è stato impostato come già verificato
                for (int e = 0; e < codice.Length; e++)
                {
                    if (codice[e] == tentativo[i]) // il valore è presente ma alla posizione errata
                    {
                        valoriCorretti++;
                        tentativo[i] = codice[e] = -1; // imposto come valori non più utilizzabili entrambi codice_i e tentativo_i
                        break;
                    }
                }
            }
            #endregion

            if(posizioniCorrette == codice.Length) // tutti i numeri sono alla posizione corretta
            {
                Console.WriteLine("Complimenti hai indovinato il codice segreto!");
                return true; // hai indovinato, non continuare
            }
            else
            {
                Console.WriteLine($"Hai indovinato correttamente {posizioniCorrette} numeri e ne hai messi {valoriCorretti} in posizioni errate.");
                return false; // non hai indovinato, continua
            }
        }
        #endregion

        #region Funzione per la lettura di una difficoltà
        static int LeggiTentativi()
        {
            while (true)
            {
                Console.WriteLine("\nScegli una difficoltà");
                Console.WriteLine("[A] Difficile (1 tentativo)");
                Console.WriteLine("[B] Medio     (10 tentativi)");
                Console.WriteLine("[C] Facile    (20 tentativi)");
                Console.Write("\nInserisci la tua scelta: ");

                char input = Console.ReadLine().ToUpper()[0];
                switch (input)
                {
                    case 'A': // difficile
                        return 1;
                    case 'B': // medio
                        return 10;
                    case 'C': // facile
                        return 20;
                    default:
                        Console.WriteLine("L'input inserito non è valido");
                        continue;
                }
            }
        }
        #endregion

        static void Main()
        {
            #region Inizializzazione delle variabili di gioco
            SetUpUrna(); // inizializzo l'urna
            #region Ascii Art per il titolo del gioco
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Yellow };
            Console.ForegroundColor = colors[rand.Next(0, colors.Length)];
            Console.WriteLine(@" __       __                        __                          __       __  __                  __ " + "\n" +
                              @"/  \     /  |                      /  |                        /  \     /  |/  |                /  |" + "\n" +
                              @"$$  \   /$$ |  ______    _______  _$$ |_     ______    ______  $$  \   /$$ |$$/  _______    ____$$ |" + "\n" +
                              @"$$$  \ /$$$ | /      \  /       |/ $$   |   /      \  /      \ $$$  \ /$$$ |/  |/       \  /    $$ |" + "\n" +
                              @"$$$$  /$$$$ | $$$$$$  |/$$$$$$$/ $$$$$$/   /$$$$$$  |/$$$$$$  |$$$$  /$$$$ |$$ |$$$$$$$  |/$$$$$$$ |" + "\n" +
                              @"$$ $$ $$/$$ | /    $$ |$$      \   $$ | __ $$    $$ |$$ |  $$/ $$ $$ $$/$$ |$$ |$$ |  $$ |$$ |  $$ |" + "\n" +
                              @"$$ |$$$/ $$ |/$$$$$$$ | $$$$$$  |  $$ |/  |$$$$$$$$/ $$ |      $$ |$$$/ $$ |$$ |$$ |  $$ |$$ \__$$ |" + "\n" +
                              @"$$ | $/  $$ |$$    $$ |/     $$/   $$  $$/ $$       |$$ |      $$ | $/  $$ |$$ |$$ |  $$ |$$    $$ |" + "\n" +
                              @"$$/      $$/  $$$$$$$/ $$$$$$$/     $$$$/   $$$$$$$/ $$/       $$/      $$/ $$/ $$/   $$/  $$$$$$$ |" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            Console.Title = "Alan Davide Bovo 3H 2023-12-19"; // intestazione del programma
            Console.WriteLine($"Benvenuto a Mastermind, il tuo obiettivo è quello di indovinare il codice segreto composto da {NUMERO_CIFRE} cifre decimali"); // saluto l'utente
            int[] codiceGenerato = new int[4]; // creo l'array con i valori del codice generato
            for (int i = 0; i < codiceGenerato.Length; i++)
                codiceGenerato[i] = EstraiNumero(); // calcolo il numero alla posizione i del codice segreto
            NUMERO_TENTATIVI = LeggiTentativi(); // chiedo all'utente il numero di tentativi in base alla difficoltà scelta
            #endregion

            bool continua = false; // continuo finchè non finisco i tentativi o indovino il codice
            for (int i = 0; i < NUMERO_TENTATIVI && !continua; i++)
            {
                Console.WriteLine($"\nTentativo {i + 1} su {NUMERO_TENTATIVI}");
                continua = ControllaTentativo(codiceGenerato); // eseguo il controllo del tentativo
            }

            if (!continua) // l'utente non ha indovinato il codice
            {
                Console.Write($"Il codice segreto era: "); // stampo il codice segreto
                foreach (int i in codiceGenerato) Console.Write($"{i} "); // stampo il valore del foreach
                Console.Write("\n"); // carattere newline per formattazione
            }

            Console.Write("\nPremi un tasto per terminare l'esecuzione del programma ... ");
            Console.ReadKey();
        }
    }
}
