namespace EserciziFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathRead = @"..\..\..\dati.txt";
            string pathWrite = @"..\..\..\result.txt";
            int sum = 0, n = 0;
            using (StreamReader sr = new StreamReader(pathRead))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sum += int.Parse(line);
                    n++;
                }
                sr.Close();
            }
            Console.WriteLine($"The sum of the values is {sum}, and the average is {sum / n}");
            StreamWriter sw = new StreamWriter(pathWrite);
            using (StreamReader sr = new StreamReader(pathRead))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (int.Parse(line) * n < sum)
                        sw.WriteLine(line);
                }
                sr.Close();
            }
            sw.Close();
        }
    }
}
