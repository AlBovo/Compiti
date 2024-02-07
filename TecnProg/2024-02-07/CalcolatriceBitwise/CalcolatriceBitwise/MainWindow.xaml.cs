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
            int total = 0;                                              // variabile di lavoro in cui verrà salvato il valore da ritornare
            for (int i = 0; i < value.Length; i++)
                total += (value[i] - '0') << (value.Length - i - 1);    // aumento il numero con l'effettivo bit alla sua posizione
            return total;
        }

        private string IntegerToBinaryString(int value)
        {
            value += 1 << 9;        // aggiungo 2^8 per poter avere il numero già paddato
            string s = "";          // dichiaro la variabile di lavoro in cui verrà salvato il risultato
            
            while(value > 0)        // effettuo la conversione finché value è valida
            {
                if (value % 2 == 0) // se il bit è 0
                    s = "0" + s;
                else
                    s = "1" + s;    // se il bit è 1

                value /= 2;         // divido per 2 e ripeto
            }

            return s.Substring(s.Length - 8, 8);    // prendo solo gli ultimi bit
        }
        #endregion

        #region Funzioni per diminuire di uno il valore di shift
        private void ShiftRightRow1(object sender, RoutedEventArgs e)
        {
            int number;                                         // dichiaro la variabile in cui verrà aggiornato il valore di shift
            if ((number = int.Parse(shiftTextBlock.Text)) == 0) // se è uguale al minimo (0) allora il valore non verrà aggiornato
                return;
            shiftTextBlock.Text = (number - 1).ToString();      // altrimenti verrà decrementato
        }

        private void ShiftRightRow2(object sender, RoutedEventArgs e)
        {
            int number;                                             // dichiaro la variabile in cui verrà aggiornato il valore di shift
            if ((number = int.Parse(shiftTextBlock_2.Text)) == 0)   // se è uguale al minimo (0) allora il valore non verrà aggiornato
                return;
            shiftTextBlock_2.Text = (number - 1).ToString();        // altrimenti verrà decrementato
        }
        #endregion

        #region Funzioni per diminuire di uno il valore di shift
        private void ShiftLeftRow1(object sender, RoutedEventArgs e)
        {
            int number;                                         // dichiaro la variabile in cui verrà aggiornato il valore di shift
            if ((number = int.Parse(shiftTextBlock.Text)) == 8) // se è uguale al massimo (8) allora il valore non verrà aggiornato
                return;
            shiftTextBlock.Text = (number + 1).ToString();      // altrimenti verrà incrementato
        }

        private void ShiftLeftRow2(object sender, RoutedEventArgs e)
        {
            int number;                                             // dichiaro la variabile in cui verrà aggiornato il valore di shift
            if ((number = int.Parse(shiftTextBlock_2.Text)) == 8)   // se è uguale al massimo (8) allora il valore non verrà aggiornato
                return;
            shiftTextBlock_2.Text = (number + 1).ToString();        // altrimenti verrà incrementato
        }
        #endregion

        #region Funzione per swappare la direzione dello shift
        private void SwapDirection(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;          // ottengo il bottone da con il relativo valore
            if (currentButton.Content.ToString() == "<-")   // se punta a destra swappo a sinistra
                currentButton.Content = "->";
            else
                currentButton.Content = "<-";               // altrimenti swappo a destra
        }
        #endregion

        #region Funzioni per aggiungere un uno nel numero binario
        private void AddDigitToFirstRow(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Content.ToString();                     // ottengo il valore da aggiungere al fondo del numero binario

            if (numberTextBox.Text.Length == 8)
                numberTextBox.Text = numberTextBox.Text.Substring(1, 7) + value;    // se log(num) >= 8 allora aggiungo al fondo il valore e prendo la sottostringa
            else
                numberTextBox.Text += value;                                        // altrimenti aggiungo semplicemente il valore
        }

        private void AddDigitToSecondRow(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Content.ToString();                     // ottengo il valore da aggiungere al fondo del numero binario

            if (numberTextBox_2.Text.Length == 8)                                   // se log(num) >= 8 allora aggiungo al fondo il valore e prendo la sottostringa
                numberTextBox_2.Text = numberTextBox_2.Text.Substring(1, 7) + value;
            else
                numberTextBox_2.Text += value;                                      // altrimenti aggiungo semplicemente il valore
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
