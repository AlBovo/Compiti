/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows.Media;
using System.Windows.Controls;

namespace LibreriaClassi
{
    public class AnimatoSulPosto : Inanimato
    {
        #region Metodo per muovere l'oggetto
        /// <summary>
        /// Muove l'oggetto chiamando il metodo Rotate.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="eventArgs">Argomenti dell'evento.</param>
        public override void Muovi(object? sender, EventArgs eventArgs) => Rotate();
        #endregion

        #region Metodo per ruotare l'oggetto sul suo asse X
        /// <summary>
        /// Ruota l'immagine sull'asse X.
        /// </summary>
        protected void Rotate()
        {
            // Crea un oggetto TransformGroup
            TransformGroup tf = new TransformGroup();

            // Crea un oggetto ScaleTransform per ribaltare l'immagine sull'asse X
            ScaleTransform flipTransform = new ScaleTransform
            {
                ScaleX = -1, // Ribalta sull'asse X se si muove a sinistra
                ScaleY = 1 // Mantiene la scala verticale invariata
            };

            // Aggiungi il flipTransform all'oggetto TransformGroup
            tf.Children.Add(flipTransform);

            // Aggiungi il RenderTransform dell'immagine all'oggetto TransformGroup
            tf.Children.Add(image.RenderTransform);

            // Assegna l'oggetto TransformGroup come nuovo RenderTransform dell'immagine
            image.RenderTransform = tf;
        }
        #endregion

        #region Costruttore della classe AnimatoSulPosto
        public AnimatoSulPosto(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, (thickness.Item1, canvas.Height - thickness.Item2), velocity, canvas) { }
        #endregion
    }
}