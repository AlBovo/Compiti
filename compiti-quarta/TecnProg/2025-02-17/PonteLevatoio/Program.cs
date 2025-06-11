using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace PonteLevatoio
{
    internal class Program
    {
        #region Variabili globali
        private static readonly object _lock = new object(); // Lock per evitare conflitti di accesso alla console
        private const int MIN_Y = 12, MAX_Y = 16, MAX_AUTO = 4; // Dati per la gestione delle posizioni delle auto
        private static readonly Random random = new Random(); // Generatore di numeri casuali per la velocità delle auto
        private static readonly Ponte ponte = new Ponte(); // Istanza del ponte
        private static readonly Queue<Auto> parcheggio = new Queue<Auto>(); // Coda delle auto in attesa di attraversare
        private static readonly HashSet<Auto> attive = new HashSet<Auto>(); // Auto che stanno attraversando il ponte
        private static readonly SemaphoreSlim _sem = new SemaphoreSlim(MAX_AUTO); // Limite di auto che possono attraversare contemporaneamente
        private static readonly HashSet<Thread> autos = new HashSet<Thread>(); // Lista di thread per le auto
        #endregion

        #region Metodo per scrivere a una posizione con il default color
        /// <summary>
        /// Metodo per scrivere un testo in una posizione specificata nella console con il colore predefinito.
        /// </summary>
        /// <param name="sinistra">Distanza dal margine sinistro</param>
        /// <param name="sopra">Distanza dal margine superiore</param>
        /// <param name="testo">Testo da stampare a video</param>
        private static void Scrivi(int sinistra, int sopra, string testo)
        {
            lock (_lock) // Lock della risorsa console
            {
                SetCursorPosition(sinistra, sopra); // Imposto la posizione del cursore
                Write(testo); // Scrivo il testo nella console
            }
        }
        #endregion

        #region Metodo per scrivere a una posizione con un colore custom
        /// <summary>
        /// Metodo per scrivere un testo in una posizione specificata con un colore personalizzato.
        /// </summary>
        /// <param name="sinistra">Distanza dal margine sinistro</param>
        /// <param name="sopra">Distanza dal margine superiore</param>
        /// <param name="testo">Testo da stampare a video</param>
        /// <param name="color">Colore del testo da assegnare</param>
        private static void Scrivi(int sinistra, int sopra, string testo, ConsoleColor color)
        {
            lock (_lock) // Lock della risorsa console
            {
                var colore = ForegroundColor; // Salvo il colore attuale

                SetCursorPosition(sinistra, sopra); // Imposto la posizione del cursore
                ForegroundColor = color; // Modifico il colore
                Write(testo); // Scrivo il testo
                ForegroundColor = colore; // Ripristino il colore precedente
            }
        }
        #endregion

        #region Classe Auto
        /// <summary>
        /// Rappresenta un'auto che si muove lungo la strada verso il ponte.
        /// </summary>
        private class Auto
        {
            public string nome { get; private set; } // Nome dell'auto (auto1, auto2, ...)
            public int x { get; private set; } // Posizione orizzontale dell'auto
            public int y { get; private set; } // Posizione verticale dell'auto
            private int vel; // Velocità dell'auto

            /// <summary>
            /// Costruttore dell'auto, inizializza posizione e velocità
            /// </summary>
            /// <param name="id">Identificativo della macchina</param>
            public Auto(int id)
            {
                nome = $"auto{id}"; // Assegna il nome in base all'ID
                x = 5; // Posizione iniziale dell'auto (a sinistra)
                y = MIN_Y + (id % 4); // Posizione verticale, distribuite in base all'ID
                vel = random.Next(50, 100); // Velocità casuale tra 50 e 100
            }

            /// <summary>
            /// Metodo per far muovere l'auto
            /// </summary>
            public void Muovi()
            {
                _sem.Wait(); // Aspetta che ci sia spazio per attraversare
                attive.Add(this); // Aggiunge l'auto tra quelle attive
                parcheggio.Dequeue(); // Rimuove l'auto dal parcheggio
                StampaParcheggio(); // Stampa lo stato del parcheggio
                do
                {
                    // Se il ponte non è aperto e l'auto è alla posizione 50, aspetta
                    while (!ponte.aperto && x == 50 - nome.Length) Thread.Sleep(10);

                    Thread.Sleep(vel); // La velocità dell'auto è determinata dal parametro vel
                    Scrivi(x, y, " " + nome); // Stampa l'auto nella posizione attuale
                } while (++x < 115); // L'auto si muove fino a x = 115

                // Cancella l'auto dalla posizione finale
                Scrivi(x, y, new string(' ', nome.Length));
                _sem.Release(); // Rilascia lo spazio per una nuova auto
                attive.Remove(this); // Rimuove l'auto dalla lista delle auto attive
                autos.Remove(Thread.CurrentThread); // Rimuove il thread dell'auto
            }
        }
        #endregion

        #region Classe Ponte
        /// <summary>
        /// Rappresenta il ponte levatoio che può essere aperto o chiuso.
        /// </summary>
        private class Ponte
        {
            public bool aperto { get; private set; } // Indica se il ponte è aperto

            /// <summary>
            /// Costruttore, inizialmente il ponte è aperto
            /// </summary>
            public Ponte() { aperto = true; }

            /// <summary>
            /// Gestisce l'apertura e la chiusura del ponte
            /// </summary>
            /// <param name="aperto">Nuovo stato del ponte</param>
            public void GestisciPonte(bool aperto)
            {
                if (!aperto)
                {
                    bool cont = false;
                    // Se ci sono auto attive tra la posizione 45 e 70, non chiudere il ponte
                    foreach (Auto auto in attive)
                        cont |= 45 < auto.x && auto.x < 70;
                    if (cont) return; // Se ci sono auto tra queste posizioni, non cambia lo stato
                }

                if (this.aperto != aperto)
                {
                    this.aperto = aperto;
                    StampaPonte(); // Ristampa lo stato del ponte
                }
            }

            /// <summary>
            /// Stampa il ponte (con apertura o chiusura)
            /// </summary>
            public void StampaPonte()
            {
                for (int i = 10; i <= 17; i++)
                {
                    if (aperto)
                        Scrivi(47, i, new string((i == 10 || i == 17) ? '▂' : ' ', 26), ConsoleColor.Yellow);
                    else
                        Scrivi(47, i, "   " + new string('▓', 20) + "   ", ConsoleColor.Cyan);
                }
            }
        }
        #endregion

        #region Metodo per la stampa del menu delle azioni
        /// <summary>
        /// Stampa il menu delle azioni e restituisce la scelta dell'utente.
        /// </summary>
        /// <returns>La scelta dell'utente (A, O, C, U)</returns>
        private static char MenuAzioni(bool leggi)
        {
            // Stampa le opzioni di azione nel menu
            Scrivi(20, 1, "Auto     (A)", ConsoleColor.Green);
            Scrivi(20, 2, "Open     (O)", ConsoleColor.Green);
            Scrivi(20, 3, "Close    (C)", ConsoleColor.Green);
            Scrivi(20, 4, "Uscita   (U)", ConsoleColor.Green);

            if (leggi)
                return (char)0; // Se leggi è vero, non fare nulla

            char c = ReadKey(true).KeyChar; // Legge il tasto premuto dall'utente
            return char.ToUpper(c); // Restituisce il tasto in maiuscolo
        }
        #endregion

        #region Stampa del sistema
        /// <summary>
        /// Stampa la visualizzazione di tutto il sistema, ponte e parcheggio.
        /// </summary>
        private static void Stampa()
        {
            for (int i = 0; i < 29; i++)
            {
                Scrivi(0, i, new string(' ', 45)); // Pulizia della console
                if (i == 10)
                {
                    ponte.StampaPonte(); // Stampa il ponte
                    i += 7; // Salta le righe che corrispondono al ponte
                }
                else
                {
                    Scrivi(50, i, new string('▓', 20), ConsoleColor.Cyan); // Stampa il parcheggio
                }
            }
            MenuAzioni(true); // Mostra il menu delle azioni
        }
        #endregion

        #region Stampa dello stato del parcheggio
        /// <summary>
        /// Stampa lo stato attuale del parcheggio delle auto.
        /// </summary>
        private static void StampaParcheggio()
        {
            int i = 0;
            Auto[] parch = new Auto[parcheggio.Count];
            parcheggio.CopyTo(parch, 0); // Copia le auto dal parcheggio
            foreach (Auto auto in parch)
                Scrivi(5, i++, auto.nome); // Stampa le auto nel parcheggio
            Scrivi(5, i, new string(' ', 7)); // Spazio per la stampa successiva
        }
        #endregion

        static void Main(string[] args)
        {
            Title = "Alan Davide Bovo 4H 2025-01-20"; // Imposta il titolo della console
            OutputEncoding = Encoding.UTF8; // Imposta la codifica dell'output
            CursorVisible = false; // Nasconde il cursore

            Stampa(); // Stampa lo stato iniziale
            char scelta = ' '; // Inizializzazione della variabile per la scelta dell'utente
            int ids = 0; // ID iniziale delle auto

            do
            {
                if (KeyAvailable)
                {
                    scelta = MenuAzioni(false); // Mostra il menu delle azioni
                    switch (scelta)
                    {
                        case 'A':
                            if (parcheggio.Count == 10) // Se il parcheggio è pieno
                                break;
                            Auto auto = new Auto(ids++); // Crea una nuova auto
                            parcheggio.Enqueue(auto); // Aggiungi l'auto al parcheggio
                            StampaParcheggio(); // Stampa il parcheggio
                            Thread thAuto = new Thread(auto.Muovi); // Crea un thread per muovere l'auto
                            autos.Add(thAuto); // Aggiungi il thread alla lista
                            thAuto.Start(); // Avvia il thread
                            break;

                        case 'O':
                            ponte.GestisciPonte(true); // Apre il ponte
                            break;

                        case 'C':
                            ponte.GestisciPonte(false); // Chiude il ponte
                            break;

                        default: // U e tutti gli altri tasti
                            break;
                    }
                }

                StampaParcheggio(); // Ristampa lo stato del parcheggio
            } while (scelta != 'U'); // Continua finché l'utente non sceglie 'U' per uscire

            foreach (Thread t in autos)
                t.Abort(); // Aborta i thread delle auto
            _sem.Dispose(); // Rilascia il semaforo
        }
    }
}