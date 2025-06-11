namespace EsercizioDijkstra
{
    internal class Program
    {
        private static List<List<(int, int)>> graph = new List<List<(int, int)>>();

        static void Dijkstra(int start)
        {
            bool[] visited = Enumerable.Repeat(false, 1000).ToArray();
            int[] costs = Enumerable.Repeat((int)1e9, graph.Count).ToArray();
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);
            costs[start] = 0;

            while (pq.Count > 0)
            {
                int pos = pq.Dequeue();
                if (visited[pos])
                    continue;

                visited[pos] = true;
                foreach (var next in graph[pos])
                {
                    if (costs[next.Item1] > costs[pos] + next.Item2)
                    {
                        costs[next.Item1] = costs[pos] + next.Item2;
                        pq.Enqueue(next.Item1, costs[next.Item1]);
                    }
                }
            }
            for (int i = 0; i < costs.Length; i++)
            {
                if (costs[i] == 1e9)
                    Console.WriteLine($"Il nodo {i} non è raggiungibile da {start}");
                else
                    Console.WriteLine($"Il nodo {i} è raggiungibile da {start} con {costs[i]}");
            }
        }

        static void Main(string[] args)
        {
            int n;
            using (StreamReader sr = new StreamReader(@"..\..\..\input.txt"))
            {
                n = int.Parse(sr.ReadLine()!);
                for (int i = 0; i < n; i++)
                    graph.Add(new List<(int, int)>());

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

            Dijkstra(0);
        }
    }
}
