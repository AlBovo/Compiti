/**********************************
* Alan Davide Bovo 4H 2025-02-24 *
* WPF Convoluzioni tra immagini  *
*********************************/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ConvoluzioneWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _filename;
        private static Bitmap _image;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CaricaFoto(object sender, RoutedEventArgs er)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png";
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp";

            if (ofd.ShowDialog() == true)
            {
                _filename = ofd.FileName;
                _image = new Bitmap(_filename);
                imgPath.Content = _filename;
                imgFoto.Source = new BitmapImage(new Uri(_filename));
            }
            else
            {
                MessageBox.Show("Non è stato selezionato nessuno file o il file non è stato caricato correttamente", "Errore nel caricamento della foto");
            }
        }

        private static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        private void TrasformaFoto(object sender, RoutedEventArgs er)
        {
            if (_image == null)
            {
                MessageBox.Show("E' necessario caricare un'immagine prima di poterla trasformare", "Errore nella trasformazione");
                return;
            }

            int[,] matr = new int[3, 3];
            int i = 0, e = 0;
            try
            {
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    for (e = 0; e < matr.GetLength(1); e++)
                    {
                        var box = (TextBox)FindName($"conv{i}{e}");
                        matr[i, e] = int.Parse(box.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show($"E' stato inserito un valore non valido nella matrice di convoluzione alla riga {i + 1} alla posizione {e + 1}", "Valore non valido nella matrice");
            }

            _image = Convoluzione(_image, matr);
            imgFoto.Source = Bitmap2BitmapImage(_image);
        }

        private int pixelConv(int val, Color color)
        {
            int ris = 0;
            int colorARGB = color.ToArgb();

            byte red = (byte)((colorARGB >> 16) & 0xFF);
            byte green = (byte)((colorARGB >> 8) & 0xFF);
            byte blue = (byte)(colorARGB & 0xFF);

            red = (byte)Math.Min(255, Math.Max(0, red * val));
            green = (byte)Math.Min(255, Math.Max(0, green * val));
            blue = (byte)Math.Min(255, Math.Max(0, blue * val));

            ris = (red << 16) | (green << 8) | blue;
            return ris;
        }

        private Bitmap Convoluzione(Bitmap img, int[,] matr)
        {
            Bitmap result = new Bitmap(img.Width - 2, img.Height - 2);

            for (int i = 0; i < result.Width; i++)
            {
                for (int e = 0; e < result.Height; e++)
                {
                    int sum = 0;
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            sum += pixelConv(matr[j, k], img.GetPixel(i+j, e+k));
                    sum |= 0xFF << (8 * 3);
                    result.SetPixel(i, e, Color.FromArgb(sum));
                }
            }
            return result;
        }
    }
}
