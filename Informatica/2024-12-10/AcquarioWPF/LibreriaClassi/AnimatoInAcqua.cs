using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace LibreriaClassi
{
    internal class AnimatoInAcqua : Inanimato
    {
        private bool DirezioneSinistra = true;

        protected virtual void Muovi(int canvasWidth)
        {
            while (true)
            {
                Muovi(1, canvasWidth);
                Thread.Sleep(10);
            }
        }

        #region Metodo per muovere autonomamente l'immagine
        /// <summary>
        /// Metodo per gestire lo spostamento di un oggetto
        /// </summary>
        /// <param name="spostamento">Offset di spostamento dell'oggetto</param>
        /// <param name="canvasSize">Dimensione del canva dell'acquario</param>
        /// <param name="direzione">Booleano per indicare se l'oggetto si sposta verticalmente o orizzontalmente</param>
        protected void Muovi(int spostamento, (int, int) canvasSize, bool direzione)
        {
            // Ottieni la posizione corrente dell'immagine
            double currentX = Canvas.GetLeft(image);
            if (double.IsNaN(currentX)) currentX = 0; // Gestisce valori non inizializzati

            double currentY = image.;

            // Calcola la nuova posizione
            int newX = (int)currentX + (DirezioneSinistra ? -spostamento : spostamento);
            
            // Controlla se l'immagine raggiunge i bordi
            if (newX < 0)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                newX = 0; // Imposta la posizione al bordo
                SpecchiaImmagine();
            }
            else if (newX + image.ActualWidth > canvasWidth)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                newX = canvasWidth - image.ActualWidth; // Imposta la posizione al bordo
                SpecchiaImmagine();
            }

            // Aggiorna la posizione dell'immagine
            Canvas.SetLeft(image, newX);

        }
        #endregion

        #region Metodo per specchiare l'immagine
        private void SpecchiaImmagine()
        {
            ScaleTransform flipTransform = new ScaleTransform
            {
                ScaleX = DirezioneSinistra ? -1 : 1, // Ribalta sull'asse X se si muove a sinistra
                ScaleY = 1 // Mantiene la scala verticale invariata
            };
            image.RenderTransform = flipTransform;
            image.RenderTransformOrigin = new Point(0.5, 0.5); // Centra il punto di trasformazione
        }
        #endregion

        public AnimatoInAcqua(Uri uri, Thickness thickness, Canvas canvas)
            : base(uri, thickness)
        {
            // TODO: add canvas width
            Thread oggetto = new Thread(() => { Muovi((int)canvas.ActualWidth); });
            oggetto.Start();
        }
    }
}
