namespace Esercizi
{
    internal class Program
    {
        #region Funzione per leggere un intero
        static int ReadInt(string message)
        {
            string input;
            int value;
            bool inputOK;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                inputOK = int.TryParse(input, out value);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un intero, riprova ...");
                }
                else if (value <= 0)
                {
                    Console.WriteLine("Il numero intero inserito deve essere maggiore di zero, riprova ...");
                }

            } while (!inputOK);

            return value;
        }
        #endregion

        static void Main(string[] args)
        {
            #region Primo esercizio
            int n = ReadInt("Inserisci un numero intero maggiore di zero: "), sum;
            int x = (int)Math.Ceiling(n / 5 / 2.0);

            /* Caso con (n / 5) pari
            * 5 = 1 * 5
            * 15 = 2 * 15
            * 25 = 3 * 25
            * 35 = 4 * 35
            * 45 = 5 * 45
            * ...
            */

            /* Caso con (n / 5) dispari
            * 10 = 1 * 5 + 10
            * 20 = 2 * 15 + 20
            * 30 = 3 * 25 + 30
            * 40 = 4 * 35 + 40
            * 50 = 5 * 45 + 50
            * ...
            */

            if (n < 5)
                sum = 0;
            else if (n / 5 % 2 == 0)
                // x * ((n / 5) - 1) * 5 + (x + 1) * 5
                sum = x * (n / 5 - 1) * 5 + n / 5 * 5;
            else
                // x * (n / 5) * 5
                sum = x * (n / 5) * 5;

            Console.WriteLine($"La somma dei multipli di 5 minori o uguali a {n} è {sum}");
            #endregion

            #region Secondo esercizio
            // Scrivere il risultato delle seguenti espressioni, indicando il tipo del risultato:

            Console.WriteLine($"Risultato di {2 * 2.25:0.###} con previsto {4.5:0.###}");
            Console.WriteLine($"Risultato di {2 * (int)2.25:0.###} con previsto {4:0.###}");
            Console.WriteLine($"Risultato di {(double)2 * (int)2.9:0.###} con previsto {4.0:0.###}");
            Console.WriteLine($"Risultato di {(int)3.1 * (int)2.9:0.###} con previsto {6:0.###}");
            Console.WriteLine($"Risultato di {(int)(3.1 * 2.9):0.###} con previsto {8:0.###}");
            #endregion

            #region Terzo esercizio
            // Semplificare, eliminando l'operatore “not”, le seguenti espressioni booleane:

            Console.WriteLine("!(x == 7) equivale a x != 7");
            Console.WriteLine("!(x < 5) equivale a x >= 5");
            Console.WriteLine("!(x >= -3) equivale a x < -3");
            Console.WriteLine("!(x < 4 || x >= 20) equivale a x >= 4 && x < 20");
            #endregion
        }
    }
}