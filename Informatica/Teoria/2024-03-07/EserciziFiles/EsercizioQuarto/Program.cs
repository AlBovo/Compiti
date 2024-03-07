namespace EsercizioQuarto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> freq = new SortedDictionary<int, int>();
            using (StreamReader sr = new StreamReader(@"..\..\..\dati.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if(freq.ContainsKey(num))
                        freq[num]++;
                    else
                        freq.Add(num, 1);
                }

                sr.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\..\result.txt"))
            {
                foreach(var i  in freq)
                    sw.WriteLine($"{i.Key}, {i.Value}");
                sw.Close();
            }
        }
    }
}
