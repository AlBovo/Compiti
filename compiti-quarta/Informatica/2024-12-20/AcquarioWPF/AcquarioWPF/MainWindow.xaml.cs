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
        #region Metodo per generare un'istanza di un AnimatoSulPosto
        /// <summary>
        /// Metodo per generare un'istanza di un AnimatoSulPosto
        /// </summary>
        /// <param name="canvas">Canvas di appartenenza dell'animato</param>
        /// <returns>Un'istanza di un AnimatoSulPosto</returns>
        private static AnimatoSulPosto animatoSulPosto(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/alga.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 350), 0, canvas);
        }
        #endregion

        #region Metodo per generare un'istanza di un AnimatoSulFondo
        /// <summary>
        /// Metodo per generare un'istanza di un AnimatoSulFondo
        /// </summary>
        /// <param name="canvas">Canvas di appartenenza dell'animato</param>
        /// <returns>Un'istanza di un AnimatoSulFondo</returns>
        private static AnimatoSulFondo animatoSulFondo(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/granchio.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 150), 5, canvas);
        }
        #endregion

        #region Metodo per generare un'istanza di un AnimatoSulFondo non sul fondo
        /// <summary>
        /// Metodo per generare un'istanza di un AnimatoSulFondo non sul fondo
        /// </summary>
        /// <param name="canvas">Canvas di appartenenza dell'animato</param>
        /// <returns>Un'istanza di un AnimatoSulFondo</returns>
        private static AnimatoSulFondo animatoInMezzo(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/pesce.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 500), 5, canvas);
        }
        #endregion

        #region Metodo per generare un'istanza di un AnimatoSilurante
        /// <summary>
        /// Metodo per generare un'istanza di un AnimatoSilurante
        /// </summary>
        /// <param name="canvas">Canvas di appartenenza dell'animato</param>
        /// <returns>Un'istanza di un AnimatoSilurante</returns>
        private static AnimatoSilurante animatoSilurante(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/sottomarino.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 200), 5, canvas);
        }
        #endregion

        #region Metodo per generare un'istanza di un AnimatoInAcqua
        /// <summary>
        /// Metodo per generare un'istanza di un AnimatoInAcqua
        /// </summary>
        /// <param name="canvas">Canvas di appartenenza dell'animato</param>
        /// <returns>Un'istanza di un AnimatoInAcqua</returns>
        private static AnimatoInAcqua animatoInAcqua(Canvas canvas)
        {
            Uri uri = new("pack://application:,,,/immagini/pescepalla.png", UriKind.RelativeOrAbsolute);
            return new(uri, (100, 500), 5, canvas);
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Title = "Alan Davide Bovo 4H 2024-11-22 - WPF con Acquario"; // aggiunta del titolo alla finestra
            Acquario acquario = new Acquario(this); // creazione di un'istanza dell'acquario

            #region Aggiunta dei vari pesci nell'acquario
            acquario.AggiungiPesce(animatoSulPosto(canvasAcquario), 300);
            acquario.AggiungiPesce(animatoSulFondo(canvasAcquario), 30); 
            acquario.AggiungiPesce(animatoInAcqua(canvasAcquario), 30);
            acquario.AggiungiPesce(animatoInMezzo(canvasAcquario), 30);
            acquario.AggiungiSilurante(animatoSilurante(canvasAcquario), 30);
            #endregion
        }
    }
}