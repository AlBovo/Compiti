using System.Windows.Media;
using System.Windows.Controls;

namespace LibreriaClassi
{
    public class AnimatoSulPosto : Inanimato
    {
        public virtual void Muovi(object? sender, EventArgs eventArgs) => Rotate();

        public void Rotate()
        {
            TransformGroup tf = new TransformGroup();
            ScaleTransform flipTransform = new ScaleTransform
            {
                ScaleX = -1, // Ribalta sull'asse X se si muove a sinistra
                ScaleY = 1 // Mantiene la scala verticale invariata
            };
            tf.Children.Add(flipTransform);
            tf.Children.Add(image.RenderTransform);
            image.RenderTransform = tf;
        }

        public AnimatoSulPosto(Uri uri, (double, double) thickness, Canvas canvas)
            : base(uri, (thickness.Item1, canvas.Height - thickness.Item2), canvas) { }
    }
}