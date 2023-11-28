/**********************************
 * Alan Davide Bovo 3H 2023-11-21 *
 * Conversione da Numero a Ascii  *
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

        #region Funzione per leggere un numero valido
        static int ReadInt(string messaggio)
        {
            int result = 0;
            bool inputOK;

            do
            {
                Console.Write(messaggio);
                inputOK = int.TryParse(Console.ReadLine(), out result);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
                else if(result < 0) // l'input deve essere positivo o uguale a zero
                {
                    Console.WriteLine("L'intero inserito deve essere positivo, riprova ...");
                    inputOK = false;
                }

            } while (!inputOK);
            return result;
        }
        #endregion

        #region Funzione per stampare il numero nella sua rappresentazione
        static void StampaNumero(int numero)
        {
            Console.WriteLine(); // writeline di allineamento
            foreach (char cifra in numero.ToString())
            {
                int line = 2;
                (int, int) position = Console.GetCursorPosition(); // ottengo la posizione del cursore

                #region Stampa della rappresentazione ascii del numero
                foreach (string st in cifre[cifra - '0'])
                {
                    Console.WriteLine(st);
                    Console.SetCursorPosition(position.Item1, ++line);
                }
                #endregion

                Console.SetCursorPosition(position.Item1 + 8 + 2, position.Item2); // traslazione del cursore
                numero /= 10;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-21";

            StampaNumero(ReadInt("Inserisci il numero da stampare: ")); // conversione in ascii art di un numero inserito

            Console.SetCursorPosition(0, 10);
            Console.Write("Premi un tasto per terminare l'esecuzione del programma ..."); // uscita dal programma
            Console.ReadKey();
        }
    }
}