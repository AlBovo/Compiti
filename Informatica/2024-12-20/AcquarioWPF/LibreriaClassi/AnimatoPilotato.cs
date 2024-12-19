using System.Windows.Controls;
using System.Windows.Input;

namespace LibreriaClassi
{
    public class AnimatoPilotato : AnimatoInAcqua
    {
        public virtual void Muovi(object? sender, KeyEventArgs e)
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
                default:
                    return;
            }
        }

        public AnimatoPilotato(Uri uri, (double, double) thickness, int velocity, Canvas canvas)
            : base(uri, thickness, velocity, canvas)
        {
        }
    }
}
