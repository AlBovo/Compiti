using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace PonteLevatoio
{
    internal class Program
    {
        private static object _lock = new object();
        private static int MIN_Y = 10, MAX_Y = 17;
        private static Random random = new Random();
        private static Ponte ponte = new Ponte();
        private static Queue<Auto> parcheggio = new Queue<Auto>();
        private static Thread[] threads = new Thread[4];

        #region Metodo per scrivere a una posizione con il default color
        /// <summary>
        /// Metodo per scrivere a una posizione con il default color
        /// </summary>
        /// <param name="sinistra">Distanza dal margine sinistro</param>
        /// <param name="sopra">Distanza dal margine superiore</param>
        /// <param name="testo">Stringa da stampare a video</param>
        private static void Scrivi(int sinistra, int sopra, string testo)
        {
            lock (_lock) // lock della risorsa console
            {
                SetCursorPosition(sinistra, sopra); // imposto la posizione del cursore
                Write(testo); // scrivo il testo richiesto
            }
        }
        #endregion

        #region Metodo per scrivere a una posizione con un colore custom
        /// <summary>
        /// Metodo per scrivere a una posizione con un colore custom
        /// </summary>
        /// <param name="sinistra">Distanza dal margine sinistro</param>
        /// <param name="sopra">Distanza dal margine superiore</param>
        /// <param name="testo">Stringa da stampare a video</param>
        /// <param name="color">Colore da assegnare durante la stampa</param>
        private static void Scrivi(int sinistra, int sopra, string testo, ConsoleColor color)
        {
            lock (_lock) // lock della risorsa console
            {
                var colore = ForegroundColor;

                SetCursorPosition(sinistra, sopra); // imposto la posizione del cursore
                ForegroundColor = color; // aggiorno il colore
                Write(testo); // scrivo il testo richiesto
                ForegroundColor = colore; // resetto il colore a quello precedente
            }
        }
        #endregion

        private class Auto
        {
            public string nome { get; private set; }
            private int x, y, vel;

            public Auto(int id)
            {
                nome = $"auto{id}";
                x = 5;
                y = random.Next(MIN_Y+1, MAX_Y-1);
                vel = random.Next(100, 1000);
            }

            public void Muovi()
            {
                do
                {
                    Thread.Sleep(vel);
                    Scrivi(x, y, " " + nome);
                } while (++x < 115);

                Scrivi(x, y, new string(' ', nome.Length));
            }
        }

        private class Ponte
        {
            public bool aperto { get; private set; }

            public void GestisciPonte(bool aperto)
            {
                if (this.aperto != aperto)
                {
                    this.aperto = aperto;
                    StampaPonte();
                }
            }

            public void StampaPonte()
            {
                for (int i = 10; i <= 17; i++)
                {
                    if (!aperto)
                        Scrivi(47, i, new string((i == 10 || i == 17) ? '▂' : ' ', 26), ConsoleColor.Yellow);
                    else
                        Scrivi(47, i, "   " + new string('▓', 20) + "   ", ConsoleColor.Cyan);
                }
            }
        }

        #region Metodo per la stampa del menu per la scelta dell'azione
        /// <summary>
        /// Metodo per la stampa del menu per la scelta dell'azione
        /// </summary>
        /// <returns>Scelta dell'utente</returns>
        private static char MenuAzioni(bool leggi)
        {
            // stampa delle azioni e del titolo
            Scrivi(20, 1, "Auto     (A)", ConsoleColor.Green);
            Scrivi(20, 2, "Open     (O)", ConsoleColor.Green);
            Scrivi(20, 3, "Close    (C)", ConsoleColor.Green);
            Scrivi(20, 4, "Uscita   (U)", ConsoleColor.Green);

            if (leggi)
                return (char)0;

            char c = ReadKey(true).KeyChar; // lettura del carattere da restituire
            return char.ToUpper(c); // return del valore in maiuscolo
        }
        #endregion


        private static void Stampa()
        {
            for(int i=0; i<29; i++)
            {
                Scrivi(0, i, new string(' ', 45));
                if (i == 10)
                {
                    ponte.StampaPonte();
                    i += 7;
                }
                else
                {
                    Scrivi(50, i, new string('▓', 20), ConsoleColor.Cyan);
                }
            }
            MenuAzioni(true);
        }

        private static void StampaParcheggio()
        {
            int i = 0;
            foreach (Auto auto in parcheggio)
                Scrivi(5, 5 + i++, auto.nome);
        }

        static void Main(string[] args)
        {
            Title = "Alan Davide Bovo 4H 2025-01-20";
            OutputEncoding = Encoding.UTF8;
            CursorVisible = false;

            Stampa();
            char scelta = ' ';
            int ids = 0;

            do
            {
                if (KeyAvailable)
                {
                    scelta = MenuAzioni(false);
                    switch (scelta)
                    {
                        case 'A':
                            if (parcheggio.Count == 10)
                                break;
                            parcheggio.Enqueue(new Auto(ids++));
                            break;

                        case 'O':
                            ponte.GestisciPonte(true);
                            break;

                        case 'C':
                            ponte.GestisciPonte(false);
                            break;

                        default: // U e tutti gli altri char
                            break;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (parcheggio.Count == 0)
                        break;
                    if (threads[i] != null && threads[i].IsAlive)
                        continue;

                    Auto auto = parcheggio.Dequeue();
                    Thread thread = new Thread(auto.Muovi);

                    if (threads[i] != null && !threads[i].IsAlive)
                        threads[i] = thread;
                    if (threads[i] == null)
                        threads[i] = thread;

                    if (!threads[i].IsAlive)
                        threads[i].Start();
                }

                StampaParcheggio();
            } while (scelta != 'U');

            foreach (Thread thread in threads)
                thread.Abort();
        }
    }
}
