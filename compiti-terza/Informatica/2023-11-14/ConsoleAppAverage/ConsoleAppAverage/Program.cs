/***************************************
*    Alan Davide Bovo 3H 2023-11-14    *
* Calcolo della media di alcuni double *
****************************************/

namespace ConsoleAppAverage
{
    internal class Program
    {
        #region Lettura di un intero da standart input
        static int ReadInt(string message)
        {
            bool inputOK;
            int input;
            string inputStr;

            do
            {
                Console.Write(message);
                inputStr = Console.ReadLine();
                inputOK = int.TryParse(inputStr, out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                }
                else if(input <= 0)
                {
                    Console.WriteLine("L'intero inserito deve essere maggiore di 0, riprova ...");
                    inputOK = false;
                }
                // controllo del massimo da mettere
            } while (!inputOK);
            return input;
        }
        #endregion

        #region Lettura di un double da standard input
        static double ReadDouble(string message)
        {
            bool inputOK;
            double input;
            string inputStr;

            do
            {
                Console.Write(message);
                inputStr = Console.ReadLine();
                inputOK = double.TryParse(inputStr, out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                }

            } while (!inputOK);
            return input;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-14";
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-14");

            int n = ReadInt("Inserisci il numero di elementi: ");
            double[] array = new double[n];
            double somma = 0.0, avg;

            for (int i = 0; i < n; i++)
                array[i] = ReadDouble($"Inserisci il numero alla posizione {i}: ");

            for (int i = 0; i < n; i++)
                somma += array[i];

            avg = somma / n;
            Console.WriteLine($"La media dei numeri inseriti è {avg:0.###}");

            Console.WriteLine("Gli elementi che sono maggiori o uguale alla media sono: ");
            for (int i = 0; i < n; i++)
            {
                if (array[i] >= avg)
                    Console.Write(array[i] + " ");
            }

            Console.Write("\nPremi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}