/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Controls;
using LibreriaClassi;

namespace AcquarioWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AnimatoSulPosto animatoSulPosto(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/alga.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 350), 0, canvas);
        }

        private static AnimatoSulFondo animatoSulFondo(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/granchio.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 150), 5, canvas);
        }

        private static AnimatoSilurante animatoSilurante(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/sottomarino.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 200), 5, canvas);
        }

        private static AnimatoInAcqua animatoInAcqua(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/pescepalla.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 500), 5, canvas);
        }

        public MainWindow()
        {
            InitializeComponent();
            Acquario acquario = new Acquario(this);

            acquario.AggiungiPesce(animatoSulPosto(canvasAcquario), 300);
            acquario.AggiungiPesce(animatoSulFondo(canvasAcquario), 30);
            acquario.AggiungiPesce(animatoInAcqua(canvasAcquario), 30);
            acquario.AggiungiSilurante(animatoSilurante(canvasAcquario), 30);
        }
    }
}