/*********************************
* Alan Davide Bovo 3H 2023-01-23 *
*          Gioco di 2048         *
*********************************/
using System;

namespace _2048
{
    internal class Program
    {
        #region Variabili globali per la generazione di numeri casuali e per i colori dei numeri
        static Random rnd = new Random();                           // generatore di numeri casuali
        static ConsoleColor[] colors = new ConsoleColor[]           // array di colori
        { 
            ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Yellow 
        };
        static ConsoleColor[] numberColors = new ConsoleColor[]     // array di colori per i numeri
        {
            ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Yellow,
            ConsoleColor.Cyan, ConsoleColor.DarkRed, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow
        };
        #endregion

        #region Funzione per leggere un tasto con input non bloccante
        static ConsoleKey LeggiTasto()
        {
            while (!Console.KeyAvailable) // continuo finchè non è disponibile un tasto
                continue;

            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.Key;
        }
        #endregion

        #region Funzione per generare un numero in una posizione casuale
        static void GeneraNumero(int[,] mat)
        {
            int x = rnd.Next(4);
            int y = rnd.Next(4);
            while (mat[x, y] != 0) // continuo finchè non trovo una posizione vuota
            {
                x = rnd.Next(4);
                y = rnd.Next(4);
            }

            mat[x, y] = (rnd.Next(0, 10) >= 8 ? 2 : 1);
        }
        #endregion

