using System.Windows;
using System.Windows.Controls;

namespace LibreriaClassi
{
    public class AnimatoPilotato : AnimatoInAcqua
    {
        private bool DirezioneSinistra = true, DirezioneAlto = true;

        protected char LeggiTasto()
        {
            if (!Console.KeyAvailable) // se nessun tasto è premuto
                return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true); // lettura del carattere
            return key.KeyChar;
        }

        public override void Muovi(object? sender, EventArgs eventArgs)
        {
            char scelta;
            while ((scelta = LeggiTasto().ToString().ToUpper()[0]) == '\0' &&
                (scelta != 'A' || scelta != 'S' || scelta != 'D' || scelta != 'W')) ;

            if(scelta == 'A' || scelta == 'D')
            {
                DirezioneSinistra = scelta == 'A';
                Muovi(1, size, false);
            }
            else
            {
                DirezioneAlto = scelta == 'S';
                Muovi(1, size, true);
            }
        }

        public AnimatoPilotato(Uri uri, Thickness thickness, Canvas canvas)
            : base(uri, thickness, canvas) { }
    }
}
