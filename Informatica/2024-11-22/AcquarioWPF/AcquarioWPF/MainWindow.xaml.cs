/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AcquarioWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = new();
        private Image immagine = new();
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
        private void Tick(object? sender, EventArgs eventArgs) => contatore.Content = (++counter).ToString();

        /// <summary>
        /// Method to add a fish into the acquarium
        /// </summary>
        private void AggiungiOggetti()
        {
            Uri uri = new("immagini/pesce.png", UriKind.RelativeOrAbsolute);
            immagine.Source = new BitmapImage(uri);
            immagine.Margin = new Thickness(300, 50, 0, 0);
            canvasAcquario.Children.Add(immagine);
        }

        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
            AggiungiOggetti();
        }
    }
}