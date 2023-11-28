namespace ConsoleAppOrdineCrescente
{
    internal class Program
    {
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
            } while (!inputOK);
            return input;
        }

        static void Main(string[] args)
        {
            int a = readInt("Inserisci il primo numero: ");
            int b = readInt("Inserisci il secondo numero: ");
            int c = readInt("Inserisci il terzo numero: ");
            int d = 0;

            if(a > b)
            {
                d = a;
                a = b;
                b = d;
            } 

            if(b > c)
            {
                d = b;
                b = c;
                c = d;

                if (a > b)
                {
                    d = a;
                    a = b;
                    b = d;
                }
            }

            Console.WriteLine($"{a} {b} {c}");
        }
    }
}