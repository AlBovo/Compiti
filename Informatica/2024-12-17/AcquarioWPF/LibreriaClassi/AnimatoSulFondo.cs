using System.Windows;
using System.Windows.Controls;

namespace LibreriaClassi
{
    /// <summary>
    /// Class to manage a fish on the floor of the acquarium
    /// </summary>
    public class AnimatoSulFondo : AnimatoInAcqua
    {
        /// <summary>
        /// </summary>
        /// <param name="uri">The uri of the image of the fish</param>
        /// <param name="thickness">The thickness for the wpf</param>
        /// <param name="canvas">The canvas where the fish is placed</param>
        public AnimatoSulFondo(Uri uri, Thickness thickness, Canvas canvas)
            : base(uri, thickness, canvas)
        {
            thickness.Top = canvas.ActualHeight - image.Height;
            image.Margin = thickness;
            
        }
    }
}