        #region Funzione per controllare se è possibile fare un movimento ed eventualmente farlo
        static bool MakeMove(int[,] mat, ConsoleKey key, ref long punteggio)
        {
            bool done = false; // variabile per controllare se è stato fatto un movimento
            switch(key)
            {
                case ConsoleKey.DownArrow: // shifto tutti i numeri verso il basso
                    for (int e = 0; e < 4; e++)
                    {
                        int[] freePos = new int[4];     // array per salvarmi i posti vuoti di una colonna
                        int point = 0, pointUse = 0;    // variabili per gestire l'array

                        for (int i = 3; i >= 0; --i)
                        {
                            if (mat[i, e] != 0 && point > pointUse) // se ho un numero e ho un posto vuoto
                            {
                                mat[freePos[pointUse++], e] = mat[i, e]; // sposto il numero
                                mat[i, e] = 0;                          // azzero la posizione precedente
                                done = true;                            // ho fatto un movimento
                            }
                            if(mat[i, e] == 0)                          // se ho un posto vuoto
                                freePos[point++] = i;
                        }
                        for (int i = 3; i > 0; --i)
                        {
                            if (mat[i, e] == 0)     // se ho un posto vuoto
                                continue;
                            if (mat[i, e] == mat[i - 1, e]) // se ho due numeri uguali
                            {
                                mat[i, e]++;            // incremento il numero
                                punteggio += 1 << mat[i, e]; // aggiorno il punteggio
                                mat[i - 1, e] = 0;      // azzero la posizione precedente
                                done = true;            // ho fatto un movimento
                            }
                        }

                        // ripeto per aggiornare in caso di somma
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
                case ConsoleKey.UpArrow: // shifto tutti i numeri verso l'alto
                    for (int e = 0; e < 4; e++)
                    {
                        int[] freePos = new int[4];     // array per salvarmi i posti vuoti di una colonna
                        int point = 0, pointUse = 0;    // variabili per gestire l'array

                        for (int i = 0; i < 4; i++)
                        {
                            if (mat[i, e] != 0 && point > pointUse) // se ho un numero e ho un posto vuoto
                            {
                                mat[freePos[pointUse++], e] = mat[i, e]; // sposto il numero
                                mat[i, e] = 0;                          // azzero la posizione precedente
                                done = true;                            // ho fatto un movimento
                            }
                            if (mat[i, e] == 0)                         // se ho un posto vuoto
                                freePos[point++] = i;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            if (mat[i, e] == 0)    // se ho un posto vuoto
                                continue;
                            if (mat[i, e] == mat[i + 1, e]) // se ho due numeri uguali
                            {
                                mat[i, e]++;                // incremento il numero
                                punteggio += 1 << mat[i, e]; // aggiorno il punteggio
                                mat[i + 1, e] = 0;          // azzero la posizione precedente
                                done = true;                // ho fatto un movimento
                            }
                        }

                        // ripeto per aggiornare in caso di somma
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
                case ConsoleKey.RightArrow: // shifto tutti i numeri verso destra
                    for (int i = 0; i < 4; i++)
                    {
                        int[] freePos = new int[4];         // array per salvarmi i posti vuoti di una riga
                        int point = 0, pointUse = 0;        // variabili per gestire l'array

                        for (int e = 3; e >= 0; --e)
                        {
                            if (mat[i, e] != 0 && point > pointUse) // se ho un numero e ho un posto vuoto
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e]; // sposto il numero
                                mat[i, e] = 0;                          // azzero la posizione precedente
                                done = true;                            // ho fatto un movimento
                            }
                            if (mat[i, e] == 0)                         // se ho un posto vuoto
                                freePos[point++] = e;
                        }
                        for (int e = 3; e > 0; --e)
                        {
                            if (mat[i, e] == 0) // se ho un posto vuoto
                                continue;
                            if (mat[i, e] == mat[i, e - 1]) // se ho due numeri uguali
                            {
                                mat[i, e]++;                // incremento il numero
                                punteggio += 1 << mat[i, e]; // aggiorno il punteggio
                                mat[i, e - 1] = 0;          // azzero la posizione precedente
                                done = true;                // ho fatto un movimento
                            }
                        }

                        // ripeto per aggiornare in caso di somma
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
                case ConsoleKey.LeftArrow:  // shifto tutti i numeri verso sinistra
                    for (int i = 0; i < 4; i++)
                    {
                        int[] freePos = new int[4];     // array per salvarmi i posti vuoti di una riga
                        int point = 0, pointUse = 0;    // variabili per gestire l'array

                        for (int e = 0; e < 4; e++)
                        {
                            if (mat[i, e] != 0 && point > pointUse)     // se ho un numero e ho un posto vuoto
                            {
                                mat[i, freePos[pointUse++]] = mat[i, e]; // sposto il numero
                                mat[i, e] = 0;                          // azzero la posizione precedente
                                done = true;                            // ho fatto un movimento
                            }
                            if (mat[i, e] == 0)                         // se ho un posto vuoto
                                freePos[point++] = e;
                        }
                        for (int e = 0; e < 3; e++)
                        {
                            if (mat[i, e] == 0) // se ho un posto vuoto
                                continue;
                            if (mat[i, e] == mat[i, e + 1]) // se ho due numeri uguali
                            {
                                mat[i, e]++;                // incremento il numero
                                punteggio += 1 << mat[i, e]; // aggiorno il punteggio
                                mat[i, e + 1] = 0;          // azzero la posizione precedente
                                done = true;                // ho fatto un movimento
                            }
                        }

                        // ripeto per aggiornare in caso di somma
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
                default: // non dovrebbe mai succedere (nel caso lo metto)
                    throw new Exception("The key is not valid"); // se il tasto non è valido lancio un'eccezione
            }
            return done;
        }
        #endregion

        #region Funzione per scrivere 2048 in ascii art con colore randomico
        static void PrintMenu()
        {
            Console.WriteLine("\t+----------------------+\n" +
                              "\t|  Benvenuto in 2048!  |\n" +
                              "\t+----------------------+");
            Console.ForegroundColor = colors[rnd.Next(0, colors.Length)];  // imposto un colore a caso
            Console.WriteLine(@"  $$$$$$\   $$$$$$\  $$\   $$\  $$$$$$\  " + "\n" +
                              @" $$  __$$\ $$$ __$$\ $$ |  $$ |$$  __$$\ " + "\n" +
                              @" \__/  $$ |$$$$\ $$ |$$ |  $$ |$$ /  $$ |" + "\n" +
                              @"  $$$$$$  |$$\$$\$$ |$$$$$$$$ | $$$$$$  |" + "\n" +
                              @" $$  ____/ $$ \$$$$ |\_____$$ |$$  __$$< " + "\n" +
                              @" $$ |      $$ |\$$$ |      $$ |$$ /  $$ |" + "\n" +
                              @" $$$$$$$$\ \$$$$$$  /      $$ |\$$$$$$  |" + "\n" +
                              @" \________| \______/       \__| \______/ " + "\n");
            Console.ForegroundColor = ConsoleColor.White; // reimposto il colore bianco
        }
        #endregion

        #region Funzione per stampare la griglia
        static void PrintGrid(int[,] mat)
        {
            const int righeScritte = 12; // numero di righe scritte prima della griglia

            // stampo la griglia
            Console.WriteLine("+--------+--------+--------+--------+");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("+--------+--------+--------+--------+");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("+--------+--------+--------+--------+");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("+--------+--------+--------+--------+");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("|        |        |        |        |");
            Console.WriteLine("+--------+--------+--------+--------+");

            for (int i = 0; i < 4; i++)
            {
                for (int e = 0; e < 4; e++)
                {
                    if (mat[i, e] == 0) continue;
                    Console.ForegroundColor = numberColors[mat[i, e] - 1];

                    switch (mat[i, e].ToString().Length)
                    {
                        case 1:
                            Console.SetCursorPosition(9 * e + 4, 4 * i + 2 + righeScritte); // imposto la posizione del cursore per un numero ad una cifra
                            Console.Write(1 << mat[i, e]);
                            break;

                        case 2:
                            Console.SetCursorPosition(9 * e + 4, 4 * i + 2 + righeScritte); // imposto la posizione del cursore per un numero a due cifre
                            Console.Write(1 << mat[i, e]);
                            break;

                        case 3:
                            Console.SetCursorPosition(9 * e + 4, 4 * i + 2 + righeScritte); // imposto la posizione del cursore per un numero a tre cifre
                            Console.Write(1 << mat[i, e]);
                            break;

                        case 4:
                            Console.SetCursorPosition(9 * e + 4, 4 * i + 2 + righeScritte); // imposto la posizione del cursore per un numero a quattro cifre
                            Console.Write(1 << mat[i, e]);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.SetCursorPosition(0, righeScritte + 4 * 4 + 1); // imposto la posizione del cursore dopo la griglia
            Console.WriteLine();
        }
        #endregion

        #region Funzione per controllare se è possibile fare un movimento
        static bool IsLost(int[,] mat)
        {
            /*
             * Questo codice fa palesemnte schifo ma non ho tempo per farlo meglio
             */

            // controllo se è possibile fare un movimento al centro della griglia
            for (int i = 1; i < 3; i++)
            {
                for (int e = 1; e < 3; e++)
                {
                    if (mat[i, e] == mat[i, e + 1] || mat[i, e + 1] == 0)
                        return false;
                    if (mat[i, e] == mat[i, e - 1] || mat[i, e - 1] == 0)
                        return false;
                    if (mat[i, e] == mat[i + 1, e] || mat[i + 1, e] == 0)
                        return false;
                    if (mat[i, e] == mat[i - 1, e] || mat[i - 1, e] == 0)
                        return false;
                }
            }

            int[] vals = { 0, 3 };

            // controllo se è possibile fare un movimento ai bordi della griglia (sinistra, destra)
            foreach(int e in vals)
            {
                for (int i = 1; i < 3; i++)
                {
                    if (mat[i, e] == mat[i + 1, e] || mat[i + 1, e] == 0)
                        return false;
                    if (mat[i, e] == mat[i - 1, e] || mat[i - 1, e] == 0)
                        return false;
                }
            }

            // controllo se è possibile fare un movimento ai bordi della griglia (alto, basso)
            foreach (int i in vals)
            {
                for (int e = 1; e < 3; e++)
                {
                    if (mat[i, e] == mat[i, e + 1] || mat[i, e + 1] == 0)
                        return false;
                    if (mat[i, e] == mat[i, e - 1] || mat[i, e - 1] == 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

        static void Main(string[] args)
        {
            int[,] mat = new int[4, 4]; // matrice di gioco
            long punteggio = 0;         // variabile per contare il punteggio
            GeneraNumero(mat);          // imposto il primo numero della griglia 

            while (true)
            {
                PrintMenu();            // stampo il menu
                Console.WriteLine($"Punteggio: {punteggio}");
                PrintGrid(mat);         // stampo la griglia di gioco
                ConsoleKey key;
                while ((key = LeggiTasto()) < ConsoleKey.LeftArrow || key > ConsoleKey.DownArrow)
                    continue;           // leggo un tasto finchè non è una freccia

                if (!MakeMove(mat, key, ref punteggio)) // controllo se è possibile fare un movimento
                {
                    Console.Clear();
                    continue;
                }

                GeneraNumero(mat);      // genero un nuovo numero

                if (IsLost(mat))        // controllo se è possibile fare un movimento
                    break;

                Console.Clear();
            }

            #region Stampo un'ultima volta la griglia
            Console.Clear();
            PrintMenu();
            PrintGrid(mat);
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
