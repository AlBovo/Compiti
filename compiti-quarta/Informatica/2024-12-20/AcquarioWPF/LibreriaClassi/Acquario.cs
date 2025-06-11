/**********************************
* Alan Davide Bovo 4H 2024-11-22 *
*        WPF con Acquario        *
*********************************/

using System.Windows;
using System.Windows.Threading;

namespace LibreriaClassi
{
    public class Acquario
    {
        private AnimatoPilotato? pilotato; // istanza dell'animato pilotabile (se non presente allora e' null)
        private AnimatoSilurante? silurante; // istanza dell'animato silurante (se non presente allora e' null)
        public readonly Window window; // istanza readonly della schermata principale
        public List<Inanimato> pesci { get; private set; } // lista dei pesci presenti nell'acquario

        #region Metodo per aggiungere un pesce con movimento automatico
        /// <summary>
        /// Metodo per aggiungere un pesce con movimento automatico
        /// </summary>
        /// <param name="inanimato">Istanza del pesce da aggiungere</param>
        /// <param name="refresh">Ogni quanti ms il pesce verrà mosso</param>
        public void AggiungiPesce(Inanimato inanimato, int refresh)
        {
            pesci.Add(inanimato);
            // aggiunta del dispatcher e setup di quest'ultimo
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = TimeSpan.FromMilliseconds(refresh);
            dispatcher.Tick += new EventHandler(inanimato.Muovi);
            dispatcher.Start();
        }
        #endregion

        #region Metodo per l'aggiunta di un sottomarino pilotabile
        /// <summary>
        /// Metodo per l'aggiunta di un sottomarino pilotabile
        /// </summary>
        /// <param name="inanimato">Istanza del sottomarino</param>
        /// <exception cref="ArgumentException">Eccezione generata se e' gia' presente un'altro sottomarino</exception>
        public void AggiungiPilotato(AnimatoPilotato inanimato)
        {
            if (pilotato != null || silurante != null)
                throw new ArgumentException("E' gia' presente un pilotato nell'acquario");
            pilotato = inanimato;

            // chiamata della funzione muovi quando un tasto viene premuto
            window.KeyDown += pilotato.Muovi;
        }
        #endregion

        #region Metodo per l'aggiunta di un sottomarino pilotabile e in grado di sparare
        /// <summary>
        /// Metodo per l'aggiunta di un sottomarino pilotabile e in grado di sparare
        /// </summary>
        /// <param name="inanimato">Istanza del sottomarino da aggiungere</param>
        /// <param name="refresh">Numero di ms tra ogni spostamento dei suoi siluri</param>
        /// <exception cref="ArgumentException">Eccezione generata se e' gia' presente un'altro sottomarino</exception>
        public void AggiungiSilurante(AnimatoSilurante inanimato, int refresh)
        {
            if (silurante != null || pilotato != null)
                throw new ArgumentException("E' gia' presente un pilotato nell'acquario");
            silurante = inanimato;
            
            // istanza di un dispatcher per spostare i siluri sparati dal sottomarino
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Tick += (s, e) => silurante.MuoviSiluri(this, e);
            dispatcher.Interval = TimeSpan.FromMilliseconds(refresh);
            dispatcher.Start();

            // chiamata della funzione muovi quando un tasto viene premuto
            window.KeyDown += silurante.Muovi;
        }
        #endregion

        #region Metodo per rimuovere un pesce dall'acquario
        /// <summary>
        /// Metodo per rimuovere un pesce dall'acquario
        /// </summary>
        /// <param name="idx">Indice a cui rimuovere il pesce</param>
        /// <exception cref="ArgumentOutOfRangeException">Eccezione generata se l'indice non e' corretto</exception>
        public void RimuoviPesce(int idx) => pesci.RemoveAt(idx);
        #endregion

        public Acquario(Window window)
        {
            pesci = new List<Inanimato>(); // istanza della lista dei pesci
            this.window = window; // copia della finestra
        }
    }
}
