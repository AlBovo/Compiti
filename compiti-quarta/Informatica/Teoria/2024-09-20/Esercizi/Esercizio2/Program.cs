namespace Esercizio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeOnly time;

            while (true)
            {
                Console.Write("Inserisci la prima data (HH:MM): ");
                string time_str = Console.ReadLine();
                if(time_str.Length != 5)
                {
                    Console.WriteLine("La data non è nel formato corretto");
                    continue;
                }
                if (!TimeOnly.TryParse(time_str, out time))
                    Console.WriteLine("La data non è nel formato corretto");
                else
                    break;
            }

            Console.Write("L'orario indicato è ");
            if (time.IsBetween(new TimeOnly(16, 00), new TimeOnly(22, 00)))
                Console.Write("interno");
            else
                Console.Write("esterno");
            Console.WriteLine(" al range [16:00, 22:00]");
        }
    }
}
