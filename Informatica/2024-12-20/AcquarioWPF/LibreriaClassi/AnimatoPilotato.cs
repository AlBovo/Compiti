/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoPilotato : AnimatoInAcqua
    {
        #region Metodo per spostare l'oggetto in base al tasto premuto
        /// <summary>
        /// Sposta l'oggetto in base al tasto premuto.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Gli argomenti dell'evento contenenti le informazioni sul tasto.</param>
        public virtual void Muovi(object? sender, KeyEventArgs e)
        {
            // In base al tasto premuto, muove l'oggetto.
            switch (e.Key)
            {
                // Se premuto il tasto su, muove l'oggetto verso l'alto.
                case Key.Up:
                    DirezioneAlto = true; // Imposta la direzione dell'oggetto.
                    Muovi(velocity, true); // Muove l'oggetto.
                    break;

                // Se premuto il tasto giù, muove l'oggetto verso il basso.
                case Key.Down:
                    DirezioneAlto = false; // Imposta la direzione dell'oggetto.
                    Muovi(velocity, true); // Muove l'oggetto.
                    break;

                // Se premuto il tasto sinistra, muove l'oggetto verso sinistra.
                case Key.Left:
                    // Se l'oggetto è girato verso destra, lo specchia.
                    if (!DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = true; // Imposta la direzione dell'oggetto.
                    Muovi(velocity, false); // Muove l'oggetto.
                    break;

                // Se premuto il tasto destra, muove l'oggetto verso destra.
                case Key.Right:
                    // Se l'oggetto è girato verso sinistra, lo specchia.
                    if (DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = false; // Imposta la direzione dell'oggetto.
                    Muovi(velocity, false); // Muove l'oggetto.
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Costruttore della classe AnimatoPilotato
        public AnimatoPilotato(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas) { }
        #endregion
    }
}
