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
    }
}
