using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ProgressBarSync
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartProgressBar(object sender, RoutedEventArgs e)
        {
            // Faccio partire la prima progressBar
            StartProgressBarSync(1000, 1);
            // Faccio partire la seconda progressBar
            StartProgressBarSync(1000, 2);
        }

        private void StartProgressBarSync(int tempo, int id)
        {
            ProgressBar progress = (ProgressBar)FindName($"progressBar{id}"); // ottengo la progressBar dall'id
            TextBox text = (TextBox)FindName($"textBox{id}"); // ottengo il textBox dall'id

            text.Text = "Start ProgessBar"; // imposto il testo
            progress.Minimum = 0; // il minimo della progressBar è 0
            progress.Maximum = tempo; // il massimo della progressBar è tempo
            progress.Value = 0; // resetto il valore della progressbar

            for (int i = 0; i < tempo; i++, progress.Value++)
                Thread.Sleep(1); // sleep di 1 ms mentre aumento il valore della progressbar
            text.Text = "End ProgressBar"; // fine dell'esecuzione
        }
    }
}
