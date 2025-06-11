/**********************************
 * Alan Davide Bovo 3H 2023-09-26 *
 *     Programma per 7 digits     *
 *********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppDigit7Segments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-09-26";

            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine("| Digit display with 7 segments |");
            Console.WriteLine("└───────────────────────────────┘\n");

            Console.Beep(4000, 500);

            Console.WriteLine("     ██████████████        "); // print del numero 9
            Console.WriteLine("   ██              ██      "); // come ascii art
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("   ██              ██      ");
            Console.WriteLine("     ██████████████        ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("                   ██      ");
            Console.WriteLine("     ██████████████      \n");

            Console.CursorVisible = false;

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            // Print di 8
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("██");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            // Print di 7
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("  ");
            }

            Console.SetCursorPosition(4, 20);
            Console.WriteLine("                          ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 5 + i);
                Console.Write("  ");
            }
            Console.Write("\n                          ");

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            // Print di 6
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 5 + i);
                Console.Write("██");
            }

            Console.Write("\n     ██████████████      ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("██");
            }

            Console.SetCursorPosition(5, 20);
            Console.WriteLine("██████████████      ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(19, 5 + i);
                Console.Write("  ");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 5
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("  ");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 4
            Console.SetCursorPosition(5, 20);
            Console.WriteLine("                      ");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("                      ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(19, 5 + i);
                Console.Write("██");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 3
            Console.SetCursorPosition(5, 20);
            Console.WriteLine("██████████████      ");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("██████████████      ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 5 + i);
                Console.Write("  ");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 2
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(19, 13 + i);
                Console.Write("  ");
            }

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("██");
            }

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 1
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(19, 13 + i);
                Console.Write("██");
            }
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("  ");
            }

            Console.SetCursorPosition(5, 20);
            Console.WriteLine("                      ");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("                      ");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("                      ");

            Thread.Sleep(500);
            Console.Beep(4000, 500);
            // Print di 0
            Console.SetCursorPosition(5, 20);
            Console.WriteLine("██████████████      ");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("██████████████      ");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 5 + i);
                Console.Write("██");
            }

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(3, 13 + i);
                Console.Write("██");
            }

            // Fine
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(250);
                Console.Beep(4000, 500);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 8);
            Console.CursorVisible = true; // rimetto il cursore
            Console.Write("\nPremi un tasto per terminare il programma... ");
            Console.ReadKey();
        }
    }
}
