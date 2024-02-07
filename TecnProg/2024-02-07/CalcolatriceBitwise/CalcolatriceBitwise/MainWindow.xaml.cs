/*********************************
* Alan Davide Bovo 3H 2024-02-06 *
*      Calcolatrice Bitwise      *
*********************************/

using System.Windows;
using System.Windows.Controls;

namespace CalcolatriceBitwise
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Funzioni per convertire da binario a decimale e viceversa
        private int BinaryStringToInteger(string value)
        {
            int total = 0;
            for (int i = 0; i < value.Length; i++)
            {
                total += (value[i] - '0') << (value.Length - i - 1);
            }
            return total;
        }

        private string IntegerToBinaryString(int value)
        {
            value += 1 << 9;
            string s = "";
            while(value > 0)
            {
                if (value % 2 == 0)
                    s = "0" + s;
                else
                    s = "1" + s;

                value /= 2;
            }

            if (s.Length > 8)
                return s.Substring(s.Length - 8, 8);
            else
                return s;
        }
        #endregion

        #region Funzioni per diminuire di uno il valore di shift
        private void ShiftRightRow1(object sender, RoutedEventArgs e)
        {
            int number;
            if ((number = int.Parse(shiftTextBlock.Text)) == 0)
                return;
            shiftTextBlock.Text = (number - 1).ToString();
        }

        private void ShiftRightRow2(object sender, RoutedEventArgs e)
        {
            int number;
            if ((number = int.Parse(shiftTextBlock_2.Text)) == 0)
                return;
            shiftTextBlock_2.Text = (number - 1).ToString();
        }
        #endregion

        #region Funzioni per diminuire di uno il valore di shift
        private void ShiftLeftRow1(object sender, RoutedEventArgs e)
        {
            int number;
            if ((number = int.Parse(shiftTextBlock.Text)) == 8)
                return;
            shiftTextBlock.Text = (number + 1).ToString();
        }

        private void ShiftLeftRow2(object sender, RoutedEventArgs e)
        {
            int number;
            if ((number = int.Parse(shiftTextBlock_2.Text)) == 8)
                return;
            shiftTextBlock_2.Text = (number + 1).ToString();
        }
        #endregion

        #region Funzione per swappare la direzione dello shift
        private void SwapDirection(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;
            if(currentButton.Content.ToString() == "<-")
            {
                currentButton.Content = "->";
            }
            else
            {
                currentButton.Content = "<-";
            }
        }
        #endregion

        #region Funzioni per aggiungere un uno nel numero binario
        private void AddDigitToFirstRow(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Content.ToString();

            if (numberTextBox.Text.Length == 8)
                numberTextBox.Text = numberTextBox.Text.Substring(1, 7) + value;
            else
                numberTextBox.Text += value;
        }

        private void AddDigitToSecondRow(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Content.ToString();

            if (numberTextBox_2.Text.Length == 8)
                numberTextBox_2.Text = numberTextBox_2.Text.Substring(1, 7) + value;
            else
                numberTextBox_2.Text += value;
        }
        #endregion

        #region Funzioni per calcolare il not del numero della textbox relativa
        private void NotFirstRow(object sender, RoutedEventArgs e)
        {
            int value = BinaryStringToInteger(numberTextBox.Text);      // lettura del valore nella prima riga
            value = ~value;                                             // calcolo del not del valore
            value &= (1 << 9) - 1;                                      // applico la bitmask sul valore escludendo i bit non necessari
            numberTextBox.Text = IntegerToBinaryString(value);          // aggiornamento del valore nel textblock
        }

        private void NotSecondRow(object sender, RoutedEventArgs e)
        {
            int value = BinaryStringToInteger(numberTextBox_2.Text);    // lettura del valore nella prima riga
            value = ~value;                                             // calcolo del not del valore
            value &= (1 << 9) - 1;                                      // applico la bitmask sul valore escludendo i bit non necessari
            numberTextBox_2.Text = IntegerToBinaryString(value);        // aggiornamento del valore nel textblock
        }
        #endregion

        #region Funzioni per calcolare lo shift del numero
        private void ShiftFirstRow(object sender, RoutedEventArgs e)
        {
            int integer = BinaryStringToInteger(numberTextBox.Text);    // lettura del valore nella prima riga
            if (shiftDirection.Content.ToString() == "<-")              // se lo shift necessario è verso destra
                integer <<= int.Parse(shiftTextBlock.Text);             // modifica del valore shiftandolo a destra
            else
                integer >>= int.Parse(shiftTextBlock.Text);             // modifica del valore shiftandolo a sinistra

            numberTextBox.Text = IntegerToBinaryString(integer);        // aggiornamento del valore nel textblock
        }

        private void ShiftSecondRow(object sender, RoutedEventArgs e)
        {
            int integer = BinaryStringToInteger(numberTextBox_2.Text);  // lettura del valore nella seconda riga
            if (shiftDirection_2.Content.ToString() == "<-")            // se lo shift necessario è verso destra
                integer <<= int.Parse(shiftTextBlock_2.Text);           // modifica del valore shiftandolo a destra
            else
                integer >>= int.Parse(shiftTextBlock_2.Text);           // modifica del valore shiftandolo a sinistra

            numberTextBox_2.Text = IntegerToBinaryString(integer);      // aggiornamento del valore nel textblock
        }
        #endregion

        #region Funzione per calcolare l'operazione bitwise richiesta
        private void CalculateBitwiseOperation(object sender, RoutedEventArgs e)
        {
            int firstValue = BinaryStringToInteger(numberTextBox.Text);     // lettura del valore nella prima riga
            int secondValue = BinaryStringToInteger(numberTextBox_2.Text);  // lettura del valore nella seconda riga


            switch (((Button)sender).Content.ToString())
            {
                case "AND": // il bottone cliccato è l'and
                    resultTextBlock.Text = IntegerToBinaryString(firstValue & secondValue);
                    break;

                case "OR":  // il bottone cliccato è l'or
                    resultTextBlock.Text = IntegerToBinaryString(firstValue | secondValue);
                    break;

                case "XOR": // il bottone cliccato è lo xor
                    resultTextBlock.Text = IntegerToBinaryString(firstValue ^ secondValue);
                    break;
            }
        }
        #endregion
    }
}
