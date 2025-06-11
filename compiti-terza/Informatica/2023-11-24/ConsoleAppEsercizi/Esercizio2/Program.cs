namespace Esercizio2
{
    internal class Program
    {
        #region Sottoprogramma per trovare la prima occorrenza di una sottostringa in una stringa
        static int TrovaSottostringa(string principale, string sottostringa)
        {
            for (int i = 0; i < principale.Length; i++)
            {
                if (principale[i] == sottostringa[0])
                {
                    int j = 0;
                    while (j < sottostringa.Length && principale[i + j] == sottostringa[j])
                    {
                        j++;
                    }
                    if (j == sottostringa.Length)
                    {
                        return i;
                    }
                }
            }
            return -1; // non trovata
        }
        #endregion

        static void Main(string[] args)
        {
            #region Lettura dell'input
            Console.Write("Inserisci la stringa principale: ");
            string stringaPrincipale = Console.ReadLine();
            Console.Write("Inserisci la stringa da cercare: ");
            string stringaDaCercare = Console.ReadLine();
            #endregion

            #region Stampa dei risultati
            int posizione = TrovaSottostringa(stringaPrincipale, stringaDaCercare);
            if (posizione != -1)
            {
                Console.WriteLine($"La sottostringa è stata trovata in posizione {posizione}");
            }
            else
            {
                Console.WriteLine("La sottostringa non è stata trovata");
            }
            #endregion
        }
    }
}