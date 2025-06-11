using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConvoluzioneWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? _filename;
        private BitmapImage? _image;

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
                _image = new BitmapImage(new(_filename));
                imgPath.Content = _filename;
                imgFoto.Source = _image;
            }
            else
            {
                MessageBox.Show("Non è stato selezionato nessuno file o il file non è stato caricato correttamente", "Errore nel caricamento della foto");
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
                MessageBox.Show($"E' stato inserito un valore non valido nella matrice di convoluzione alla riga {i+1} alla posizione {e+1}", "Valore non valido nella matrice");
            }

            WriteableBitmap risultato = new WriteableBitmap(
                (int)_image.Width,
                (int)_image.Height,
                _image.DpiX,
                _image.DpiY,
                PixelFormats.Bgr32,
                null
            );
            
        }

        private void Convoluzione(WriteableBitmap img, int[,] matr)
        {
            for (int i = -1; i <= img.Width; i++)
                for (int e = -1; e <= img.Height; e++)
                    img
        }

        private 
    }
}