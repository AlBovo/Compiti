using System.Windows;
using System.Windows.Threading;

namespace LibreriaClassi
{
    public class Acquario
    {
        private AnimatoPilotato? pilotato;
        private AnimatoSilurante? silurante;
        public readonly Window window;
        public List<Inanimato> pesci { get; private set; }


        public void AggiungiPesce(Inanimato inanimato, int refresh)
        {
            pesci.Add(inanimato);
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = TimeSpan.FromMilliseconds(refresh);
            dispatcher.Tick += new EventHandler(inanimato.Muovi);
            dispatcher.Start();
        }

        public void AggiungiPilotato(AnimatoPilotato inanimato)
        {
            if (pilotato != null || silurante != null)
                throw new ArgumentException("E' gia' presente un pilotato nell'acquario");
            pilotato = inanimato;

            window.KeyDown += pilotato.Muovi;
        }

        public void AggiungiSilurante(AnimatoSilurante inanimato, int refresh)
        {
            if (silurante != null || pilotato != null)
                throw new ArgumentException("E' gia' presente un pilotato nell'acquario");
            silurante = inanimato;
            
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Tick += (s, e) => silurante.MuoviSiluri(this, e);
            dispatcher.Interval = TimeSpan.FromMilliseconds(refresh);
            dispatcher.Start();

            window.KeyDown += silurante.Muovi;
        }

        public void RimuoviPesce(int idx) => pesci.RemoveAt(idx);        

        public Acquario(Window window)
        {
            pesci = new List<Inanimato>();
            this.window = window;
        }
    }
}
