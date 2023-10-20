using System;

namespace Esercizio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(long n_punti_tot=10; n_punti_tot<=100000000000; n_punti_tot*=10)
            {
                #region Dichiarazione delle variabili
                const double lato = 1.0;
                long punti_interni = 0;
                Random rand = new Random();
                #endregion

                #region Generazione dei punti e calcolo del numero di punti all'interno del cerchio
                for (int i = 0; i < n_punti_tot; i++)
                {
                    double x = rand.NextDouble();
                    double y = rand.NextDouble();

                    if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= lato)
                    {
                        punti_interni++;
                    }
                }
                #endregion

                #region Calcolo del PI Greco
                double pi_greco = (4 * (double)(punti_interni)) / n_punti_tot;
                Console.WriteLine($"Il valore di PI Greco calcolato è {pi_greco}");
                #endregion
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
