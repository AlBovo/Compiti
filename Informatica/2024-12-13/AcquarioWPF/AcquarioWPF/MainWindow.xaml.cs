/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        #region Method to transform the image
        /// <summary>
        /// Method used to translate the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = new();
            transformGroup.Children.Add(new TranslateTransform(-1, 1));
            transformGroup.Children.Add(immagine.RenderTransform);

            immagine.RenderTransform = transformGroup;
        }

        /// <summary>
        /// Method used to rotate the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = new();
            transformGroup.Children.Add(new RotateTransform(1));
            transformGroup.Children.Add(immagine.RenderTransform);
            immagine.RenderTransform = transformGroup;
        }

        /// <summary>
        /// Method used to scale the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = new();
            transformGroup.Children.Add(new ScaleTransform(1.1, 1.1));
            transformGroup.Children.Add(immagine.RenderTransform);
            immagine.RenderTransform = transformGroup;
        }

        private void Transform_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup transformGroup = new();

            transformGroup.Children.Add(new TranslateTransform(20, 20));
            transformGroup.Children.Add(new ScaleTransform(1.1, 1.1));
            transformGroup.Children.Add(new RotateTransform(10));
            transformGroup.Children.Add(immagine.RenderTransform);

            immagine.RenderTransform = transformGroup;
        }

        #endregion

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