/**********************************
* Alan Davide Bovo 4H 2025-02-24 *
* WPF Convoluzioni tra immagini  *
*********************************/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ConvoluzioneAsyncWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variabili statiche per il percorso del file e l'immagine caricata
        private static string _filename;
        private static Bitmap _image;

        // Costruttore della finestra principale, inizializza i componenti UI
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metodo per caricare l'immagine da un file tramite un dialogo di apertura
        private void CaricaFoto(object sender, RoutedEventArgs er)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png";  // Estensione di default per il file
            // Filtra i tipi di file immagine che l'utente può selezionare
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.webp";

            if (ofd.ShowDialog() == true)  // Se l'utente seleziona un file
            {
                _filename = ofd.FileName;  // Salva il percorso del file
                _image = new Bitmap(_filename);  // Carica l'immagine come oggetto Bitmap
                imgPath.Content = _filename;  // Mostra il percorso dell'immagine nella UI
                imgFoto.Source = new BitmapImage(new Uri(_filename));  // Imposta l'immagine nel controllo WPF
            }
            else  // Se l'utente annulla o si verifica un errore
            {
                MessageBox.Show("Non è stato selezionato nessuno file o il file non è stato caricato correttamente", "Errore nel caricamento della foto");
            }
        }

        // Metodo per convertire un oggetto Bitmap in BitmapImage, necessario per la UI di WPF
        private static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())  // Crea un flusso di memoria per la conversione
            {
                bitmap.Save(memory, ImageFormat.Png);  // Salva l'immagine nel flusso in formato PNG
                memory.Position = 0;  // Riporta la posizione del flusso all'inizio

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();  // Inizia l'inizializzazione dell'immagine
                bitmapImage.StreamSource = memory;  // Imposta il flusso di memoria come sorgente
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;  // Carica l'immagine subito
                bitmapImage.EndInit();  // Completa l'inizializzazione
                bitmapImage.Freeze();  // Congela l'immagine per migliorare le prestazioni

                return bitmapImage;  // Ritorna l'immagine convertita
            }
        }

        // Metodo asincrono per applicare la trasformazione (convoluzione) all'immagine
        async private void TrasformaFoto(object sender, RoutedEventArgs er)
        {
            if (_image == null)  // Verifica se è stata caricata un'immagine
            {
                MessageBox.Show("E' necessario caricare un'immagine prima di poterla trasformare", "Errore nella trasformazione");
                return;
            }

            int[,] matr = new int[3, 3];  // Matrice 3x3 per la convoluzione
            int i = 0, e = 0;
            try
            {
                // Ciclo per raccogliere i valori della matrice dalla UI (caselle di testo)
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    for (e = 0; e < matr.GetLength(1); e++)
                    {
                        var box = (TextBox)FindName($"conv{i}{e}");  // Trova la casella di testo corrispondente
                        matr[i, e] = int.Parse(box.Text);  // Leggi e salva il valore nella matrice
                    }
                }
            }
            catch  // Gestisce eventuali errori di parsing dei valori
            {
                MessageBox.Show($"E' stato inserito un valore non valido nella matrice di convoluzione alla riga {i + 1} alla posizione {e + 1}", "Valore non valido nella matrice");
            }

            // Configura la barra di progresso
            progressBar.Minimum = 0;
            progressBar.Maximum = 4;
            progressBar.Value = 0;

            // Divide l'immagine in quadranti per elaborazione parallela
            Bitmap[] bitmap = ImageSplitter.DividiQuadranti(_image);
            for (i = 0; i < bitmap.Length; i++)
            {
                // Avvia l'elaborazione della convoluzione in un task asincrono
                await Task.Run(() => bitmap[i] = Convoluzione(bitmap[i], matr));
                progressBar.Value++;  // Aggiorna la barra di progresso
            }

            // Unisce i quadranti elaborati in un'unica immagine
            _image = ImageSplitter.UnisciQuadranti(bitmap);
            imgFoto.Source = Bitmap2BitmapImage(_image);  // Mostra l'immagine trasformata
        }

        // Metodo per applicare la convoluzione su un singolo pixel dell'immagine
        private int PixelConv(int val, Color color)
        {
            int colorARGB = color.ToArgb();  // Ottieni il valore ARGB del colore

            // Estrai i componenti di colore (rosso, verde, blu) dal valore ARGB
            byte red = (byte)((colorARGB >> 16) & 0xFF);
            byte green = (byte)((colorARGB >> 8) & 0xFF);
            byte blue = (byte)(colorARGB & 0xFF);

            // Applica il valore della matrice di convoluzione al componente di colore
            red = (byte)Math.Min(255, Math.Max(0, red * val));
            green = (byte)Math.Min(255, Math.Max(0, green * val));
            blue = (byte)Math.Min(255, Math.Max(0, blue * val));

            // Combina i componenti modificati in un unico valore ARGB
            return (red << 16) | (green << 8) | blue;
        }

        // Metodo per applicare la convoluzione all'intera immagine
        private Bitmap Convoluzione(Bitmap img, int[,] matr)
        {
            Bitmap result = new Bitmap(img.Width - 2, img.Height - 2);  // Crea un'immagine di dimensioni ridotte

            // Ciclo per ogni pixel dell'immagine (eccetto i bordi)
            for (int i = 0; i < result.Width; i++)
            {
                for (int e = 0; e < result.Height; e++)
                {
                    int sum = 0;  // Somma dei valori modificati dei pixel

                    // Ciclo su ogni elemento della matrice di convoluzione
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            sum += PixelConv(matr[j, k], img.GetPixel(i + j, e + k));  // Calcola il valore del pixel

                    // Imposta il nuovo pixel nell'immagine risultante
                    sum |= 0xFF << (8 * 3);  // Aggiunge l'alpha (trasparenza) al valore ARGB
                    result.SetPixel(i, e, Color.FromArgb(sum));
                }
            }
            return result;  // Restituisce l'immagine modificata
        }
    }
}