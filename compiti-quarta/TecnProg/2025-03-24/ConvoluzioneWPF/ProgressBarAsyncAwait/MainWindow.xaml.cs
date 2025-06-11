using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProgressBarAsyncAwait
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

            // emulo l'esecuzione di un calcolo pesante
            await Task.Delay(1000);

            #region Esecuzione delle progressBar
            await StartProgressBarAsync(1000, 1);
            await StartProgressBarAsync(1000, 2);
            #endregion

            // sblocco l'utilizzo del bottone
            btnStart.IsEnabled = true;
        }

        private async Task StartProgressBarAsync(int tempo, int id)
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
