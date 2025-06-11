/**********************************
 * Alan Davide Bovo 3H 2023-11-21 *
 *        Pianoforte su PC        *
 *********************************/

namespace PianofortePC
{
    internal class Program
    {
        #region Dichiarazione delle costanti globali
        static readonly char[] keyboard = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'w', 'e', 'r', 't', 'y', 'u' }; // tasti da premere per ogni suono
        static readonly int[] sound_freq = { 262, 294, 330, 349, 392, 440, 494, 277, 311, 370, 415, 466 }; // frequenze di ogni suono
        const int DURATA = int.MaxValue; // durata di un suono (impostata come massimo se no si bugga tutto)
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
        static async void SuonaPianoforte(int position) => Console.Beep(sound_freq[position], DURATA); // funzione asincrona per suonare il piano
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-21";
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-21");

            Console.WriteLine("Premi un tasto per suonare una nota, 'q' per uscire");

            Thread thread = new Thread(() => { }); // inizializzazione del thread
            char tastoTask = ' ';

            while (true) 
            {
                char tastoLetto;
                #region Lettura dell'input non bloccante
                while ('\0' == (tastoLetto = LeggiTasto())) // lettura input non bloccante
                {
                    if (thread.IsAlive) // se il tasto non è premuto e il thread è attivo lo termino
                        thread.Interrupt();
                    Console.WriteLine(thread.IsAlive);
                    continue;
                }
                #endregion

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