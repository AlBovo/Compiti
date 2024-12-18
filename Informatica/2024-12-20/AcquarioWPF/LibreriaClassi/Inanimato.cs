using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibreriaClassi
{
    public class Inanimato
    {
        public Image image { get; protected set; }
        public (double, double) size { get; protected set; }
        protected (double, double) position = (0, 0);

        public void AddTransform(Transform t)
        {
            TransformGroup transformGroup = new();

            transformGroup.Children.Add(t);
            transformGroup.Children.Add(image.RenderTransform);

            image.RenderTransform = transformGroup;
        }


        public Inanimato(Uri uri, (double, double) thickness, Canvas canvas)
        {
            image = new Image();
            image.Source = new BitmapImage(uri);

            if (thickness.Item1 <= 0 || thickness.Item1 >= canvas.Width)
                throw new ArgumentException("Invalid X position");
            if (thickness.Item2 <= 0 || thickness.Item2 >= canvas.Height)
                throw new ArgumentException("Invalid Y position");

            position = thickness;
            AddTransform(new TranslateTransform(thickness.Item1, thickness.Item2));            

            image.RenderTransformOrigin = new Point(0.5, 0.5);
            canvas.Children.Add(image);
            size = (canvas.Width, canvas.Height);
        }
    }
}
