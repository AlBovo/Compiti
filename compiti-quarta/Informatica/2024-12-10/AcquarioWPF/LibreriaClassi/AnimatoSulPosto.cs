using System.Windows.Media;
using System.Windows;

namespace LibreriaClassi
{
    internal class AnimatoSulPosto : Inanimato
    {
        public void Rotate(double angle)
        {
            TransformGroup tf = new TransformGroup();
            tf.Children.Add(new ScaleTransform(-1, 1));
            tf.Children.Add(image.RenderTransform);
            image.RenderTransform = tf;
        }

        public AnimatoSulPosto(Uri uri, Thickness thickness)
            : base(uri, thickness) { }
    }
}
