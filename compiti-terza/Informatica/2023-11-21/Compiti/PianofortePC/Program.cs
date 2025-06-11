/**********************************
 * Alan Davide Bovo 3H 2023-11-21 *
 *        Pianoforte su PC        *      
 *********************************/

namespace PianofortePC
{
    internal class Program
    {
        #region Dichiarazione delle costanti globali
        static readonly char[] keyboard = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'w', 'e', 'r', 't', 'y', 'u' };
        static readonly int[] sound_freq = { 262, 294, 330, 349, 392, 440, 494, 277, 311, 370, 415, 466 };
        const int DURATA = int.MaxValue;
        #endregion

        #region Funzione per leggere un carattere
        static public char LeggiTasto()
        {
            if (!Console.KeyAvailable) // tasto premuto
                return '\0';
            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.KeyChar;
        }
        #endregion

        #region Funzione asincrona per suonare una nota
        static async void SuonaPianoforte(int position) => Console.Beep(sound_freq[position], DURATA);
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-21";
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-21");

            Console.WriteLine("Premi un tasto per suonare una nota, 'q' per uscire");

            Thread thread = new Thread(() => { });
            char tastoTask = ' ';

            while (true) 
            {
                char tastoLetto;
                while ('\0' == (tastoLetto = LeggiTasto())) // lettura input non bloccante
                {
                    if (thread.IsAlive)
                        thread.Interrupt();
                    Console.WriteLine(thread.IsAlive);
                    continue;
                }

                int i;
                for (i = 0; i < keyboard.Length; i++)
                    if (keyboard[i] == tastoLetto) break;

                if (i == keyboard.Length) Environment.Exit(0); // esco forzatamente
                if (tastoLetto != tastoTask && thread.IsAlive) // se bisogna cambiare nota fermo il thread
                    thread.Interrupt(); // termino il thread
                
                thread = new Thread(() => SuonaPianoforte(i)); // avvio il thread
                tastoTask = tastoLetto; // cambio il tasto della nota 
                thread.Start(); // avvio il thread
            }
        }
    }
}