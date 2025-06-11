namespace Esercizio1
{
    internal class Program
    {
        #region Enumeratore per l'ordinamento dell'array
        enum Ordinamento
        {
            Crescente = -1,
            Decrescente = +1,
            Nessuno = 0
        }
        #endregion

        #region Metodo per l'ordinamento dell'array
        static Ordinamento GetOrdinamento(int[] array)
        {
            bool crescente = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    crescente = false;
                    continue;
                }
                else if (!crescente && array[i] < array[i + 1])
                {
                    return Ordinamento.Nessuno;
                }
            }

            return crescente ? Ordinamento.Crescente : Ordinamento.Decrescente;
        }
        #endregion

        #region Metodo per la lettura di un intero da console
        static int ReadInt(string message, bool num)
        {
            int n;
            bool inputOK;
            do
            {
                Console.Write(message);
                inputOK = int.TryParse(Console.ReadLine(), out n);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un intero, riprova ...");
                }
                else if(num && n <= 0)
                {
                    Console.WriteLine("L'input inserito non è un numero positivo, riprova ...");
                    inputOK = false;
                }

            } while (!inputOK);
            return n;
        }
        #endregion

        static void Main(string[] args)
        {
            #region Lettura dell'input
            int n;
            n = ReadInt("Inserisci la dimensione dell'array: ", true);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = ReadInt($"Inserisci l'elemento {i + 1}: ", false);
            #endregion

            #region Stampa dell'ordinamento dell'array
            Ordinamento ordinamento = GetOrdinamento(array);
            switch (ordinamento)
            {
                case Ordinamento.Crescente:
                    Console.WriteLine("L'array è ordinato in modo crescente");
                    break;
                case Ordinamento.Decrescente:
                    Console.WriteLine("L'array è ordinato in modo decrescente");
                    break;
                case Ordinamento.Nessuno:
                    Console.WriteLine("L'array non è ordinato");
                    break;
            }
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}