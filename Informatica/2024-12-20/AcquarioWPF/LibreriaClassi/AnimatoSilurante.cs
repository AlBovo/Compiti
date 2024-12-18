using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoSilurante : AnimatoPilotato
    {
        protected class Siluro : AnimatoInAcqua
        {
            public Siluro(Uri uri, (int, int) thickness, Canvas canvas)
                : base(uri, thickness, canvas) { }
        }

        private Siluro siluro;

        private void Spara()
        {
            if (DirezioneSinistra)
            {
                arpione.AddTransform()
            }
            else
            {

            }
        }

        public override void Muovi(object? sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    DirezioneAlto = true;
                    Muovi(5, size, true);
                    break;
                case Key.Down:
                    DirezioneAlto = false;
                    Muovi(5, size, true);
                    break;
                case Key.Left:
                    if (!DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = true;
                    Muovi(5, size, false);
                    break;
                case Key.Right:
                    if (DirezioneSinistra)
                        SpecchiaImmagine();
                    DirezioneSinistra = false;
                    Muovi(5, size, false);
                    break;
                case Key.Space:
                    Spara();
                    break;
                default:
                    return;
            }
        }

        public AnimatoSilurante(Uri uri, (int, int) thickness, Canvas canvas)
            : base(uri, thickness, canvas)
        {
            siluro = new(uri, thickness, canvas);
        }
    }
}
