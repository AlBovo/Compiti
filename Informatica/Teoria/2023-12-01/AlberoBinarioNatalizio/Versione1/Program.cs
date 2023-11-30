using System;

namespace Versione1
{
    internal class Program
    {
        #region Funzione per leggere N da console
        static int ReadInt(string message)
        {
            bool inputOK;
            int input;

            do
            {
                Console.Write(message);
                inputOK = int.TryParse(Console.ReadLine(), out input);

                if(!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
                else if(input <= 0)
                {
                    Console.WriteLine("L'intero inserito deve essere maggiore di 0, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            return input;
        }
        #endregion

        static void Main(string[] args)
        {
            int N = ReadInt("Inserisci il numero di elementi: ");

            #region Stampa dell'albero binario
            for (int i=0, c = 0, j; c<N; i+=j)
            {
                for(j=0; j<Math.Pow(2, c); j++)
                {
                    Console.Write($"{j+i} ");
                }
                c++;
                Console.Write('\n');
            }
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
