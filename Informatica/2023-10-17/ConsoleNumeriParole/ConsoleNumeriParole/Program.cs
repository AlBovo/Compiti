/*********************************
* Alan Davide Bovo 3H 2023-10-17 *
*       Da numero a parole       *
*********************************/

using System;

namespace ConsoleNumeriParole
{
    internal class Program
    {
        const int MAX_NUMBER = 9999, MIN_NUMBER = 0; // range degli input elaborabili
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            int number;
            char[] numberAsString;
            string parola = "";
            bool inputOK;
            #endregion

            Console.Title = "Alan Davide Bovo 3H 2023-10-17";
            Console.WriteLine("Alan Davide Bovo 3H 2023-10-17");

            #region Lettura del numero e conversione a stringa
            do
            {
                Console.Write($"Enter the number to convert to words (from {MIN_NUMBER} to {MAX_NUMBER}): ");
                parola = Console.ReadLine();
                inputOK = int.TryParse(parola, out number);

                if (!inputOK)
                {
                    Console.WriteLine("The input entered is not an integer, try again ...");
                }
                else if(number > MAX_NUMBER || number < MIN_NUMBER) // input fuori dal range
                {
                    inputOK = false;
                    Console.WriteLine($"The number entered is not in the range from {MIN_NUMBER} to {MAX_NUMBER}, try again...");
                }
            } while (!inputOK);
            numberAsString = number.ToString().ToCharArray();
            Array.Reverse(numberAsString);
            parola = "";
            #endregion

            if(numberAsString.Length >= 4)
            {
                #region Calcolo delle migliaia
                switch (numberAsString[3])
                {
                    case '1':
                        parola = "one thousand";
                        break;
                    case '2':
                        parola = "two thousand";
                        break;
                    case '3':
                        parola = "three thousand";
                        break;
                    case '4':
                        parola = "four thousand";
                        break;
                    case '5':
                        parola = "five thousand";
                        break;
                    case '6':
                        parola = "six thousand";
                        break;
                    case '7':
                        parola = "seven thousand";
                        break;
                    case '8':
                        parola = "eight thousand";
                        break;
                    case '9':
                        parola = "nine thousand";
                        break;
                }
                #endregion
            }
            if (numberAsString.Length >= 3)
            {
                #region Calcolo delle centinaia
                switch (numberAsString[2])
                {
                    case '1':
                        parola += " one hundred";
                        break;
                    case '2':
                        parola += " two hundred";
                        break;
                    case '3':
                        parola += " three hundred";
                        break;
                    case '4':
                        parola += " four hundred";
                        break;
                    case '5':
                        parola += " five hundred";
                        break;
                    case '6':
                        parola += " six hundred";
                        break;
                    case '7':
                        parola += " seven hundred";
                        break;
                    case '8':
                        parola += " eight hundred";
                        break;
                    case '9':
                        parola += " nine hundred";
                        break;
                }
                #endregion
            }
            if ((number % 100) > 10 && (number % 100) < 20)
            {
                #region Calcolo del numero se è tra 19 e 11
                switch (number % 100)
                {
                    case 11:
                        parola += " eleven";
                        break;
                    case 12:
                        parola += " twelve";
                        break;
                    case 13:
                        parola += " thirteen";
                        break;
                    case 14:
                        parola += " fourteen";
                        break;
                    case 15:
                        parola += " fifteen";
                        break;
                    case 16:
                        parola += " sixteen";
                        break;
                    case 17:
                        parola += " seventeen";
                        break;
                    case 18:
                        parola += " eighteen";
                        break;
                    case 19:
                        parola += " nineteen";
                        break;
                }
                #endregion
            }
            else
            {
                if (numberAsString.Length >= 2)
                {
                    #region Calcolo delle decine se non sono tra 19 e 11
                    switch (numberAsString[1])
                    {
                        case '1':
                            parola += " ten";
                            break;
                        case '2':
                            parola += " twenty";
                            break;
                        case '3':
                            parola += " thirty";
                            break;
                        case '4':
                            parola += " fourty";
                            break;
                        case '5':
                            parola += " fifty";
                            break;
                        case '6':
                            parola += " sixsty";
                            break;
                        case '7':
                            parola += " seventy";
                            break;
                        case '8':
                            parola += " eighty";
                            break;
                        case '9':
                            parola += " ninty";
                            break;
                    }
                    #endregion
                }
                if (numberAsString.Length >= 1)
                {
                    #region Calcolo delle unità se non sono tra 19 e 11
                    switch (numberAsString[0])
                    {
                        case '1':
                            parola += " one";
                            break;
                        case '2':
                            parola += " two";
                            break;
                        case '3':
                            parola += " three";
                            break;
                        case '4':
                            parola += " four";
                            break;
                        case '5':
                            parola += " five";
                            break;
                        case '6':
                            parola += " six";
                            break;
                        case '7':
                            parola += " seven";
                            break;
                        case '8':
                            parola += " eight";
                            break;
                        case '9':
                            parola += " nine";
                            break;
                    }
                    #endregion
                }
            }
            Console.WriteLine("The number as word is: " + parola.Trim());

            Console.Write("Press a button to stop the program ... ");
            Console.ReadKey();
        }
    }
}
