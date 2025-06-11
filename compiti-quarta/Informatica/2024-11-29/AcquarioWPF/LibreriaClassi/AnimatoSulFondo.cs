using System.Windows;

namespace LibreriaClassi
{
    internal class AnimatoSulFondo : AnimatoSulPosto
    {
        public AnimatoSulFondo(Uri uri, Thickness thickness, double screenHeight)
            : base(uri, thickness)
        {
            thickness.Top = screenHeight - image.Height;
            image.Margin = thickness;
        }
    }
}
