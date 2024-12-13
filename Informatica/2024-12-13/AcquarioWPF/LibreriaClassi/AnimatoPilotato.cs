using System.Windows;
using System.Windows.Controls;

namespace LibreriaClassi
{
    internal class AnimatoPilotato : AnimatoInAcqua
    {
        private bool DirezioneSinistra = true, DirezioneAlto = true;

        protected char LeggiTasto()
        {
            if (!Console.KeyAvailable) // se nessun tasto è premuto
                return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true); // lettura del carattere
            return key.KeyChar;
        }

        protected override void Muovi((double, double) canvasSize)
        {
            char scelta;
            while ((scelta = LeggiTasto().ToString().ToUpper()[0]) == '\0' &&
                (scelta != 'A' || scelta != 'S' || scelta != 'D' || scelta != 'W')) ;

            if(scelta == 'A' || scelta == 'D')
            {
                DirezioneSinistra = scelta == 'A';
                Muovi(1, canvasSize, false);
            }
            else
            {
                DirezioneAlto = scelta == 'S';
                Muovi(1, canvasSize, true);
            }
        }

        public AnimatoPilotato(Uri uri, Thickness thickness, Canvas canvas)
            : base(uri, thickness, canvas)
        {
            var size = (canvas.ActualWidth, canvas.ActualHeight) ;
            Thread oggetto = new (() => { Muovi(size); });
            oggetto.Start();
        }
    }
}
