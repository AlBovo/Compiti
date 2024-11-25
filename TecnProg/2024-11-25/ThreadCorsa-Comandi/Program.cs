/*********************************
* Alan Davide Bovo 4H 2024-11-04 *
*      Corsa con thread          *
*********************************/

using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace ThreadCorsa
{
    internal class Program
    {
        #region Creazione delle variabili globali
        static int[] posizioni = { 0, 0, 0 }; // posizioni di Andrea, Baldo e Carlo
        static List<int> velocita = new List<int>(); // velocita random dei vari partecipanti
        static List<Thread> threads = new List<Thread>(); // creazione della "pool" dei thread
        static List<int> flags = new List<int>();
        static int classifica = 0; // classifica della gara
        static Object _lock = new Object(); // lock per le risorse usate dai thread
        static Random random = new Random(); // random per generare le velocità dei corridori
        static string[] nomi = { "Andrea", "Baldo", "Carlo" };

        static string[][] persone = 
        {
            new string[] // rappresentazione di Andrea
            {
                "  []",
                " /▒▒\\",
                "  /\\"
            },
            new string[] // rappresentazione di Baldo
            {
                "  () ",
                " ┌▓▓┐",
                "  ┘└"
            },
            new string[] // rappresentazione di Carlo
            {
                "  <>",
                " /░░\\",
                "  ╝╚ "
            }
        };
        #endregion

        #region Metodo per stampare su console
        private static void Scrivi(int sinistra, int sopra, string testo)
        {
            lock (_lock) // lock della risorsa console
            {
                SetCursorPosition(sinistra, sopra); // imposto la posizione del cursore
                Write(testo); // scrivo il testo richiesto
            }
        }
        #endregion

        #region Metodo per inizializzare la corsa
        static void Pronti()
        {
            int column = 3, persona = 0;

            #region Stampa della rappresentazione di Andrea
            //Scrivi(posizioni[persona], column++, "x - Andrea");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);
            
            persona++;
            column++;
            #endregion

            #region Stampa della rappresentazione di Baldo
            //Scrivi(posizioni[persona], column++, "x - Baldo");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);

            persona++;
            column++;
            #endregion

            #region Stampa della rappresentazione di Carlo
            //Scrivi(posizioni[persona], column++, "x - Carlo");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);
            #endregion
        }
        #endregion

        static void Corri(Object pers)
        {
            int persona = (int)pers, column;

            do
            {
                #region Lettura della flag per eseguire il join
                if (flags[persona] != 0)
                {
                    threads[flags[persona]-1].Join(); // join del corridore della flag
                    flags[persona] = 0; // reset della flag
                }
                #endregion

                column = 4 * (persona + 1) - 1; // calcolo della colonna corretta
                posizioni[persona]++; // aumento della posizione per ogni ciclo

                #region Stampa della rappresentazione della persona i-esima
                for (int i = 0; i < 3; i++, column++)
                {
                    Scrivi(posizioni[persona], column, persone[persona][i]);
                    Thread.Sleep(velocita[persona]); // sleep per aggiungere un'animazione
                }
                #endregion
            } while (posizioni[persona] <= 114);

            /*
             * Non ho creato due lock in quanto potrebbe capitare il seguente caso
             * lock di f_1 per aggiornare la classifica (1)
             * lock di f_2 per aggiornare la classifica (2)
             * lock di f_1 per stampare la classifica (2 invece che 1)
             * lock di f_2 per stampare la classifica (2 come previsto)
             * in sostanza potrebbe sbagliare la classifica se due partecipanti
             * finiscono contemporaneamente la gara
             */
            Scrivi(0, 2 + 4 * persona, $"{++classifica} -");
        }

        #region Proprietà per ottenere lo stato di tutti i thread
        static bool IsAlive
        {
            get
            {
                bool result = false;
                foreach (Thread t in threads) // per ogni thread aggiorno il valore di result
                    result |= t.IsAlive;
                return result; // ritorno il risultato
            }
        }
        #endregion

        #region Funzione per stampa dello stato di un thread
        static void Stato(object e)
        {
            int i = (int)e;
            while (true)
            {
                Scrivi(4, 2 + i * 4, $"{nomi[i]} -> " + threads[i].ThreadState.ToString().PadRight(40)); // scrittura dello stato del thread
                Scrivi(50, 2 + i * 4, $"Is alive = {(threads[i].IsAlive ? "True" : "False")}"); // scrittura dello stato IsAlive del thread
                Thread.Sleep(5);
                if (threads[i].ThreadState == ThreadState.Stopped || threads[i].ThreadState == ThreadState.Aborted) // se non è più attivo lo stato viene chiuso
                    return;
            }
        }
        #endregion

        #region Metodo per la stampa del menu per la scelta del corridore
        static void Menu(string titolo)
        {
            Scrivi(0, 15, titolo.PadRight(40));         // stampa del titolo
            Scrivi(0, 17, "Andrea (A)".PadRight(20));   // stampa di Andrea paddato per pulire la console
            Scrivi(0, 18, "Baldo  (B)".PadRight(20));   // stampa di Baldo paddato per pulire la console
            Scrivi(0, 19, "Carlo  (C)".PadRight(20));   // stampa di Carlo paddato per pulire la console
            Scrivi(0, 20, "".PadRight(40)); // reset della riga al fondo
        }
        #endregion

        #region Metodo per la stampa del menu per la scelta dell'azione
        static char MenuAzioni(string titolo)
        {
            // stampa delle azioni e del titolo
            Scrivi(0, 15, titolo.PadRight(10));
            Scrivi(0, 17, "Sospendere (S)");
            Scrivi(0, 18, "Riprendere (R)");
            Scrivi(0, 19, "Abortire   (A)");
            Scrivi(0, 20, "Aspettare  (J)");

            char c = ReadKey(true).KeyChar; // lettura del carattere da restituire
            return char.ToUpper(c); // return del valore in maiuscolo
        }
        #endregion

        #region Metodo per la stampa del menu per la scelta del join
        static char MenuJoin(string titolo, char scelta)
        {
            int raw = 17;
            Scrivi(0, 15, titolo.PadRight(10));
            
            if (scelta != 'A') // se il thread di partenza non è andrea
                Scrivi(0, raw++, "Andrea (A)".PadRight(20));
            if (scelta != 'B') // se il thread di partenza non è baldo
                Scrivi(0, raw++, "Baldo  (B)".PadRight(20));
            if (scelta != 'C') // se il thread di partenza non è carlo
                Scrivi(0, raw++, "Carlo  (C)".PadRight(20));
            
            Scrivi(0, 19, "".PadRight(40)); // sovrascrittura della riga 19
            Scrivi(0, 20, "".PadRight(40)); // sovrascrittura della riga 20

            char c = ReadKey(true).KeyChar; // lettura del carattere da restituire
            return char.ToUpper(c); // return del valore in maiuscolo
        }
        #endregion

        static void Comando()
        {
            char persona = char.ToUpper(ReadKey(true).KeyChar); // lettura di un carattere
            Thread thread;
            try // ottenimento del thread del corridore scelto
            {
                thread = threads[persona - 'A'];
            }
            catch { return; }

            char scelta = MenuAzioni("AZIONE DA ESEGUIRE SU: " + thread.Name); // stampa del menu delle azioni

            switch (scelta)
            {
                case 'S':
                    lock(_lock)
                        if(thread.IsAlive)
                            thread.Suspend();
                    break;

                case 'R':
                    if (thread.ThreadState == ThreadState.Suspended)
                        thread.Resume();
                    break;

                case 'J':
                    char c = MenuJoin("AZIONE DI ASPETTARE DA ESEGUIRE SU:", persona);
                    if('A' <= c && c <= 'C') // persona fuori range
                        flags[persona - 'A'] = c - 'A' + 1; // imposto la flag per eseguire il join
                    break;

                case 'A':
                    lock (_lock)
                        if(thread.ThreadState != ThreadState.Suspended)
                            thread.Abort();
                    break;

                default:
                    Menu("CORSA TRA THREADS");
                    return;
            }

            Menu("CORSA TRA THREADS");
        }

        static void Main(string[] args)
        {
            Thread[] stato = new Thread[3]; // array per stampare lo stato dei corridori
            CursorVisible = false;

            Pronti(); // configurazione della gara
            Menu("CORSA TRA THREADS");

            for (int i = 0; i < 3; i++)
            {
                flags.Add(0);
                velocita.Add(random.Next(10, 100)); // generazione della velocita dell'i-esimo partecipante
                threads.Add(new Thread(Corri)); // aggiunta alla pool il nuovo thread
                threads[i].Name = nomi[i];
                threads[i].Start(i); // inizia la corsa dell'i-esimo partecipante
                stato[i] = new Thread(Stato);
                stato[i].Start(i);
            }

            #region Controllo se tutti i thread sono finiti
            while (IsAlive)
            {
                if(KeyAvailable) Comando();
            }

            Scrivi(0, 21, "Premi un tasto per terminare l'esecuzione del programma ..."); // stampa della stringa per terminare il programma
            ReadKey(true); // lettura di un carattere
            #endregion
        }
    }
}