/*********************************
* Alan Davide Bovo 3H 2023-11-21 *
*        Conto Alla Rovescia     *
*********************************/

namespace ContoAllaRovescia
{
    internal class Program
    {
        #region Matrice contenente le rappresentazioni dei numeri
        static string[][] cifre =
        {
            new string[] 
            {
                " ▓▓▓▓▓▓ ", // ZERO
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                "       ▓", // UNO
                "       ▓",
                "       ▓",
                "        ",
                "       ▓",
                "       ▓",
                "       ▓",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // DUE
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // TRE
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            { 
                "▓      ▓", // QUATTRO
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                "       ▓",  
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // CINQUE
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // SEI
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // SETTE
                "       ▓",
                "       ▓",
                "        ",
                "       ▓",
                "       ▓",
                "       ▓",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // OTTO
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ", // NOVE
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
            },
        };
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-21";

            #region Conto alla rovescia
            for (int i=0; i<10; i++)
            {
                (int, int) position = Console.GetCursorPosition();
                int line = 0;
                
                foreach (string s in cifre[i])
                {
                    Console.WriteLine(s);
                    line++;
                    Console.SetCursorPosition(position.Item1, line); // traslo a destra il cursore
                }

                Console.SetCursorPosition(position.Item1 + 8 + 2, 0); // posizione + lunghezza + spazio
                Thread.Sleep(1000); // wait di 1 secondo
            }
            #endregion

            Console.SetCursorPosition(0, 8);
            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}