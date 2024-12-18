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
            if (position.Item1 - 2 <= 0 && DirezioneSinistra)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                SpecchiaImmagine();
            }
            else if (position.Item1 + image.ActualWidth + 2 >= size.Item1)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                SpecchiaImmagine();
            }
            Muovi(2, size, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="uri">The uri of the image of the fish</param>
        /// <param name="thickness">The thickness for the wpf</param>
        /// <param name="canvas">The canvas where the fish is placed</param>
        public AnimatoSulFondo(Uri uri, (int, int) thickness, Canvas canvas)
            : base(uri, (thickness.Item1, canvas.Height - thickness.Item2), canvas)
        {
            DirezioneAlto = false;
        }
    }
}
