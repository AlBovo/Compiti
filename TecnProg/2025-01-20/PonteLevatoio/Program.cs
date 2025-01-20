using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace PonteLevatoio
{
    internal class Program
    {
        private static object _lock = new object();
        private static int MIN_X = 0, MAX_X = 100;
        private static Random random = new Random();
        private static Ponte ponte = new Ponte();
        private static List<Auto> parcheggio = new List<Auto>();

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
            private int x, y;

            public Auto(int id)
            {
                nome = $"Auto {id}";
                x = random.Next(MIN_X, MAX_X);
            }

            public void Muovi()
            {

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
                        Scrivi(50, i, new string('▓', 20), ConsoleColor.Cyan);
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
                            parcheggio.Add(new Auto(ids++));
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
            } while (scelta != 'U');
        }
    }
}
