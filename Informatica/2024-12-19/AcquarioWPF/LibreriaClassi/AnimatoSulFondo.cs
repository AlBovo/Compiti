using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaClassi
{
    /// <summary>
    /// Class to manage a fish on the floor of the acquarium
    /// </summary>
    public class AnimatoSulFondo : AnimatoInAcqua
    {
        public override void Muovi(object? sender, EventArgs eventArgs)
        {
            // Controlla se l'immagine raggiunge i bordi
            if (position.Item1 - 5 <= 0 && DirezioneSinistra)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                SpecchiaImmagine();
            }
            else if (position.Item1 + image.ActualWidth + 5 >= size.Item1)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                SpecchiaImmagine();
            }
            Muovi(5, size, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="uri">The uri of the image of the fish</param>
        /// <param name="thickness">The thickness for the wpf</param>
        /// <param name="canvas">The canvas where the fish is placed</param>
        public AnimatoSulFondo(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, (thickness.Item1, canvas.Height - thickness.Item2), velocity, canvas)
        {
            DirezioneAlto = false;
        }
    }
}
