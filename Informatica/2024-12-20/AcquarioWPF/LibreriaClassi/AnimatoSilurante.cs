using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoSilurante : AnimatoPilotato
    {
        private readonly Uri arpione = new("pack://application:,,,/immagini/siluro.png", UriKind.RelativeOrAbsolute);

        protected class Siluro : AnimatoInAcqua
        {
            public bool Muovi(Window window, List<Inanimato> inanimato)
            {
                if (IsBorder())
                {
                    RimuoviPesce();
                    return false;
                }
                Muovi(velocity, false);

                for (int i = 0; i < inanimato.Count; i++)
                {
                    if (CheckImageOverlap(window, inanimato[i]))
                    {
                        RimuoviPesce();
                        inanimato[i].RimuoviPesce();
                        inanimato.RemoveAt(i);
                        break;
                    }
                }
                return true;
            }

            private bool CheckImageOverlap(Window window, Inanimato inanimato)
            {
                // Assuming img1 and img2 are Image controls in your XAML
                Rect rect1 = GetElementBounds(window, position, image);
                Rect rect2 = GetElementBounds(window, inanimato.position, inanimato.image);

                return rect1.IntersectsWith(rect2);
            }

            private Rect GetElementBounds(Window window, (double, double) position, Image element)
            {
                // Get the top-left position relative to the window
                Point topLeft = new Point(position.Item1, position.Item2);

                // Create a rectangle representing the element's bounds
                return new Rect(topLeft, new Size(element.ActualWidth, element.ActualHeight));
            }

            public Siluro(Uri uri, (double, double) thickness, int velocity, Canvas canvas, bool direzione)
                : base(uri, thickness, velocity, canvas)
            {
                DirezioneSinistra = direzione;
                if (!direzione)
                    SpecchiaImmagine();
                this.canvas = canvas;
            }
        }

        private List<Siluro> siluri = new List<Siluro>();

        private void Spara()
        {
            siluri.Add(new(arpione, 
                (position.Item1 + image.ActualWidth / 2, position.Item2 + image.ActualHeight / 2), 
                velocity, canvas, DirezioneSinistra)
            );
        }

        public void MuoviSiluri(object? sender, EventArgs e)
        {
            if (sender == null) return;

            Acquario acquario = (Acquario)sender;
            for (int i = 0; i < siluri.Count; i++)
                if (!siluri[i].Muovi(acquario.window, acquario.pesci))
                    siluri.Remove(siluri[i]);
        }

        public override void Muovi(object? sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    DirezioneAlto = true;
                    Muovi(velocity, true);
                    break;
                case Key.Down:
                    DirezioneAlto = false;
                    Muovi(velocity, true);
                    break;
                case Key.Left:
                    if (!DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = true;
                    Muovi(velocity, false);
                    break;
                case Key.Right:
                    if (DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = false;
                    Muovi(velocity, false);
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
