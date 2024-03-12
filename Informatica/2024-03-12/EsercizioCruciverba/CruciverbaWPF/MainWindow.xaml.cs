﻿using System;
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
        static public Button[,] buttons;
        static public List<List<char>> chars = new List<List<char>>();

        private bool Trova(int x, int y, string toFind)
        {
            string temp = "";
            for (int i = y, e = x; i >= 0 && e >= 0; i--, e--) // alto sinistra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i++].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; e >= 0; e--) // alto
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count && e >= 0; i++, e--) // alto destra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e++, i--].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0; i--) // sinistra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e, i++].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count; i++) // destra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e, i--].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; i >= 0 && e < chars.Count; i--, e++) // giù sinistra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i++].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; e < chars.Count; e++) // giù
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i].Background = Brushes.Blue;
                    return true;
                }
            }
            temp = "";
            for (int i = y, e = x; i < chars[0].Count && e < chars.Count; i++, e++) // giù destra
            {
                temp += chars[e][i];
                if (temp == toFind)
                {
                    for (int j = 0; j < temp.Length; j++)
                        buttons[e--, i--].Background = Brushes.Blue;
                    return true;
                }
            }
            return false;
        }

        private void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine()!;
                int i = 0;
                while (line != "")
                {
                    chars.Add(new List<char>());
                    foreach (char c in line)
                        chars[i].Add(c);
                    line = sr.ReadLine()!;
                    i++;
                }

                line = sr.ReadLine()!;
                while (line != null)
                {
                    comboBox.Items.Add(line);
                    line = sr.ReadLine()!;
                }
                sr.Close();
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadFile(@"..\..\..\dati.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in reading file");
            }

            buttons = new Button[chars.Count, chars[0].Count];

            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = 0; j < chars[i].Count; j++)
                {
                    Button b = new Button();
                    b.Height = 30;
                    b.Width = 30;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(j * 30, i *30, 0, 0);
                    b.Content = chars[i][j];
                    gridwin.Children.Add(b);
                    buttons[i,j] = b;
                }
            }
        }

        private void comboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            bool done = false;
            for(int i=0; i<chars.Count && !done; i++)
            {
                for(int j=0; j < chars[i].Count && !done; j++)
                {
                    done |= Trova(i, j, ((ComboBox)sender).SelectedValue.ToString()!);
                }
            }
        }
    }
}
