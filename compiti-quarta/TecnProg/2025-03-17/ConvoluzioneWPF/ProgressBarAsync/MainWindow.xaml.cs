using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProgressBarAsync
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

        private async void StartProgressBar(object sender, RoutedEventArgs e)
        {
            // blocco l'utilizzo del bottone
            btnStart.IsEnabled = false;

            StartProgressBarAsync(1000, 1); // attivo l'esecuzione della prima progressBar
            await Task.Delay(1000); // emulo l'esecuzione di un calcolo pesante
            StartProgressBarAsync(1000, 2); // attivo l'esecuzione della seconda progressBar

            #region Aspetto il termine dell'esecuzione dei metodi
            ProgressBar p1 = progressBar1, p2 = progressBar2;
            while (p1.Value < 1000 || p2.Value < 1000) // finche' le barre non hanno raggiunto il massimo 
                await Task.Delay(10); // aspetto 10 ms
            #endregion

            // riabilito l'utilizzo del bottone
            btnStart.IsEnabled = true;
        }

        private async void StartProgressBarAsync(int tempo, int id)
        {
            ProgressBar progress = (ProgressBar)FindName($"progressBar{id}"); // ottengo la progressBar dall'id
            TextBox text = (TextBox)FindName($"textBox{id}"); // ottengo il textBox dall'id

            text.Text = "Start ProgessBar"; // imposto il testo
            progress.Minimum = 0; // il minimo della progressBar è 0
            progress.Maximum = tempo; // il massimo della progressBar è tempo
            progress.Value = 0; // resetto il valore della progressbar

            for (int i = 0; i < tempo; i++, progress.Value++)
                await Task.Delay(1); // sleep di 1 ms mentre aumento il valore della progressbar
            text.Text = "End ProgressBar"; // fine dell'esecuzione
        }
    }
}
