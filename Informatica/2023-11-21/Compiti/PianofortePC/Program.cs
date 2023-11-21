namespace PianofortePC
{
    internal class Program
    {
        static char[] keyboard = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'w', 'e', 'r', 't', 'y', 'u' };
        static int[] sound_freq = { 262, 294, 330, 349, 392, 440, 494, 277, 311, 370, 415, 466 };
        const int DURATA = 400;

        #region Funzione per leggere un carattere
        static public char LeggiTasto()
        {
            if (!Console.KeyAvailable) // tasto premuto
                return '\0';
            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.KeyChar;
        }
        #endregion

        static async void SuonaPianoforte(int position) => Console.Beep(sound_freq[position], DURATA);

        static void Main(string[] args)
        {
            Console.WriteLine("Premi un tasto per suonare una nota, 'q' per uscire");

            Thread task = new Thread(() => { });
            bool first = true; // per runnare la prima volta
            while (true) // fa schifo ma per colpa delle periferiche e dei driver (ho bisogno di un linguaggio di basso livello)
            {
                char tastoLetto;
                while ('\0' == (tastoLetto = LeggiTasto())) continue;

                int i;
                for (i = 0; i < keyboard.Length; i++)
                    if (keyboard[i] == tastoLetto) break;
                
                if(i == keyboard.Length) break;

                if (first) first = false;
                else if (!task.IsAlive) task.Interrupt();
                task = new Thread(() => SuonaPianoforte(i));
                task.Start();
            }
        }
    }
}