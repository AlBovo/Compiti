/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows.Controls;

namespace LibreriaClassi
{
    public class AnimatoSulFondo : AnimatoInAcqua
    {
        #region Metodo per spostare il pesce sul fondo dell'acquario
        /// <summary>
        /// Sposta il pesce sul fondo dell'acquario.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="eventArgs">Gli argomenti dell'evento.</param>
        public override void Muovi(object? sender, EventArgs eventArgs)
        {
            // Controlla se l'immagine raggiunge i bordi
            if (position.Item1 - velocity <= 0 && DirezioneSinistra)
            {
                DirezioneSinistra = false; // Cambia direzione verso destra
                SpecchiaImmagine(); // Inverte l'immagine
            }
            else if (position.Item1 + image.ActualWidth + velocity >= canvas.Width)
            {
                DirezioneSinistra = true; // Cambia direzione verso sinistra
                SpecchiaImmagine(); // Inverte l'immagine
            }
            Muovi(velocity, false); // Sposta il pesce
        }
        #endregion

        #region Costruttore della classe AnimatoSulFondo
        public AnimatoSulFondo(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, (thickness.Item1, canvas.Height - thickness.Item2), velocity, canvas)
        {
            DirezioneAlto = false;
        }
        #endregion
    }
}
