using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaClassi
{
    public class AnimatoInAcqua : Inanimato
    { 
        protected bool DirezioneSinistra = true;
        protected bool DirezioneAlto = true;

        public virtual void Muovi(object? sender, EventArgs eventArgs)
        {            
            // Controlla se l'immagine raggiunge i bordi
            if (position.Item1 == 0 && DirezioneSinistra)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                SpecchiaImmagine();
            }
            else if (position.Item1 + image.ActualWidth >= size.Item1)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                SpecchiaImmagine();
            }
            Muovi(velocity, size, true);
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
            double currentX = position.Item1;
            double currentY = position.Item2;
            double newX, newY;
            newX = newY = 1;

            // Calcola la nuova posizione
            if (!direzione)
                newX = currentX + (DirezioneSinistra ? -spostamento : spostamento);
            else
                newY = currentY + (DirezioneAlto ? -spostamento : spostamento);

            TranslateTransform translateTransform;

            if (!direzione)
            {
                // Controlla se l'immagine raggiunge i bordi
                if (newX <= 0)
                    return;
                else if (newX + image.ActualWidth >= canvasSize.Item1)
                    return;
                translateTransform = new(-spostamento, 0);
                position.Item1 = newX;
            }
            else
            {
                if (newY <= 0)
                    return;
                else if (newY + image.ActualHeight >= canvasSize.Item2)
                    return;
                translateTransform = new(0, DirezioneAlto ? -spostamento : spostamento);
                position.Item2 = newY;
            }
            // Aggiorna la posizione dell'immagine
            AddTransform(translateTransform);
        }
        #endregion

        #region Metodo per specchiare l'immagine
        protected void SpecchiaImmagine()
        {
            ScaleTransform flipTransform = new ScaleTransform
            {
                ScaleX = -1, // Ribalta sull'asse X se si muove a sinistra
                ScaleY = 1 // Mantiene la scala verticale invariata
            };
            AddTransform(flipTransform);
        }
        #endregion

        public AnimatoInAcqua(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas) { }
    }
}