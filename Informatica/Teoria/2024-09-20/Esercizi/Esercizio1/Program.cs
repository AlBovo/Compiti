namespace Esercizio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateOnly date_first, date_second;

            while(true)
            {
                Console.Write("Inserisci la prima data (gg/mm/aaaa): ");
                string first_date = Console.ReadLine();
                if (!DateOnly.TryParse(first_date, out date_first))
                    Console.WriteLine("La data non è nel formato corretto");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Inserisci la seconda data (gg/mm/aaaa): ");
                string second_date = Console.ReadLine();
                if (!DateOnly.TryParse(second_date, out date_second))
                    Console.WriteLine("La data non è nel formato corretto");
                else
                    break;
            }

            int delta = int.Abs(date_first.DayNumber - date_second.DayNumber);
            Console.WriteLine($"La differenza di giorni tra le due date è di {delta} giorn{(delta > 1 ? 'i' : 'o')}");
        }
    }
}
