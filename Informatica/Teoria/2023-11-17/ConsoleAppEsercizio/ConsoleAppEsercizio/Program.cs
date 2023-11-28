/**********************************
*  Alan Davide Bovo 3H 2023-11-17 *
*  Ricerca lineare in un vettore  *
***********************************/
using System;

namespace ConsoleAppEsercizio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-17";
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-17");

            string[] elenco = { "Marco", "Lucia", "Giorgio", "Pamela", "Antonio", "Carla", "Fabio" };
            Console.Write("Inserisci il nome della persona da cercare: ");
            string nome = Console.ReadLine();
            for (int i = 0; i < elenco.Length; i++)
            {
                if (elenco[i].ToLower() != nome.ToLower())
                {
                    if(i == elenco.Length - 1)
                    {
                        Console.WriteLine("La persona indicata non è presente nell'elenco");
                    }
                }
                else
                {
                    Console.WriteLine($"La posizione è {i + 1}");
                    break;
                }
            }

            Console.WriteLine("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
