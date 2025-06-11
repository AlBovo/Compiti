/*********************************
* Alan Davide Bovo 3H 2024-01-30 *
*    Conversione numero-parola   *
*********************************/

using System;
using System.Windows;

namespace AppWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Costanti globali per il range valido
        const int MAX_NUMBER = 9999, MIN_NUMBER = 0; // range degli input elaborabili
        #endregion

        #region Funzione per convertire il numero in una parola
        private string ConvertNumberToString(string numberAsString, int number)
        {
            // Il numero deve essere nel range [MIN_NUMBER; MAX_NUMBER]
            if (number < MIN_NUMBER)
                throw new ArgumentException($"The number must be at least {MIN_NUMBER}");
            if (number > MAX_NUMBER)
                throw new ArgumentException($"The number can be at most {MAX_NUMBER}");
            
            string parola = "";

            #region Converto il numero in una parola
            if (numberAsString.Length >= 4)
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

            if (number == 0) parola = "zero";
            #endregion

            return parola;
        }
        #endregion

        #region Funzione per gestire l'evento click sul bottone
        private void bottoneSubmit_Click(object sender, RoutedEventArgs e)
        {
            string numero = numeroTextBox.Text;
            int numeroInt;

            try
            {
                numeroInt = int.Parse(numero); // converto da stringa a intero
                #region Reverso la stringa numero
                char[] nums = numero.ToCharArray();
                Array.Reverse(nums);
                numero = new string(nums);
                #endregion

                numeroOutput.Text = ConvertNumberToString(numero, numeroInt); // stampo il valore ottenuto
            }
            catch (FormatException) // Il numero inserito non è un numero valido
            {
                MessageBox.Show("The number entered is not valid, retry");
                numeroTextBox.Text = "";
            }
            catch (ArgumentException ex) // Il numero non è in un range valido
            {
                MessageBox.Show(ex.Message);
                numeroTextBox.Text = "";
            }
        }
        #endregion
    }
}
