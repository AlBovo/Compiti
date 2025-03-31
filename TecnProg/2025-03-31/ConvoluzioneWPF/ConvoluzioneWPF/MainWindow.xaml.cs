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

namespace ConvoluzioneSyncWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variabili statiche per memorizzare il percorso del file e l'immagine caricata
        private static string _filename;
        private static Bitmap _image;

        // Costruttore della finestra principale, inizializza i componenti della UI
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metodo per caricare un'immagine dal file system
        private void CaricaFoto(object sender, RoutedEventArgs er)
        {
            // Crea una finestra di dialogo per aprire un file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png"; // Estensione di default
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp"; // Filtro per i file di immagine

            // Se l'utente seleziona un file, carica l'immagine
            if (ofd.ShowDialog() == true)
            {
                _filename = ofd.FileName; // Salva il percorso del file
                _image = new Bitmap(_filename); // Carica l'immagine come oggetto Bitmap
                imgPath.Content = _filename; // Mostra il percorso dell'immagine nel controllo TextBlock
                imgFoto.Source = new BitmapImage(new Uri(_filename)); // Visualizza l'immagine nell'interfaccia utente
            }
            else
            {
                // Mostra un messaggio di errore se non è stato selezionato un file
                MessageBox.Show("Non è stato selezionato nessuno file o il file non è stato caricato correttamente", "Errore nel caricamento della foto");
            }
        }

        // Metodo che converte un oggetto Bitmap in un BitmapImage per l'uso in WPF
        private static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream()) // Usa un MemoryStream per salvare l'immagine
            {
                bitmap.Save(memory, ImageFormat.Png); // Salva l'immagine in formato PNG nel memory stream
                memory.Position = 0; // Riporta la posizione all'inizio del memory stream

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit(); // Inizializza il bitmapImage
                bitmapImage.StreamSource = memory; // Imposta il memory stream come fonte
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Carica l'immagine completamente in memoria
                bitmapImage.EndInit(); // Termina l'inizializzazione dell'immagine
                bitmapImage.Freeze(); // Congela l'immagine per renderla thread-safe

                return bitmapImage; // Restituisce il BitmapImage
            }
        }

        // Metodo che gestisce la trasformazione dell'immagine attraverso la convoluzione
        private void TrasformaFoto(object sender, RoutedEventArgs er)
        {
            // Controlla se è stata caricata un'immagine, altrimenti mostra un messaggio di errore
            if (_image == null)
            {
                MessageBox.Show("E' necessario caricare un'immagine prima di poterla trasformare", "Errore nella trasformazione");
                return;
            }

            // Inizializza la matrice di convoluzione 3x3
            int[,] matr = new int[3, 3];
            int i = 0, e = 0;
            try
            {
                // Legge i valori inseriti dall'utente nella UI e li memorizza nella matrice
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    for (e = 0; e < matr.GetLength(1); e++)
                    {
                        // Trova il TextBox corrispondente e legge il valore
                        var box = (TextBox)FindName($"conv{i}{e}");
                        matr[i, e] = int.Parse(box.Text); // Converte il testo in un valore intero e lo memorizza nella matrice
                    }
                }
            }
            catch
            {
                // Mostra un messaggio di errore se si verifica un errore nel parsing dei valori
                MessageBox.Show($"E' stato inserito un valore non valido nella matrice di convoluzione alla riga {i + 1} alla posizione {e + 1}", "Valore non valido nella matrice");
            }

            // Applica la convoluzione all'immagine
            _image = Convoluzione(_image, matr);

            // Mostra l'immagine trasformata nell'interfaccia utente
            imgFoto.Source = Bitmap2BitmapImage(_image);
        }

        // Metodo per eseguire la convoluzione di un singolo pixel con il valore della matrice
        private int pixelConv(int val, Color color)
        {
            int colorARGB = color.ToArgb(); // Ottiene il valore ARGB del colore

            // Estrae i componenti del colore (rosso, verde, blu) dai bit ARGB
            byte red = (byte)((colorARGB >> 16) & 0xFF);
            byte green = (byte)((colorARGB >> 8) & 0xFF);
            byte blue = (byte)(colorARGB & 0xFF);

            // Applica la convoluzione moltiplicando i valori dei colori con il valore della matrice e limitandoli tra 0 e 255
            red = (byte)Math.Min(255, Math.Max(0, red * val));
            green = (byte)Math.Min(255, Math.Max(0, green * val));
            blue = (byte)Math.Min(255, Math.Max(0, blue * val));

            // Restituisce il colore risultante in formato ARGB
            return (red << 16) | (green << 8) | blue;
        }

        // Metodo per eseguire la convoluzione su tutta l'immagine
        private Bitmap Convoluzione(Bitmap img, int[,] matr)
        {
            // Crea una nuova immagine per il risultato della convoluzione (con dimensioni ridotte)
            Bitmap result = new Bitmap(img.Width - 2, img.Height - 2);

            // Itera su tutti i pixel dell'immagine di output
            for (int i = 0; i < result.Width; i++)
            {
                for (int e = 0; e < result.Height; e++)
                {
                    int sum = 0; // Inizializza la somma per il nuovo valore del pixel
                    for (int j = 0; j < 3; j++) // Ciclo sulla matrice 3x3
                        for (int k = 0; k < 3; k++)
                            sum += pixelConv(matr[j, k], img.GetPixel(i + j, e + k)); // Aggiungi il risultato della convoluzione

                    // Aggiungi il valore alpha (trasparenza) alla somma
                    sum |= 0xFF << (8 * 3);

                    // Imposta il pixel convoluto nell'immagine di output
                    result.SetPixel(i, e, Color.FromArgb(sum));
                }
            }
            return result; // Restituisce l'immagine risultante
        }
    }
}