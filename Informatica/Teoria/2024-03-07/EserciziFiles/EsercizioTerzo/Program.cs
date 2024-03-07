namespace EsercizioTerzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathRead = @"..\..\..\dati.txt";
            string pathWrite = @"..\..\..\result.txt";
            List<int> nums = new List<int>();
            using (StreamReader sr = new StreamReader(pathRead))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    nums.Add(int.Parse(line));
                sr.Close();
            }
            nums.Sort();
            using (StreamWriter sw = new StreamWriter(pathWrite))
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    sw.WriteLine(nums[i]);
                }
                sw.Close();
            }
        }
    }
}
