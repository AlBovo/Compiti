/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoSilurante : AnimatoPilotato
    {
        // immagine del siluro presente nelle risorse
        private readonly Uri arpione = new("pack://application:,,,/immagini/siluro.png", UriKind.RelativeOrAbsolute);

        protected class Siluro : AnimatoInAcqua
        {
            #region Metodo per muovere il siluro e controllare le collisioni con gli oggetti inanimati
            /// <summary>
            /// Muove il siluro e controlla le collisioni con gli oggetti inanimati
            /// </summary>
            /// <param name="window">Finestra dell'acquario</param>
            /// <param name="inanimato">Lista degli oggetti inanimati</param>
            /// <returns>True se il siluro si è mosso con successo, False se ha raggiunto il bordo</returns>
            public bool Muovi(Window window, List<Inanimato> inanimato)
            {
                // se il siluro tocca il bordo
                if (IsBorder())
                {
                    // rimuovi il pesce e ritorna false per dire che il siluro è uscito dal bordo
                    RimuoviPesce();
                    return false;
                }
                // muovi il siluro
                Muovi(velocity, false);

                for (int i = 0; i < inanimato.Count; i++)
                {
                    // se il siluro tocca un oggetto inanimato
                    if (CheckImageOverlap(window, inanimato[i]))
                    {
                        // rimuovi il siluro e l'oggetto inanimato
                        RimuoviPesce();
                        inanimato[i].RimuoviPesce();
                        inanimato.RemoveAt(i);
                        break;
                    }
                }

                // ritorna true per dire che il siluro si è mosso con successo
                return true;
            }
            #endregion

            #region Metodo per controllare la sovrapposizione di immagini tra il siluro e un oggetto inanimato
            /// <summary>
            /// Controlla la sovrapposizione di immagini tra il siluro e un oggetto inanimato
            /// </summary>
            /// <param name="window">Finestra dell'acquario</param>
            /// <param name="inanimato">Oggetto inanimato</param>
            /// <returns>True se le immagini si sovrappongono, False altrimenti</returns>
            private bool CheckImageOverlap(Window window, Inanimato inanimato)
            {
                // calcolo per ottenere i rettangoli che rappresentano i limiti del siluro e dell'oggetto inanimato
                Rect rect1 = GetElementBounds(window, position, image);
                Rect rect2 = GetElementBounds(window, inanimato.position, inanimato.image);

                // controllo se i rettangoli si sovrappongono
                return rect1.IntersectsWith(rect2);
            }
            #endregion

            #region Metodo per ottenere i limiti dell'immagine rispetto alla finestra
            /// <summary>
            /// Ottiene i limiti dell'elemento rispetto alla finestra
            /// </summary>
            /// <param name="window">Finestra dell'acquario</param>
            /// <param name="position">Posizione dell'elemento</param>
            /// <param name="element">Elemento</param>
            /// <returns>Rettagolo che rappresenta i limiti dell'elemento</returns>
            private Rect GetElementBounds(Window window, (double, double) position, Image element)
            {
                // calcolo per ottenere la posizione dell'elemento rispetto alla finestra
                Point topLeft = new Point(position.Item1, position.Item2);

                // creazione di un rettangolo che rappresenta i limiti dell'elemento
                return new Rect(topLeft, new Size(element.ActualWidth, element.ActualHeight));
            }
            #endregion

            #region Costruttore del siluro
            public Siluro(Uri uri, (double, double) thickness, int velocity, Canvas canvas, bool direzione)
                : base(uri, thickness, velocity, canvas)
            {
                // istanziazione del siluro
                DirezioneSinistra = direzione;
                if (!direzione) // se la direzione è destra
                    SpecchiaImmagine(); // specchia l'immagine
                this.canvas = canvas; // copia del canvas
            }
            #endregion
        }

        private List<Siluro> siluri = new List<Siluro>(); // lista dei siluri sparati

        #region Metodo per sparare un nuovo siluro
        /// <summary>
        /// Spara un nuovo siluro
        /// </summary>
        private void Spara()
        {
            // aggiunta del siluro alla lista con la sua posizione e velocità
            siluri.Add(new(arpione,
                (position.Item1 + image.ActualWidth / 2, position.Item2 + image.ActualHeight / 2),
                velocity, canvas, DirezioneSinistra)
            );
        }
        #endregion

        #region Metodo per muovere i siluri sparati dall'animato
        /// <summary>
        /// Muove i siluri e rimuove quelli che hanno raggiunto il bordo
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento</param>
        /// <param name="e">Argomenti dell'evento</param>
        public void MuoviSiluri(object? sender, EventArgs e)
        {
            // se l'oggetto che ha generato l'evento è nullo
            if (sender == null) return;

            // ottengo l'istanza dell'acquario
            Acquario acquario = (Acquario)sender;
            for (int i = 0; i < siluri.Count; i++)
                if (!siluri[i].Muovi(acquario.window, acquario.pesci)) // se tocca il bordo
                    siluri.Remove(siluri[i]); // rimozione del siluro dalla lista
        }
        #endregion

        #region Metodo per muovere l'animato silurante in base al tasto premuto
        /// <summary>
        /// Muove l'animato silurante in base al tasto premuto
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento</param>
        /// <param name="e">Argomenti dell'evento</param>
        public override void Muovi(object? sender, KeyEventArgs e)
        {
            switch (e.Key) // controllo del tasto premuto
            {
                // movimento dell'animato verso l'alto
                case Key.Up:
                    // aggiornamento della direzione e movimento
                    DirezioneAlto = true;
                    Muovi(velocity, true);
                    break;

                // movimento dell'animato verso il basso
                case Key.Down:
                    // aggiornamento della direzione e movimento
                    DirezioneAlto = false;
                    Muovi(velocity, true);
                    break;

                // movimento dell'animato verso sinistra
                case Key.Left:
                    // se la direzione è destra
                    if (!DirezioneSinistra)
                        SpecchiaImmagine(); // specchia l'immagine
                    // aggiornamento della direzione e movimento
                    DirezioneSinistra = true;
                    Muovi(velocity, false);
                    break;

                // movimento dell'animato verso destra
                case Key.Right:
                    // se la direzione è sinistra
                    if (DirezioneSinistra)
                        SpecchiaImmagine(); // specchia l'immagine
                    // aggiornamento della direzione e movimento
                    DirezioneSinistra = false;
                    Muovi(velocity, false);
                    break;

                // sparo di un siluro
                case Key.Space:
                    Spara();
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Costruttore dell'animato silurante
        public AnimatoSilurante(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas) { this.canvas = canvas; }
        #endregion
    }
}
