using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LibreriaClassi
{
    internal class Inanimato
    {
        public Image image { get; protected set; }

        public Inanimato(Uri uri, Thickness thickness)
        {
            image = new Image();
            image.Source = new BitmapImage(uri);
            image.Margin = thickness;
        }
    }
}
