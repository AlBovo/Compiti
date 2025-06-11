using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoSilurante : AnimatoPilotato
    {
        private readonly Uri arpione = new("immagini/arpione.png", UriKind.RelativeOrAbsolute);
        private readonly Canvas canvas;

        protected class Siluro : AnimatoInAcqua
        {
            private readonly Canvas canvas;

            public bool Muovi()
            {
                if (IsBorder())
                    return false;
                Muovi(velocity, size, false);
                return true;
            }

            public Siluro(Uri uri, (double, double) thickness, int velocity, Canvas canvas, bool direzione)
                : base(uri, thickness, velocity, canvas)
            {
                DirezioneSinistra = direzione;
                if (!direzione)
                    SpecchiaImmagine();
                this.canvas = canvas;
            }

            ~Siluro() => canvas.Children.Remove(image);
        }

        private List<Siluro> siluri = new List<Siluro>();

        private void Spara()
        {
            siluri.Add(new(arpione, position, velocity, canvas, DirezioneSinistra));
        }

        public void MuoviSiluri(object? sender, EventArgs e)
        {
            for (int i = 0; i < siluri.Count; i++)
                if (!siluri[i].Muovi())
                    siluri.Remove(siluri[i]);
        }

        public override void Muovi(object? sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    DirezioneAlto = true;
                    Muovi(velocity, size, true);
                    break;
                case Key.Down:
                    DirezioneAlto = false;
                    Muovi(velocity, size, true);
                    break;
                case Key.Left:
                    if (!DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = true;
                    Muovi(velocity, size, false);
                    break;
                case Key.Right:
                    if (DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = false;
                    Muovi(velocity, size, false);
                    break;
                case Key.Space:
                    Spara();
                    break;
                default:
                    return;
            }
        }

        public AnimatoSilurante(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas) { this.canvas = canvas; }
    }
}
