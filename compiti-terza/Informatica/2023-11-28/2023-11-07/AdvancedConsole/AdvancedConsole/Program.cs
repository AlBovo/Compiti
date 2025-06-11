/**********************************
* Alan Davide Bovo 3H 2023-11-07 *
*       Gioco di scrittura       *
*********************************/

namespace AdvancedConsole
{
    internal class Program
    {
        #region Funzione per leggere un carattere
        static public char LeggiTasto()
        {
            if (!Console.KeyAvailable) // tasto premuto
                return '\0'; // tasto non premuto
            ConsoleKeyInfo key = Console.ReadKey(true); // lettura di un carattere
            return key.KeyChar;
        }
        #endregion

        #region Funzione per leggere una stringa
        static public string LeggiStringa(string messaggio)
        {
            string input;
            bool inputOK;

            do
            {
                Console.Write(messaggio);
                input = Console.ReadLine();
                inputOK = true;
                if(input.Length == 0)
                {
                    Console.WriteLine("La stringa inserita non può essere vuota ...");
                    inputOK = false;
                }
            } while (!inputOK);

            return input;
        }
        #endregion

        #region Funzione per leggere delle stringhe da file e far partire il gioco
        static public void LeggiFile()
        {
            #region Dichiarazione e inizializzazione delle variabili
            const string path = @"..\..\..\frasi.txt"; // path del file contenente le frasi
            int errori = 0, lunghezza = 0, erroriTemp;
            double secondi = 0, secondiTemp;
            #endregion

            #region Apertura e lettura del file
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string riga = sr.ReadLine(); // lettura di una linea
                    lunghezza += riga.Length;

                    Console.Clear();
                    Console.ResetColor();
                    Console.Write("Inizio tra");

                    #region Countdown per 
                    for (int i = 3; i >= 1; i--)
                    {
                        Console.Write($" {i} ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    #endregion

                    ControlloFrase(riga, out erroriTemp, out secondiTemp); // inizio del gioco

                    #region Aggiornamento delle variabili
                    errori += erroriTemp;
                    secondi += secondiTemp;
                    #endregion
                }

                sr.Close();
            }
            #endregion

            #region Stampa dei risultati
            Console.WriteLine($"\n\nHai fatto {errori} error{((errori == 1) ? 'e' : 'i')} e ci hai messo {secondi:0.000} second{((secondi == 1) ? 'o' : 'i')}");
            Console.WriteLine($"Hai un tasso di errore di {(double)errori / lunghezza:0.000} ovvero {(double)errori / lunghezza * 100:0}%");
            Console.WriteLine($"Hai scritto ad una velocità di {lunghezza / secondi * 60:0.000} lettere al minuto\n");
            #endregion
        }
        #endregion

        static void ControlloFrase(string frase, out int errori, out double secondi)
        {
            #region Dichiarazione e inizializzazione delle variabili
            char tastoLetto;
            errori = 0;
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch(); // timer per calcolare il tempo di gioco
            #endregion

            Console.Write($"\n{frase}"); // stampa della frase
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top); // imposto la corretta posizione del cursore
            Console.CursorVisible = false; // imposto il cursore come invisibile
            cronometro.Restart();

            for (int i = 0; i < frase.Length;)
            {
                #region Imposto la posizione del carattere
                (int, int) position = Console.GetCursorPosition();
                Console.SetCursorPosition(i, position.Item2+1);
                Console.ResetColor();
                Console.Write('^');
                Console.SetCursorPosition(i, position.Item2);
                #endregion

                while ('\0' == (tastoLetto = LeggiTasto())) continue; // aspetto un carattere con input non bloccante

                #region DECOMMENTARE PER USARE IL BACKSPACE (BETA)
                //if(tastoLetto == '\b')
                //{
                //    Console.SetCursorPosition(i, position.Item2 + 1);
                //    Console.Write(' ');
                //    Console.SetCursorPosition(i, position.Item2);
                //    i--;
                //    continue;
                //}
                #endregion

                if (tastoLetto != frase[i]) // input errato
                {
                    Console.ForegroundColor = ConsoleColor.Red; // testo rosso
                    Console.Write(frase[i]);
                    errori++;
                }
                else // input corretto
                {
                    Console.ForegroundColor = ConsoleColor.Green; // testo verde
                    Console.Write(tastoLetto);
                }

                #region Imposto la posizione del nuovo carattere
                position = Console.GetCursorPosition();
                Console.SetCursorPosition(position.Item1 - 1, position.Item2 + 1);
                Console.ResetColor();
                Console.Write(' ');
                Console.SetCursorPosition(position.Item1, position.Item2);
                #endregion
                i++;
            }
            cronometro.Stop();
            Console.ResetColor();
            secondi = cronometro.ElapsedMilliseconds / 1000.0; // calcolo del tempo speso
        }

        static void Main(string[] args)
        {
            Console.Title = "Alan Davide Bovo 3H 2023-11-07";
            Console.WriteLine("Alan Davide Bovo 3H 2023-11-07");

            LeggiFile(); // leggo da file e faccio giocare

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ..."); // uscita dal programma
            Console.ReadKey();
        }
    }
}