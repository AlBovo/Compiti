/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibreriaClassi
{
    public class Inanimato
    {
        public Image image { get; protected set; } // immagine dell'oggetto
        public Canvas canvas { get; protected set; } // canvas in cui viene posizionato l'oggetto
        public (double, double) position { get; protected set; } // posizione dell'oggetto nel canvas
        protected int velocity; // velocità di movimento dell'oggetto

        #region Metodo per modificare la posizione dell'oggetto
        /// <summary>
        /// Aggiunge una trasformazione all'immagine.
        /// </summary>
        /// <param name="t">La trasformazione da aggiungere.</param>
        public void AddTransform(Transform t)
        {
            // Crea un nuovo gruppo di trasformazioni
            TransformGroup transformGroup = new();

            // Aggiunge la trasformazione fornita al gruppo di trasformazioni
            transformGroup.Children.Add(t);

            // Aggiunge la trasformazione corrente dell'immagine al gruppo di trasformazioni
            transformGroup.Children.Add(image.RenderTransform);

            // Imposta il gruppo di trasformazioni come trasformazione corrente dell'immagine
            image.RenderTransform = transformGroup;
        }
        #endregion

        #region Metodo virtuale usato per muovere l'oggetto
        /// <summary>
        /// Metodo virtuale per muovere l'oggetto.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="eventArgs">Argomenti dell'evento.</param>
        public virtual void Muovi(object? sender, EventArgs eventArgs) { }
        #endregion

        #region Metodo per verificare se l'oggetto è vicino al bordo del canvas
        /// <summary>
        /// Verifica se l'oggetto è vicino al bordo del canvas.
        /// </summary>
        /// <returns>True se l'oggetto è vicino al bordo, altrimenti False.</returns>
        public bool IsBorder() =>
            position.Item1 - velocity <= 0 || position.Item2 - velocity <= 0 ||
            position.Item1 + velocity + image.ActualWidth >= canvas.Width ||
            position.Item2 + velocity + image.ActualHeight >= canvas.Height;
        #endregion

        #region Metodo per rimuovere l'immagine del canvas
        /// <summary>
        /// Rimuove l'immagine dal canvas.
        /// </summary>
        public void RimuoviPesce() => canvas.Children.Remove(image);
        #endregion

        #region Costruttore base della classe Inanimato
        public Inanimato(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
        {
            // Crea una nuova istanza dell'immagine
            image = new Image();
            // Imposta la sorgente dell'immagine con l'URI fornito
            image.Source = new BitmapImage(uri);

            // Verifica se la posizione X è valida
            if (thickness.Item1 <= 0 || thickness.Item1 >= canvas.Width)
                throw new ArgumentException("Posizione X non valida");
            // Verifica se la posizione Y è valida
            if (thickness.Item2 <= 0 || thickness.Item2 >= canvas.Height)
                throw new ArgumentException("Posizione Y non valida");

            // Imposta la posizione iniziale dell'oggetto
            position = thickness;
            // Imposta la velocità di movimento dell'oggetto
            this.velocity = velocity;
            // Aggiunge una trasformazione di traslazione all'immagine
            AddTransform(new TranslateTransform(thickness.Item1, thickness.Item2));

            // Imposta l'origine della trasformazione dell'immagine
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            // Aggiunge l'immagine al canvas
            canvas.Children.Add(image);
            // Imposta il canvas come proprietà dell'oggetto
            this.canvas = canvas;
        }
        #endregion
    }
}
