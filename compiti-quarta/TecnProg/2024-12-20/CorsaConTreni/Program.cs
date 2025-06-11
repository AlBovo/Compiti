/*********************************
* Alan Davide Bovo 4H 2024-12-02 *
*    Corsa con treni e thread    *
*********************************/

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;

namespace CorsaConTreni
{
    internal class Program
    {
        static Object _lock = new Object(); // lock per le risorse usate dai thread
        static Random _random = new Random(); // oggetto per generare le velocita randomiche
        static Thread[] _treni = new Thread[2]; // array di thread per i vari treni

        #region Metodo per scrivere a una posizione con il default color
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

        #region Classe Treno
        class Treno
        {
            private int numero; // identificativo del treno usato per i thread
            private int velocita; // velocita randomica del treno

            #region Ascii art del treno
            private string[] treno =
            {
                "╔═══╗",
                "║   ║",
                "║   ║",
                "║   ║",
                "╚═══╝",
                "  |  ",
                "╔═══╗",
                "║   ║",
                "║   ║",
                "║   ║",
                "╚═══╝",
                "  |  ",
                "╔═══╗",
                "║   ║",
                "║   ║",
                "║   ║",
                "╚═══╝",
            };
            #endregion

            #region Costruttore della classe Treno
            public Treno(int n)
            {
                numero = n; // assegnazione dell'identificativo al treno
                velocita = _random.Next(50, 500); // assegnazione di una velocita randomica
            }
            #endregion

