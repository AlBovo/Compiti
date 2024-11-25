using System;
using System.Threading;
using static System.Console;

namespace CorsaConTreni
{
    internal class Program
    {
        static Object _lock = new Object(); // lock per le risorse usate dai thread
        static Random _random = new Random(); // istanza del random per generare le velocita

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
            private bool numero; // valore per rappresentare il treno
            private int velocita; // intero per memorizzare la velocita del treno
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
            }; // ascii art del treno

            public Treno(bool n)
            {
                numero = n; // assegnazione del id del treno
                velocita = _random.Next(50, 500); // generazione della velocita randomica del treno
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

        #region Metodo per stampare la ferrovia e i vari dati
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
            WriteLine("                             |" + new string(' ', 5) + "|                             |" + new string(' ', 5) + "|");
        }
        #endregion

        static void Main(string[] args)
        {
            StampaFerrovia();
            Treno treno1 = new Treno(1), treno2 = new Treno(2); // istanze di prova del treno
            treno1.StampaTreno(); // stampa del treno1
            treno2.StampaTreno(); // stampa del treno2

            Write("Premi un tasto per terminare l'esecuzione del programma ...");
            ReadKey();
        }
    }
}
