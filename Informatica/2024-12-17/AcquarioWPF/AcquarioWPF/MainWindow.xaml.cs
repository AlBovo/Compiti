/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using LibreriaClassi;

namespace AcquarioWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = new();
        private AnimatoInAcqua immagine;
        private bool started = false;
        private int counter = 0;

        /// <summary>
        /// Method used to setup all data for the dispatcher
        /// </summary>
        private void SetupTimer()
        {
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(300);
            dispatcherTimer.Tick += new EventHandler(Tick);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Method used called by the dispatcher every 300 ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Tick(object? sender, EventArgs eventArgs) => (++counter).ToString();

        /// <summary>
        /// Method to add a fish into the acquarium
        /// </summary>
        private AnimatoInAcqua AggiungiOggetti()
        {
            Uri uri = new("immagini/pesce.png", UriKind.RelativeOrAbsolute);
            return new AnimatoInAcqua(uri, new Thickness(0, 150, 0, 0), canvasAcquario);
        }

        public MainWindow()
        {
            InitializeComponent();
            var pesce = AggiungiOggetti();
            dispatcherTimer.Tick += new EventHandler(pesce.Muovi);
            AggiungiOggetti();
        }
    }
}