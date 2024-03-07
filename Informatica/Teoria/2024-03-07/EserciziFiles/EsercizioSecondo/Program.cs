namespace EsercizioSecondo
{
    internal class Program
    {
        static int ReadInt(string text)
        {
            bool inputOK;
            int number;
            do
            {
                Console.Write(text);
                if(!(inputOK = int.TryParse(Console.ReadLine(), out number)))
                {
                    Console.WriteLine("The number you wrote is not valid, try again ...");
                }
            } while (!inputOK);

            return number;
        }

        static void Main(string[] args)
        {
            string path = @"..\..\..\dati.txt";
            int number = ReadInt("Write the number to search: ");
            using (StreamReader sr = new StreamReader(path))
            {
                string line; int n = 1;
                bool done = false;
                while((line = sr.ReadLine()) != null)
                {
                    if (int.Parse(line) == number)
                    {
                        Console.WriteLine($"Number found at line {n}");
                        done = true;
                    }
                    n++;
                }
                if (!done)
                    Console.WriteLine("The number was not in the list");
            }
        }
    }
}
