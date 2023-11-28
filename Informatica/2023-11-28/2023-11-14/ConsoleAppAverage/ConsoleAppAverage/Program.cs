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
                else if(input <= 0) // l'input deve essere positivo
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

            #region Dichiarazione e inizializzazione delle variabili
            int n = ReadInt("Inserisci il numero di elementi: ");
            double[] array = new double[n]; // array contenente i valori inseriti dall'utente
            double somma = 0.0, avg;
            #endregion

            for (int i = 0; i < n; i++)
            {
                array[i] = ReadDouble($"Inserisci il numero alla posizione {i}: "); // lettura dell'array
                somma += array[i]; // calcolo della somma
            }

            avg = somma / n; // calcolo della media

            Console.WriteLine($"La media dei numeri inseriti è {avg:0.###}"); // stampa della media
            Console.WriteLine("Gli elementi che sono maggiori o uguale alla media sono: "); // stampa dei numeri maggiori o uguali della media

            for (int i = 0; i < n; i++)
            {
                if (array[i] >= avg)
                    Console.Write(array[i] + " ");
            }

            Console.Write("\nPremi un tasto per terminare l'esecuzione del programma ..."); // uscita dal programma
            Console.ReadKey();
        }
    }
}