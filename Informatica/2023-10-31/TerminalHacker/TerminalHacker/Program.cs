namespace TerminalHacker
{
    internal class Program
    {
        private static string[] TERMINAL =
        {
            "                                                                                               \n",
            "    DATANET PROC RECORD:  45-3456-W-3452                                  Transnet on/xc-3     \n",
            "                                                                                               \n",
            "                                  FEDERAL RESERVE TRANSFER NODE                                \n",
            "                                     National Headquarters                                     \n",
            "                                                                                               \n",
            "   ************************** Remote Systems Network Input Station *************************   \n",
            "   =========================================================================================   \n",
            "                                                                                               \n",
            "        [1] Interbank Funds Transfer   (Code Prog: 485-GWU)                                    \n",
            "        [2] International Telelink Access   (Code Lim: XRP-262)                                \n",
            "        [3] Remote Facsimile Send/Receive   (Code Tran: 2LZP-517)                              \n",
            "        [4] Regional Bank Interconnect   (Security Code: 47-B34)                               \n",
            "        [5] Update System Parameters   (Entry Auth. Req.)                                      \n",
            "        [6] Remote Operator Logon/Logoff                                                       \n",
            "                                                                                               \n",
            "   =========================================================================================   \n",
            "                                                                                               \n",
            "                              [ ] Select Option or ESC to Abort                                \n"
        };

        static void Main(string[] args)
        {
            char[][] copyTerminal = new char[TERMINAL.Length][];
            bool[][] isPrinted = new bool[TERMINAL.Length][];
            for (int i = 0; i < TERMINAL.Length; i++)
            {
                copyTerminal[i] = TERMINAL[i].ToCharArray();
                isPrinted[i] = new bool[TERMINAL[i].Length];
            }

            bool toContinue = true, printChar;
            Random rand = new Random();
            Console.CursorVisible = false;

            while (toContinue)
            {
                toContinue = false;
                for (int i = 0; i < copyTerminal.Length; i++)
                {
                    for (int j = 0; j < copyTerminal[i].Length; j++)
                    {
                        if (copyTerminal[i][j] == ' ' || copyTerminal[i][j] == '\n' || isPrinted[i][j])
                        {
                            (int, int) pos = Console.GetCursorPosition();
                            if (copyTerminal[i][j] == '\n')
                            {
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.SetCursorPosition(pos.Item1 + 1, pos.Item2);
                            }
                            continue;
                        }

                        printChar = rand.Next(0, 10) == 1;

                        if (printChar)
                        {
                            copyTerminal[i][j] = TERMINAL[i][j];
                            Console.ForegroundColor = ConsoleColor.Blue;
                            isPrinted[i][j] = true;
                        }
                        else
                        {
                            toContinue = true;
                            Console.ForegroundColor = ConsoleColor.White;
                            copyTerminal[i][j] = (char)rand.Next(33, 255);
                        }
                        Console.Write(copyTerminal[i][j]);
                    }
                }
                Thread.Sleep(5);
                Console.SetCursorPosition(0, 0);
            }

            Console.Beep(3000, 500);
            Console.CursorVisible = true;
            Console.SetCursorPosition(31, 18);
            Console.ReadKey();
        }
    }
}