            #region Metodo per stampare il treno e aggiornarlo con un'animazione
            public void StampaTreno()
            {
                // calcolo delle coordinate del treno
                int x = 30 * numero + (6 * (numero - 1)), y = 0, y1;

                #region Aggiornamento del colore dei semafori a rosso
                Scrivi(29 + 36 * (numero - 1), 9, "■", ConsoleColor.Red);
                Scrivi(35 + 36 * (numero - 1), 9, "■", ConsoleColor.Red);
                Scrivi(29 + 36 * (numero - 1), 13, "■", ConsoleColor.Red);
                Scrivi(35 + 36 * (numero - 1), 13, "■", ConsoleColor.Red);
                for (int x1 = 0; x1 < 3; x1++) // scrittura dei gate per bloccare l'entrata alla ferrovia
                {
                    Scrivi(29 + 36 * (numero - 1), 10 + x1, "|", ConsoleColor.DarkRed);
                    Scrivi(35 + 36 * (numero - 1), 10 + x1, "|", ConsoleColor.DarkRed);
                }
                #endregion

                #region Animazione iniziale per il treno che entra parzialmente nella ferrovia
                for (int y2 = 0; y2 < treno.Length; y2++)
                {
                    for (int y3 = 0; y3 <= y2; y3++)
                        Scrivi(x, y2 - y3, treno[treno.Length - y3 - 1]); // animazione parziale del treno

                    Thread.Sleep(velocita); // sleep per gestire la velocita'
                }
                #endregion


                while (y < 29) // finche' il treno e' nello schermo
                {
                    y1 = y; // 
                    foreach (var r in treno) // per ogni riga del treno
                    {
                        if (y1 == 29) // fine della console verticalmente
                            break;
                        Scrivi(x, y1++, r); // scrittura della riga del treno
                    }
                    Thread.Sleep(velocita); // sleep per gestire la velocita'
                    // sovrascrittura dell'ultima riga dell'ultima carrozza con una riga vuota
                    Scrivi(x, y++, new string(' ', 5));
                }

                #region Aggiornamento del colore dei semafori a verde
                Scrivi(29 + 36 * (numero - 1), 9, "■", ConsoleColor.Green);
                Scrivi(35 + 36 * (numero - 1), 9, "■", ConsoleColor.Green);
                Scrivi(29 + 36 * (numero - 1), 13, "■", ConsoleColor.Green);
                Scrivi(35 + 36 * (numero - 1), 13, "■", ConsoleColor.Green);
                for (int x1 = 0; x1 < 3; x1++) // rimozione dei gate della ferrovia
                {
                    Scrivi(29 + 36 * (numero - 1), 10 + x1, " ");
                    Scrivi(35 + 36 * (numero - 1), 10 + x1, " ");
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Classe Persona
        class Persona
        {
            public int pos { get; private set; } // posizione della persona
            public string name { get; private set; } // nome della persona

            #region Ascii art della persona
            private string[] persona =
            {
                @"  [] ",
                @" -||-",
                @"  /\ "
            };
            #endregion

            #region Costruttore della classe persona
            public Persona(int pos, string name)
            {
                this.pos = pos; // inizializzazione della posizione
                this.name = name; // assegnazione del nome
            }
            #endregion

            #region Metodo per muovere la persona
            public void Muovi()
            {
                while (pos < 114) // finche' e' dentro la console
                {
                    if (pos == 25 && _treni[0].IsAlive) // aspetta che il primo treno passi
                        _treni[0].Join();
                    if (pos == 60 && _treni[1].IsAlive) // aspetta che il secondo treno passi
                        _treni[1].Join();

                    for (int i = 0; i < persona.Length; i++) // disegna ogni riga della persona
                        Scrivi(pos, 10 + i, persona[i]);
                    pos++; // aumenta di uno l'ascissa
                    Thread.Sleep(50); // gestisce la velocita'
                }
            }
            #endregion

            #region Metodo per la stampa del menu per la scelta dell'azione
            public static char MenuAzioni()
            {
                // stampa delle azioni e del titolo
                Scrivi(1, 1, "Sospendere (S)");
                Scrivi(1, 2, "Riprendere (R)");
                Scrivi(1, 3, "Abortire   (A)");

                char c = ReadKey(true).KeyChar; // lettura del carattere da restituire
                return char.ToUpper(c); // return del valore in maiuscolo
            }
            #endregion

            #region Metodo per eseguire un comando sulla persona
            public void Comando(Thread persona)
            {
                char scelta = MenuAzioni(); // stampa del menu delle azioni

                switch (scelta)
                {
                    case 'S':
                        lock (_lock)
                            if (persona.IsAlive)
                                persona.Suspend();
                        break;

                    case 'R':
                        if (persona.ThreadState == ThreadState.Suspended)
                            persona.Resume();
                        break;

                    case 'A':
                        lock (_lock)
                            if (persona.ThreadState != ThreadState.Suspended)
                                persona.Abort();
                        break;
                }
            }
            #endregion
        }
        #endregion

        #region Metodo per la stampa iniziale della ferrovia
        static private void StampaFerrovia()
        {
            WriteLine("         MENU AZIONI         |" + new string(' ', 5) + "|Stato treno 1                |" + new string(' ', 5) + "|Stato treno 2");
            WriteLine(" Sospendere (S)              |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine(" Riprendere (R)              |" + new string(' ', 5) + "|Is alive =                   |" + new string(' ', 5) + "|Is alive = ");
            WriteLine(" Abortire   (A)              |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|" + string.Concat(Enumerable.Repeat("█ ", 24)));
            WriteLine("                             ■" + new string(' ', 5) + "■                             ■" + new string(' ', 5) + "■");
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             ■" + new string(' ', 5) + "■                             ■" + new string(' ', 5) + "■");
            WriteLine("█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|█ █ █ █ █ █ █ █ █ █ █ █ █ █ █|" + new string(' ', 5) + "|" + string.Concat(Enumerable.Repeat("█ ", 24)));
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
        }
        #endregion

        #region Metodo per aggiornare a console lo stato dei treni
        static void AggiornaStato()
        {
            bool treno0, treno1; // variabili per gestire lo stato dei treni
            do
            {
                treno0 = _treni[0].IsAlive; // aggiornamento dello stato del primo treno
                treno1 = _treni[1].IsAlive; // aggiornamento dello stato del secondo treno
                Scrivi(47, 2, treno0.ToString()); // scrittura dello stato del primo treno
                Scrivi(83, 2, treno1.ToString()); // scrittura dello stato del secondo treno
                Thread.Sleep(20); // sleep per non occupare troppo tempo nella cpu
            } while (treno0 || treno1); // finche' entrambi i treni sono in corsa
        }
        #endregion

        static void Main(string[] args)
        {
            Title = "Alan Davide Bovo 4H 2024-12-02";
            CursorVisible = false; // impostazione del cursore come non visibile
            
            Treno treno1 = new Treno(1), treno2 = new Treno(2); // instanzio le classi dei treni
            _treni[0] = new Thread(treno1.StampaTreno); // instanzio il thread per l'animazione del primo treno
            _treni[1] = new Thread(treno2.StampaTreno); // instanzio il thread per l'animazione del secondo treno
            StampaFerrovia(); // stampa dello stato iniziale della ferrovia

            _treni[0].Start(); // avvia animazione del primo treno
            _treni[1].Start(); // avvia animazione del secondo treno
         
            Thread stato = new Thread(AggiornaStato); // instanzio il thread per aggiornare lo stato
            stato.Start(); // avvio il thread per aggiornare lo stato

            Persona mario = new Persona(0, "Mario"); // creazione della persona mario
            Thread persona = new Thread(mario.Muovi); // instanzio il thread per l'animazione di mario
            persona.Start(); // mario inizia a camminare

            while (persona.IsAlive) // finche' mario e' vivo
                if (KeyAvailable) mario.Comando(persona);
            
            if (_treni[0].IsAlive) // ferma il primo treno se e' ancora in moto
                _treni[0].Abort();
            if (_treni[1].IsAlive) // ferma il secondo treno se e' ancora in moto
                _treni[1].Abort();

            Scrivi(0, 29, "Premi un tasto per terminare l'esecuzione del programma ..."); // imposto il cursore alla fine della console
            ReadKey();
        }
    }
}
