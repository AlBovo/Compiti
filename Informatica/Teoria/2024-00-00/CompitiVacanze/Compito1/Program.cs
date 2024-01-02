using System;

namespace Compito1
{
    internal class Program
    {
        static int Sottostringa(string principale, string sottostringa) // returna index della sottostringa oppure -1
        {
            for(int i=0; i<principale.Length - sottostringa.Length; i++)
            {
                for(int e=0; e<sottostringa.Length; e++)
                {
                    if (principale[i+e] != sottostringa[e])
                        break;
                    if(e == sottostringa.Length - 1)
                        return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Inserisci la stringa principale: ");
                string principale = Console.ReadLine();
                Console.Write("Inserisci la sottostringa: ");
                string sottostringa = Console.ReadLine();
                int posizione = Sottostringa(principale, sottostringa);
                if (posizione == -1)
                    Console.WriteLine("La sottostringa non è presente nella stringa principale");
                else
                    Console.WriteLine("La sottostringa è presente nella stringa principale alla posizione " + posizione);
                Console.Clear();
            }
        }
    }
}
