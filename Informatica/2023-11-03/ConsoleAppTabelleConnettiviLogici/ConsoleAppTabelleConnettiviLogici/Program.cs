using System;

namespace ConsoleAppTabelleConnettiviLogici
{
    internal class Program
    {
        const int OP_NOT = 1;
        const int OP_AND = 2;
        const int OP_OR = 3;
        const int OP_XOR = 4;

        static string ConvertToBool(bool value)
        {
            if (!value) return "False";
            return "True";
        }

        static int readInt(string message)
        {
            bool inputOK;
            int input;
            string inputStr;

            do
            {
                Console.Write(message);
                inputStr = Console.ReadLine();
                inputOK = int.TryParse(inputStr, out input);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è valido, riprova ...");
                }
                else if(input < 0 || input > 4)
                {
                    Console.WriteLine("L'intero inserito non è valido, riprova ...");
                    inputOK = false;
                }
            } while (!inputOK);
            return input;
        }


        static void PrintTable(int operation)
        {
            switch(operation)
            {
                case OP_NOT:
                    Console.WriteLine("+---------------+---------------+");
                    Console.WriteLine("|\tA\t|\tNOT A\t|");
                    for(int i=0; i<2; i++)
                    { 
                        Console.WriteLine($"|\t{ConvertToBool(i == 1)}\t|\t{ConvertToBool(!(i == 1))}\t|");
                    }
                    Console.WriteLine("+---------------+---------------+");
                    break;

                case OP_AND:
                    Console.WriteLine("+---------------+---------------+---------------+");
                    Console.WriteLine("|\tA\t|\tB\t|\tA AND B\t|");
                    for (int i = 0; i < 2; i++)
                    {
                        for (int e = 0; e < 2; e++)
                        {
                            Console.WriteLine($"|\t{ConvertToBool(i == 1)}\t|\t{ConvertToBool(e == 1)}\t|\t{ConvertToBool((e == 1) && (i == 1))}\t|");
                        }
                    }
                    Console.WriteLine("+---------------+---------------+---------------+");
                    break;

                case OP_OR:
                    Console.WriteLine("+---------------+---------------+---------------+");
                    Console.WriteLine("|\tA\t|\tB\t|\tA OR B\t|");
                    for (int i = 0; i < 2; i++)
                    {
                        for (int e = 0; e < 2; e++)
                        {
                            Console.WriteLine($"|\t{ConvertToBool(i == 1)}\t|\t{ConvertToBool(e == 1)}\t|\t{ConvertToBool((e == 1) || (i == 1))}\t|");
                        }
                    }
                    Console.WriteLine("+---------------+---------------+---------------+");
                    break;

                case OP_XOR:
                    Console.WriteLine("+---------------+---------------+---------------+");
                    Console.WriteLine("|\tA\t|\tB\t|\tA XOR B\t|");
                    for (int i = 0; i < 2; i++)
                    {
                        for (int e = 0; e < 2; e++)
                        {
                            Console.WriteLine($"|\t{ConvertToBool(i == 1)}\t|\t{ConvertToBool(e == 1)}\t|\t{ConvertToBool((e == 1) != (i == 1))}\t|");
                        }
                    }
                    Console.WriteLine("+---------------+---------------+---------------+");
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                if(choice != -1)
                {
                    PrintTable(choice);
                }

                choice = readInt("Inserisci il numero di operazione da eseguire (0 per terminare): ");
            } while (choice != 0);

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
