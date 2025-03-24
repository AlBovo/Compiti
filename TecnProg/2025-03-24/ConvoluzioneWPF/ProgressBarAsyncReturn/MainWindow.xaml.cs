using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProgressBarAsyncReturn
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartProgressBar(object sender, RoutedEventArgs e)
        {
            // blocco l'utilizzo del bottone
            btnStart.IsEnabled = false;

            int res1 = await StartProgressBarAsync(1000, 1); // esecuzione della prima progressBar
            textBox1.Text = $"Restituito -> {res1}"; // stampa del risultato dell'esecuzione

            // emulo l'esecuzione di un calcolo pesante
            await Task.Delay(1000);

            int res2 = await StartProgressBarAsync(1000, 2); // esecuzione della seconda progressBar
            textBox2.Text = $"Restituto -> {res2}"; // stampa del risultato dell'esecuzione

            // sblocco l'utilizzo del bottone
            btnStart.IsEnabled = true;
        }

        private async Task<int> StartProgressBarAsync(int tempo, int id)
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
            
            return random.Next();
        }
    }
}
