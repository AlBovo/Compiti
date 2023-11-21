namespace ContoAllaRovescia
{
    internal class Program
    {
        #region Matrice contenente le rappresentazioni dei numeri
        static string[][] cifre =
        {
            new string[] 
            {
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                "       ▓",
                "       ▓",
                "       ▓",
                "        ",
                "       ▓",
                "       ▓",
                "       ▓",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            { 
                "▓      ▓",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                "       ▓",  
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "▓       ",
                "▓       ",
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "       ▓",
                "       ▓",
                "        ",
                "       ▓",
                "       ▓",
                "       ▓",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
                "▓      ▓",
                "▓      ▓",
                " ▓▓▓▓▓▓ ",
            },

            new string[]
            {
                " ▓▓▓▓▓▓ ",
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
            for(int i=0; i<10; i++)
            {
                (int, int) position = Console.GetCursorPosition();
                int line = 0;
                foreach (string s in cifre[i])
                {
                    Console.WriteLine(s);
                    line++;
                    Console.SetCursorPosition(position.Item1, line);
                }
                Console.SetCursorPosition(position.Item1 + 8 + 2, 0); // posizione + lunghezza + spazio
                Thread.Sleep(1000);
            }

            Console.SetCursorPosition(0, 8);
            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}