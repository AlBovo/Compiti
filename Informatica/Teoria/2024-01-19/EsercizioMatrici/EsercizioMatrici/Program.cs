using System;

namespace EsercizioMatrici
{
    internal class Program
    {
        #region Funzione per leggere un intero da console
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
            } while (!inputOK);
            return input;
        }
        #endregion

        #region Funzione per leggere una stringa da console
        static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        #endregion

        #region Funzione per calcolare la media della classe
        static void CalcolaMedie(int[,] t1, int[,] t2, out double mediaPrima, out double mediaSeconda)
        {
            mediaPrima = mediaSeconda = 0;                  // valori per calcolare le medie
            for (int i = 0; i < t1.GetLength(0); i++)       // ciclo per calcolare le medie di ogni studente
            {
                for (int e = 0; e < t1.GetLength(1); e++)   // ciclo per prendere ogni materia
                {
                    mediaPrima += t1[i, e];                 // aumento la media con il voto del studente i nella materia e
                    mediaSeconda += t2[i, e];
                }
            }
            mediaPrima /= t1.Length;                        // dalla somma calcolo la media
            mediaSeconda /= t2.Length;
        }
        #endregion

        #region Funzione per calcolare l'indice dello studente migliore
        static int CalcolareStudente(int[,] quadrimestre)
        {
            int mediaMigliore = -1, indiceMigliore = -1;

            for (int i = 0; i < quadrimestre.GetLength(0); i++)
            {
                int somma = 0;
                for (int e = 0; e < quadrimestre.GetLength(1); e++)
                    somma += quadrimestre[i, e];

                if(somma > mediaMigliore)
                {
                    mediaMigliore = somma;
                    indiceMigliore = i;
                }
            }

            return indiceMigliore;
        }
        #endregion

        static void Main(string[] args)
        {
            int n = ReadInt("Inserisci il numero di alunni: ");
            int m = ReadInt("Inserisci il numero di materie: ");
            int[,] t1 = new int[n, m], t2 = new int[n, m];
            string[] nome = new string[n], materia = new string[m];
            
            for (int i = 0; i < n; i++)
                nome[i] = ReadString($"Inserisci il nome del {i + 1} alunno: ");

            for (int i = 0; i < m; i++)
                materia[i] = ReadString($"Inserisci il nome della {i + 1} materia: ");

            for (int i = 0; i < n; i++)
            {
                for (int e = 0; e < m; e++)
                {
                    t1[i, e] = ReadInt($"Inserisci il voto che ha preso {nome[i]} in {materia[e]} nel primo quadrimestre: ");
                    t2[i, e] = ReadInt($"Inserisci il voto che ha preso {nome[i]} in {materia[e]} nel secondo quadrimestre: ");
                }
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
