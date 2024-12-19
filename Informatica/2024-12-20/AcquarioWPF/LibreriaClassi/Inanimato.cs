using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibreriaClassi
{
    public class Inanimato
    {
        public Rect rect { get; protected set; }
        public Image image { get; protected set; }
        public Canvas canvas { get; protected set; }
        public (double, double) position { get; protected set; }
        protected int velocity;

        public void AddTransform(Transform t)
        {
            TransformGroup transformGroup = new();

            transformGroup.Children.Add(t);
            transformGroup.Children.Add(image.RenderTransform);

            image.RenderTransform = transformGroup;
        }

        public virtual void Muovi(object? sender, EventArgs eventArgs) { }

        public bool IsBorder() => 
            position.Item1 - velocity <= 0 || position.Item2 - velocity <= 0 || 
            position.Item1 + velocity + image.ActualWidth >= canvas.Width || 
            position.Item2 + velocity + image.ActualHeight >= canvas.Height;

        public void RimuoviPesce() => canvas.Children.Remove(image);

        public Inanimato(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
        {
            image = new Image();
            image.Source = new BitmapImage(uri);

            if (thickness.Item1 <= 0 || thickness.Item1 >= canvas.Width)
                throw new ArgumentException("Invalid X position");
            if (thickness.Item2 <= 0 || thickness.Item2 >= canvas.Height)
                throw new ArgumentException("Invalid Y position");

            position = thickness;
            this.velocity = velocity;
            AddTransform(new TranslateTransform(thickness.Item1, thickness.Item2));            

            image.RenderTransformOrigin = new Point(0.5, 0.5);
            canvas.Children.Add(image);
            this.canvas = canvas;
        }
    }
}
