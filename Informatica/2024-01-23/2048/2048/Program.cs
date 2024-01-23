using System;

namespace _2048
{
    internal class Program
    {
        static Random rnd = new Random();

        static ConsoleKey LeggiTasto()
        {
            while (!Console.KeyAvailable)
                continue;

            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.Key;
        }

        static void GeneraNumero(int[,] mat)
        {
            int x = rnd.Next(4);
            int y = rnd.Next(4);
            while (mat[x, y] != 0)
            {
                x = rnd.Next(4);
                y = rnd.Next(4);
            }

            mat[x, y] = (rnd.Next(0, 10) >= 8 ? 2 : 1);
        }

        static bool MakeMove(int[,] mat, ConsoleKey key)
        {
            bool done = false;
            switch(key)
            {
                case ConsoleKey.DownArrow:
                    for (int e = 0; e < 4; e++)
                    {
                        int[] freePos = new int[4];
                        int point = 0, pointUse = 0;

                        for (int i = 3; i >= 0; --i)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[freePos[pointUse++], e] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if(mat[i, e] == 0)
                                freePos[point++] = i;
                        }
                        for (int i = 3; i > 0; --i)
                        {
                            if (mat[i, e] == 0)
                                continue;
                            if (mat[i, e] == mat[i - 1, e])
                            {
                                mat[i, e]++;
                                mat[i - 1, e] = 0;
                                done = true;
                            }
                        }
                        freePos = new int[4];
                        point = pointUse = 0;
                        for (int i = 3; i >= 0; --i)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[freePos[pointUse++], e] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = i;
                        }
                    }
                    break;
                case ConsoleKey.UpArrow:
                    for (int e = 0; e < 4; e++)
                    {
                        int[] freePos = new int[4];
                        int point = 0, pointUse = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[freePos[pointUse++], e] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = i;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            if (mat[i, e] == 0)
                                continue;
                            if (mat[i, e] == mat[i + 1, e])
                            {
                                mat[i, e]++;
                                mat[i + 1, e] = 0;
                                done = true;
                            }
                        }
                        freePos = new int[4];
                        point = pointUse = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[freePos[pointUse++], e] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = i;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    for (int i = 0; i < 4; i++)
                    {
                        int[] freePos = new int[4];
                        int point = 0, pointUse = 0;

                        for (int e = 3; e >= 0; --e)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = e;
                        }
                        for (int e = 3; e > 0; --e)
                        {
                            if (mat[i, e] == 0)
                                continue;
                            if (mat[i, e] == mat[i, e - 1])
                            {
                                mat[i, e]++;
                                mat[i, e - 1] = 0;
                                done = true;
                            }
                        }
                        freePos = new int[4];
                        point = pointUse = 0;
                        for (int e = 3; e >= 0; --e)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = e;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < 4; i++)
                    {
                        int[] freePos = new int[4];
                        int point = 0, pointUse = 0;

                        for (int e = 0; e < 4; e++)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = e;
                        }
                        for (int e = 0; e < 3; e++)
                        {
                            if (mat[i, e] == 0)
                                continue;
                            if (mat[i, e] == mat[i, e + 1])
                            {
                                mat[i, e]++;
                                mat[i, e + 1] = 0;
                                done = true;
                            }
                        }
                        freePos = new int[4];
                        point = pointUse = 0;
                        for (int e = 0; e < 4; e++)
                        {
                            if (mat[i, e] != 0 && point > pointUse)
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e];
                                mat[i, e] = 0;
                                done = true;
                            }
                            if (mat[i, e] == 0)
                                freePos[point++] = e;
                        }
                    }
                    break;
                default:
                    throw new Exception("The key is not valid");
            }
            return done;
        }

        static void Print(int[,] mat)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int e = 0; e < 4; e++)
                {
                    Console.Write($"{(mat[i, e] == 0? 0 : (1 << mat[i, e]))} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool IsLost(int[,] mat)
        {
            for (int i = 1; i < 3; i++)
            {
                for (int e = 1; e < 3; e++)
                {
                    if (mat[i, e] == mat[i, e + 1])
                        return false;
                    if (mat[i, e] == mat[i, e - 1])
                        return false;
                    if (mat[i, e] == mat[i + 1, e])
                        return false;
                    if (mat[i, e] == mat[i - 1, e])
                        return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[,] mat = new int[4, 4];
            GeneraNumero(mat);

            while (true)
            {
                Print(mat);
                ConsoleKey key;
                while ((key = LeggiTasto()) < ConsoleKey.LeftArrow || key > ConsoleKey.DownArrow)
                    continue;

                if (!MakeMove(mat, key))
                {
                    Console.Clear();
                    continue;
                }

                GeneraNumero(mat);

                if (IsLost(mat))
                    break;
                Console.Clear();
            }

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
