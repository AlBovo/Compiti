using System;

namespace ConsoleApp_ConversioneDiBase
{
    internal class Program
    {
        public const string ALPHABET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // alfabeto utilizzato
        
        #region Metodo per convertire da base X a decimale
        static int BaseToInt(string input, int baseInput)
        {
            int length = input.Length, pos, risultato = 0;

            if (baseInput < 2 || baseInput > 36) // la base non è valida
            {
                Console.WriteLine("La base inserita non è valida, riprova ...");
                return -1;
            }

            if (length == 0) // la stringa è vuota quindi non valida
            {
                Console.WriteLine("La stringa di input è vuota, riprova ...");
                return -1;
            }

            #region Conversione cercando i valori nell'alfabeto
            for (int i = 0; i < length; i++)
            {
                pos = ALPHABET.IndexOf(input[i]);

                if (pos == -1) // la stringa da convertire non è base valida
                {
                    Console.WriteLine($"L'input inserito non è in base {baseInput}, riprova ...");
                    return -1;
                }

                risultato += pos * (int)Math.Pow(baseInput, length - i - 1);
            }
            #endregion

            return risultato;
        }
        #endregion

        #region Metodo per convertire da decimale a base X
        static string IntToBase(int input, int baseInput)
        {
            int resto;
            string valore = "";

            if (baseInput < 2 || baseInput > 36) // base non valida
            {
                Console.WriteLine("La base inserita non è valida, riprova ...");
                return "";
            }

            if (input < 0) // input non valido
            {
                Console.WriteLine("L'input inserito non può essere negativo, riprova ...");
                return "";
            }

            #region Conversione con il divisioni successive
            while (input > 0)
            {
                resto = input % baseInput;
                input /= baseInput;
                valore = ALPHABET[resto] + valore;
            }
            #endregion

            return valore;
        }
        #endregion

        #region Metodo per leggere un intero
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
        #endregion

        static void Main(string[] args)
        {
            char choice;

            #region Ciclo per chiedere l'input all'utente
            do
            {
                #region Richiesta dell'azione da eseguire
                Console.Write("Vuoi convertire ad una base o a un intero? (b/i/f per finire): ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                #endregion

                switch (choice)
                {
                    #region Conversione da decimale a base X
                    case 'b':
                        int value = readInt("Inserisci il valore decimale: ");
                        int baseInput = readInt("Inserisci la base del valore: ");
                        Console.WriteLine($"Il valore convertito a base {baseInput} è {IntToBase(value, baseInput)}");
                        break;
                    #endregion

                    #region Conversione da base X a decimale
                    case 'i':
                        Console.Write("Inserisci la stringa da convertire a base 10: ");
                        string valueString = Console.ReadLine().ToUpper();
                        baseInput = readInt("Inserisci la base della stringa: ");
                        Console.WriteLine($"La stringa in base {baseInput} convertita ad intero equivale a {BaseToInt(valueString, baseInput)}");
                        break;
                    #endregion

                    #region Uscita dal programma
                    case 'f':
                        break;
                    #endregion

                    #region L'input inserito non è valido
                    default:
                        Console.WriteLine("La scelta non è valida, riprova ...");
                        break;
                    #endregion
                }

            } while (choice != 'f');
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
