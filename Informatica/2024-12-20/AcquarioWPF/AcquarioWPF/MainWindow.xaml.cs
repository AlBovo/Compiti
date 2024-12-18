/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
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
        private DispatcherTimer pesciFondo = new();
        private DispatcherTimer pescePilotato = new();
        private AnimatoInAcqua immagine;
        private int counter = 0;

        /// <summary>
        /// Method used to setup all data for the dispatcher
        /// </summary>
        private void SetupTimer()
        {
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
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
        private AnimatoSulFondo PesceAnimato()
        {
            Uri uri = new("immagini/granchio.png", UriKind.RelativeOrAbsolute);
            return new(uri, (1, 150), canvasAcquario);
        }

        private AnimatoSulPosto PescePosto()
        {
            Uri uri = new("immagini/alga.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 350), canvasAcquario);
        }

        private AnimatoPilotato PescePilotato()
        {
            Uri uri = new("immagini/pesce.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 200), canvasAcquario);
        }

        public MainWindow()
        {
            InitializeComponent();
            var pesce1 = PescePosto();
            var pesce2 = PesceAnimato();
            var pesce3 = PescePilotato();
            dispatcherTimer.Tick += new EventHandler(pesce2.Muovi);
            pesciFondo.Tick += new EventHandler(pesce1.Muovi);
            pesciFondo.Interval = TimeSpan.FromMilliseconds(300);
            pesciFondo.Start();

            var window = Window.GetWindow(this);
            window.KeyDown += pesce3.Muovi;


            SetupTimer();
        }
    }
}