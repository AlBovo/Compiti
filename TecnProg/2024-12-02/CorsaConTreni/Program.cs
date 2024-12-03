using Microsoft.Win32.SafeHandles;
using System;
using System.Threading;
using static System.Console;

namespace CorsaConTreni
{
    internal class Program
    {
        static Object _lock = new Object(); // lock per le risorse usate dai thread
        static Random _random = new Random();
        static Thread[] _treni = new Thread[2];

        private static void Scrivi(int sinistra, int sopra, string testo)
        {
            lock (_lock) // lock della risorsa console
            {
                SetCursorPosition(sinistra, sopra); // imposto la posizione del cursore
                Write(testo); // scrivo il testo richiesto
            }
        }

        class Treno
        {
            private int numero;
            private int velocita;
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

            public Treno(int n)
            {
                numero = n;
                velocita = _random.Next(50, 500);
            }

            public void StampaTreno()
            {
                int x = 30 * numero + (6 * (numero - 1)), y = 0, y1;
                while (y < 30)
                {
                    y1 = y;
                    foreach (var r in treno)
                    {
                        if (y1 == 30)
                            break;
                        Scrivi(x, y1++, r);
                    }
                    Thread.Sleep(velocita);
                    Scrivi(x, y++, new string(' ', 5));
                }
            }
        }

        class Persona
        {
            public int pos { get; private set; }
            public string name { get; private set; }

            private string[] persona =
            {
                @"  [] ",
                @" -||-",
                @"  /\ "
            };

            public Persona(int pos, string name)
            {
                this.pos = pos;
                this.name = name;
            }

            public void Muovi()
            {
                while (pos < 130)
                {
                    if (pos == 25 && _treni[0].IsAlive)
                    { Thread.Sleep(50); continue; }
                    if (pos == 60 && _treni[1].IsAlive)
                    { Thread.Sleep(50); continue; }

                    for (int i = 0; i < persona.Length; i++)
                        Scrivi(pos, 10 + i, persona[i]);
                    pos++;
                    Thread.Sleep(50);
                }
            }
        }

        static private void StampaFerrovia()
        {
            WriteLine("                             |" + new string(' ', 5) + "|Stato treno 1                |" + new string(' ', 5) + "|Stato treno 2");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|Is alive =                   |" + new string(' ', 5) + "|Is alive = ");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
            WriteLine("                             -" + new string(' ', 5) + "-                             -" + new string(' ', 5) + "-");
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             " + new string(' ', 5) + "                                " + new string(' ', 5));
            WriteLine("                             -" + new string(' ', 5) + "-                             -" + new string(' ', 5) + "-");
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
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
        }

        static void AggiornaStato()
        {
            bool treno0, treno1;
            do
            {
                treno0 = _treni[0].IsAlive;
                treno1 = _treni[1].IsAlive;
                Scrivi(47, 2, treno0.ToString());
                Scrivi(83, 2, treno1.ToString());
                Thread.Sleep(20);
            } while (treno0 || treno1);
        }

        static void Main(string[] args)
        {
            CursorVisible = false;
            Treno treno1 = new Treno(1), treno2 = new Treno(2);
            _treni[0] = new Thread(treno1.StampaTreno);
            _treni[1] = new Thread(treno2.StampaTreno);
            StampaFerrovia();

            _treni[0].Start();
            _treni[1].Start();
         
            Thread stato = new Thread(AggiornaStato);
            stato.Start();

            Persona mario = new Persona(0, "Mario");
            Thread persona = new Thread(mario.Muovi);
            persona.Start();

            //Write("Premi un tasto per terminare l'esecuzione del programma ...");
            //ReadKey();
        }
    }
}
