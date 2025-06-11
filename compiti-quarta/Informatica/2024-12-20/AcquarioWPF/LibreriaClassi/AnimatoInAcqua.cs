/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaClassi
{
    public class AnimatoInAcqua : Inanimato
    {
        protected bool DirezioneSinistra = true; // variabile per la direzione orizzontale
        protected bool DirezioneAlto = true; // variabile per la direzione verticale

        #region Metodo per muovere l'oggetto in acqua
        /// <summary>
        /// Metodo per muovere l'oggetto in acqua.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="eventArgs">Argomenti dell'evento.</param>
        public override void Muovi(object? sender, EventArgs eventArgs)
        {
            // Controlla se l'immagine raggiunge i bordi
            if (position.Item1 - velocity <= 0 && DirezioneSinistra)
            {
                DirezioneSinistra = false; // Cambia direzione a destra
                SpecchiaImmagine();
            }
            else if (position.Item1 + image.ActualWidth + velocity >= canvas.Width)
            {
                DirezioneSinistra = true; // Cambia direzione a sinistra
                SpecchiaImmagine();
            }

            // controlla se l'immagine raggiunge i bordi
            if (DirezioneAlto && position.Item2 - velocity == 0)
                DirezioneAlto = false;
            else if (!DirezioneAlto && position.Item2 + image.ActualHeight + velocity >= canvas.Height)
                DirezioneAlto = true;

            // movimento in diagonale
            Muovi(velocity, true);
            Muovi(velocity, false);
        }
        #endregion

        #region Metodo per muovere autonomamente l'immagine
        /// <summary>
        /// Metodo per gestire lo spostamento di un oggetto.
        /// </summary>
        /// <param name="spostamento">Offset di spostamento dell'oggetto.</param>
        /// <param name="direzione">Indica se l'oggetto si sposta verticalmente o orizzontalmente.</param>
        protected void Muovi(int spostamento, bool direzione)
        {
            // Ottieni le dimensioni del canvas
            (double, double) canvasSize = (canvas.Width, canvas.Height);
            // Ottieni la posizione corrente dell'immagine
            double currentX = position.Item1;
            double currentY = position.Item2;
            double newX, newY;
            newX = newY = 1;

            // Calcola la nuova posizione in base alla direzione
            if (!direzione)
                newX = currentX + (DirezioneSinistra ? -spostamento : spostamento);
            else
                newY = currentY + (DirezioneAlto ? -spostamento : spostamento);

            // Crea un oggetto TranslateTransform per spostare l'immagine
            TranslateTransform translateTransform;

            if (!direzione)
            {
                // Controlla se l'immagine raggiunge i bordi orizzontali
                if (newX <= 0)
                    return; // Restituisci se l'immagine raggiunge il bordo sinistro
                else if (newX + image.ActualWidth >= canvasSize.Item1)
                    return; // Restituisci se l'immagine raggiunge il bordo destro
                translateTransform = new(-spostamento, 0);
                position = (newX, position.Item2);
            }
            else
            {
                // Controlla se l'immagine raggiunge i bordi verticali
                if (newY <= 0)
                    return; // Restituisci se l'immagine raggiunge il bordo superiore
                else if (newY + image.ActualHeight >= canvasSize.Item2)
                    return; // Restituisci se l'immagine raggiunge il bordo inferiore
                translateTransform = new(0, DirezioneAlto ? -spostamento : spostamento);
                position = (position.Item1, newY);
            }
            // Aggiorna la posizione dell'immagine con la trasformazione di traslazione
            AddTransform(translateTransform);
        }
        #endregion

        #region Metodo per specchiare l'immagine
        /// <summary>
        /// Metodo per specchiare l'immagine.
        /// </summary>
        protected void SpecchiaImmagine()
        {
            ScaleTransform flipTransform = new ScaleTransform
            {
                ScaleX = -1, // Ribalta sull'asse X se si muove a sinistra
                ScaleY = 1 // Mantiene la scala verticale invariata
            };
            AddTransform(flipTransform); // Aggiunge la trasformazione di ribaltamento
        }
        #endregion

        #region Costruttore della classe AnimatoInAcqua
        public AnimatoInAcqua(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas) { }
        #endregion
    }
}