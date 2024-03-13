namespace EsercizioDFS
{
    internal class Program
    {
        private static List<List<(int, int)>> graph = new List<List<(int, int)>>();
        private static List<int> costs = new List<int>();

        static void Backtracking(int pos)
        {
            foreach (var next in graph[pos])
            {
                if (costs[next.Item1] > costs[pos] + next.Item2)
                {
                    costs[next.Item1] = costs[pos] + next.Item2;
                    Backtracking(next.Item1);
                }
            }
        }

        static void Main(string[] args)
        {
            int n;
            using (StreamReader sr = new StreamReader(@"..\..\..\input.txt"))
            {
                n = int.Parse(sr.ReadLine()!);
                for (int i = 0; i < n; i++)
                {
                    graph.Add(new List<(int, int)>());
                    costs.Add((int)1e9);
                }

                for (int i = 0; i < n; i++)
                {
                    var line = sr.ReadLine()!.Split(',');
                    int from = int.Parse(line[0].Trim()),
                        to = int.Parse(line[1].Trim()),
                        cost = int.Parse(line[2].Trim());
                    graph[from].Add((to, cost));
                    graph[to].Add((from, cost));
                }

                sr.Close();
            }
            costs[0] = 0;
            Backtracking(0);

            for (int i = 0; i < costs.Count; i++)
            {
                if (costs[i] == 1e9)
                    Console.WriteLine($"Il nodo {i} non è raggiungibile da {0}");
                else
                    Console.WriteLine($"Il nodo {i} è raggiungibile da {0} con {costs[i]}");
            }
        }
    }
}
