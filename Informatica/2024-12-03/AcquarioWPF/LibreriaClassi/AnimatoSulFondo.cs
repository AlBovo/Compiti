using System.Windows;

namespace LibreriaClassi
{
    /// <summary>
    /// Class to manage a fish on the floor of the acquarium
    /// </summary>
    internal class AnimatoSulFondo : AnimatoInAcqua
    {
        /// <summary>
        /// </summary>
        /// <param name="uri">The uri of the image of the fish</param>
        /// <param name="thickness">The thickness for the wpf</param>
        /// <param name="screenHeight">The height of the screen</param>
        public AnimatoSulFondo(Uri uri, Thickness thickness, double screenHeight)
            : base(uri, thickness)
        {
            thickness.Top = screenHeight - image.Height;
            image.Margin = thickness;
        }
    }
}
