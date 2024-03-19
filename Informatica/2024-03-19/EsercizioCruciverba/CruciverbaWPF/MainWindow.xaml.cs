/*********************************
* Alan Davide Bovo 3H 2024-03-12 *
*   Applicazione WPF Cruciverba  *
*********************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CruciverbaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static public Random rand = new Random();                       // Generatore random per i colori
        static public Button[,] buttons;                                // Matrice dei bottoni relativi ad ogni carattere
        static public List<List<char>> chars = new List<List<char>>();  // Lista dei caratteri della griglia
        static private SolidColorBrush choseColor;                      // Colore scelto per colorare la parola corrente

        private SolidColorBrush RandomColor()
        {
            int count = typeof(Brushes).GetProperties().Length;         // Prendo la lunghezza dell'enum
            int index = rand.Next(0, count);                            // Scelgo un indice casuale nel range della lunghezza
            var brushProperty = typeof(Brushes).GetProperties()[index]; // Prendo un colore random dall'enum
            return (SolidColorBrush)brushProperty.GetValue(null)!;      // Restituisco il colore
        }

        /// <summary>
        /// Function to find a word in a specific coordinate
        /// </summary>
        private bool FindWord(int x, int y, string toFind)
        {
            string temp = ""; // variabile in cui calcolo la parola trovata fino ad ora
            for (int i = y, e = x; i >= 0 && e >= 0; i--, e--) // alto sinistra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind)  // se la parola coincide con la toFind allora ho finito
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i++].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; e >= 0; e--) // alto
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind)  // se la parola coincide con la toFind allora ho finito
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count && e >= 0; i++, e--) // alto destra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i--].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0; i--) // sinistra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e, i++].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count; i++) // destra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e, i--].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0 && e < chars.Count; i--, e++) // giù sinistra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i++].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; e < chars.Count; e++) // giù
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count && e < chars.Count; i++, e++) // giù destra
            {
                temp += chars[e][i]; // aggiungo la lettera alla stringa
                if (temp == toFind) // aggiungo la lettera alla stringa
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i--].Background = choseColor; // imposto il colore ritornando indietro nell'iterazione
                    return true; // ho trovato la parola
                }
            }
            return false;
        }

        /// <summary>
        /// Function to read from a file the data of the puzzle
        /// </summary>
        private void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path)) // apro il file contenente le parole ed i caratteri
            {
                string line = sr.ReadLine()!;       // leggo la prima riga
                int i = 0;
                while (line != "")                  // finchè esiste una riga da leggere
                {
                    chars.Add(new List<char>());    // Aggiungo una riga alla matrice
                    foreach (char c in line)        // Per ogni carattere nella linea
                        chars[i].Add(c);            // Aggiungo nella matrice alla riga corrente il carattere su cui sto iterando
                    line = sr.ReadLine()!;          // leggo una nuova linea
                    i++;                            // aumento il counter della riga corrente
                }

                line = sr.ReadLine()!;              // leggo la prima riga delle parole
                while (line != null)                // finchè esiste una riga
                {
                    comboBox.Items.Add(line);       // aggiungo nella UI la parola appena letta
                    line = sr.ReadLine()!;          // leggo una nuova parola
                }
                sr.Close(); // chiudo il file
            }
        }

        /// <summary>
        /// Function to initialize all the variables
        /// </summary>
        private void Start(object sender, RoutedEventArgs e)
        {
            gridwin.Children.Clear();   // pulisco lo stato corrente della matrice dei bottoni
            chars.Clear();              // pulisco la matrice
            comboBox.Items.Clear();     // pulisco la lista delle parole utilizzabili
            comboBox.IsEnabled = true;  // abilito la scelta di una parola

            try
            {
                ReadFile(@"..\..\..\dati.txt"); // inizializzo tutte le variabili leggendo i dati dal file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in reading file"); // sono un coglione
            }

            buttons = new Button[chars.Count, chars[0].Count];  // inizializzo la matrice dei bottoni

            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = 0; j < chars[i].Count; j++)
                {
                    Button b = new Button();    // creo un oggetto bottone
                    b.Height = 30;              // gli assegno delle proprietà visive
                    b.Width = 30;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(j * 30, i *30, 0, 0);
                    b.Content = chars[i][j];
                    gridwin.Children.Add(b);    // aggiungo alla UI il bottone dentro la griglia
                    buttons[i,j] = b;           // imposto il valore nella matrice alla posizione corretta
                }
            }
        }

        private void comboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.Items.Count == 0) // non ci sono più parole da scegliere
            {
                comboBox.IsEnabled = false; // disabilito la scelta di una parola
                //MessageBox.Show("There are no more words to search in the puzzle", "Error");
            }

            bool done = false; // flag di lavoro
            string word = comboBox.SelectedValue?.ToString()!; // ottengo la parola scelta (anche se la reference è null)
            choseColor = RandomColor(); // scelgo un colore random per la parola

            for (int i = 0; i < chars.Count && !done; i++)
            {
                for (int j = 0; j < chars[i].Count && !done; j++)
                {
                    done |= FindWord(i, j, word); // per ogni coordinata cerco la parola
                }
            }

            if (done) // se esiste la parola nella matrice
                comboBox.Items.RemoveAt(comboBox.SelectedIndex); // rimuovo la parola dalla lista
        }
    }
}
