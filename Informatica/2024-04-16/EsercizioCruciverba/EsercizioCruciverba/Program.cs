/**********************************
* Alan Davide Bovo 3H 2024-03-12  *
* Applicazione Console Cruciverba *
**********************************/
using System;
using System.Collections.Generic;
using System.IO;

namespace EsercizioCruciverba
{
    internal class Program
    {
        static public bool[,] done = new bool[0,0];
        static public List<List<char>> chars = new List<List<char>>();
        static public HashSet<string> names = new HashSet<string>();

        static void Trova(int x, int y)
        {
            string temp = "";
            for(int i=y, e=x; i >= 0 && e >= 0; i--, e--) // alto sinistra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e++, i++] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; e >= 0; e--) // alto
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e++, i] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; i<chars[0].Count && e >= 0; i++, e--) // alto destra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e++, i--] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0; i--) // sinistra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e, i++] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count; i++) // destra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e, i--] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0 && e < chars.Count; i--, e++) // giù sinistra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e--, i++] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; e < chars.Count; e++) // giù
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e--, i] = true;
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count && e < chars.Count; i++, e++) // giù destra
            {
                temp += chars[e][i];
                if (names.Contains(temp))
                {
                    for (int j = 0; j < temp.Length; j++)
                        done[e--, i--] = true;
                }
            }
        }

        static void ReadFile(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                int i = 0;
                while (line != "")
                {
                    chars.Add(new List<char>());
                    foreach (char c in line)
                        chars[i].Add(c);
                    line = sr.ReadLine();
                    i++;
                }

                line = sr.ReadLine();
                while (line != null)
                {
                    names.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        static void Main()
        {
            Console.Title = "Alan Davide Bovo 3H 2024-03-12";
            ReadFile(@"..\..\..\dati.txt");
            done = new bool[chars.Count, chars[0].Count];
            for (int i = 0; i < chars.Count; i++)
            {
                for (int e = 0; e < chars[i].Count; e++)
                {
                    Console.Write($"{chars[i][e]} ");
                    Trova(i, e);
                }
                Console.WriteLine();
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
