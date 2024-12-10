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

        public override void Muovi((int, int) canvasSize)
        {
            char scelta;
            while ((scelta = LeggiTasto().ToString().ToUpper()[0]) == '\0' &&
                (scelta != 'A' || scelta != 'S' || scelta != 'D' || scelta != 'W')) ;

            if(scelta == 'A' || scelta == 'D')
            {
                DirezioneSinistra = scelta == 'A';
                Muovi(1, canvasSize.Item1);
            }
            else
            {

            }
        }

        public AnimatoPilotato(Uri uri, Thickness thickness, Canvas canvas)
            : base(uri, thickness)
        {
            (int, int) size = ((int)canvas.ActualWidth, (int)canvas.ActualWidth) ;
            Thread oggetto = new Thread(() => { Muovi(size); });
            oggetto.Start();
        }
    }
}
