using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibreriaClassi
{
    internal class Inanimato
    {
        public Image image { get; protected set; }

        protected void AddTransform(Transform t)
        {
            TransformGroup transformGroup = new();

            transformGroup.Children.Add(t);
            transformGroup.Children.Add(image.RenderTransform);

            image.RenderTransform = transformGroup;
        }


        public Inanimato(Uri uri, Thickness thickness)
        {
            image = new Image();
            image.Source = new BitmapImage(uri);
            image.Margin = thickness;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
        }
    }
}
