namespace Esercizio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime[] dates = {
                new DateTime(2014, 6, 14, 6, 32, 0),
                new DateTime(2014, 7, 10, 23, 49, 0),
                new DateTime(2015, 1, 10, 1, 16, 0),
                new DateTime(2014, 12, 20, 21, 45, 0),
                new DateTime(2014, 6, 2, 15, 14, 0)
            };

            int idx_1 = 0, idx_2 = 1;
            double mini = double.MaxValue;
            for (int i = 0; i < dates.Length; i++)
            {
                for (int j = i + 1; j < dates.Length; j++)
                {
                    TimeSpan delta = dates[i] - dates[j];

                    if (double.Abs(delta.TotalSeconds) < mini)
                    {
                        idx_1 = i;
                        idx_2 = j;
                        mini = double.Abs(delta.TotalSeconds);
                    }
                }
            }

            Console.WriteLine($"Le date più vicine tra loro sono {dates[idx_1].ToShortDateString()} e {dates[idx_2].ToShortDateString()}");
        }
    }
}
