using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaClassi
{
    public class AnimatoInAcqua : Inanimato
    { 
        private bool DirezioneSinistra = true;

        public virtual void Muovi(object? sender, EventArgs eventArgs)
        {
            Muovi(1, size, true);
        }

        #region Metodo per muovere autonomamente l'immagine
        /// <summary>
        /// Metodo per gestire lo spostamento di un oggetto
        /// </summary>
        /// <param name="spostamento">Offset di spostamento dell'oggetto</param>
        /// <param name="canvasSize">Dimensione del canva dell'acquario</param>
        /// <param name="direzione">Booleano per indicare se l'oggetto si sposta verticalmente o orizzontalmente</param>
        protected void Muovi(int spostamento, (double, double) canvasSize, bool direzione)
        {
            // Ottieni la posizione corrente dell'immagine
            double currentX = image.Width;
            if (double.IsNaN(currentX)) currentX = 0; // Gestisce valori non inizializzati

            double currentY = Canvas.GetTop(image);
            if (double.IsNaN(currentY)) currentY = 0;

            // Calcola la nuova posizione
            double newX = (int)currentX + (DirezioneSinistra ? -spostamento : spostamento);
            
            // Controlla se l'immagine raggiunge i bordi
            if (newX < 0)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                newX = 0; // Imposta la posizione al bordo
                SpecchiaImmagine();
            }
            else if (newX + image.ActualWidth > canvasSize.Item1)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                newX = canvasSize.Item1 - image.ActualWidth; // Imposta la posizione al bordo
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
            : base(uri, thickness, canvas) { }
    }
}