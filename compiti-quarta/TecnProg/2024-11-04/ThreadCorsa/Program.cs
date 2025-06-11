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
        static int[] velocita = new int[3]; // velocita random dei vari partecipanti
        static int classifica = 0; // classifica della gara
        static Object _lock = new Object(); // lock per le risorse usate dai thread
        static Random random = new Random(); // random per generare le velocità dei corridori

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

        private static void Scrivi(int sinistra, int sopra, string testo)
        {
            lock (_lock)
            {
                SetCursorPosition(sinistra, sopra);
                Write(testo);
            }
        }

        static void Pronti()
        {
            int column = 2, persona = 0;

            #region Stampa della rappresentazione di Andrea
            Scrivi(posizioni[persona], column++, "x - Andrea");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);
            
            persona++;
            #endregion

            #region Stampa della rappresentazione di Baldo
            Scrivi(posizioni[persona], column++, "x - Baldo");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);


            persona++;
            #endregion

            #region Stampa della rappresentazione di Carlo
            Scrivi(posizioni[persona], column++, "x - Carlo");

            for (int i = 0; i < 3; i++, column++)
                Scrivi(posizioni[persona], column, persone[persona][i]);
            #endregion
        }

        static void Corri(Object pers)
        {
            int persona = (int)pers, column;

            do
            {
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
            Scrivi(0, 2 + 4 * persona, $"{++classifica}");
        }

        static void Main(string[] args)
        {
            CursorVisible = false;
            List<Thread> threads = new List<Thread>(); // creazione della "pool" dei thread

            Pronti(); // configurazione della gara

            for (int i = 0; i < 3; i++)
            {
                velocita[i] = random.Next(10, 100); // generazione della velocita dell'i-esimo partecipante
                threads.Add(new Thread(Corri)); // aggiunta alla pool il nuovo thread
                threads[i].Start(i); // inizia la corsa dell'i-esimo partecipante
            }

            //SetCursorPosition(0, 15);
            //Write("Premi un tasto per terminare l'esecuzione del programma ...");
            //ReadKey();
        }
    }
}