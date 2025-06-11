using System;

namespace ConsoleApp_ValidazioneData
{
    internal class Program
    {
        #region Funzione per la lettura di un numero intero
        static int readInt(string message)
        {
            int result;
            string input;
            bool inputOK;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                inputOK = int.TryParse(input, out result);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
            } while (!inputOK);

            return result;
        }
        #endregion

        static bool Bisestile(int anno)
        {
            if (anno % 4 != 0) return false;
            if (anno % 1000 == 0) return true;
            if(anno % 100 == 0) return false;
            return true;
        }

        static bool ControllaData(int giorno, int mese, int anno)
        {
            #region Controllo della validità della data
            switch (mese)
            {
                case 1: // gennaio
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 2: // febbraio
                    if(Bisestile(anno)) return giorno >= 1 && giorno <= 29; // tra 1 e 29 se bisestile
                    else return giorno >= 1 && giorno <= 28; // tra 1 e 28 se non bisestile

                case 3: // marzo
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 4: // aprile
                    return giorno >= 1 && giorno <= 30; // tra 1 e 30

                case 5: // maggio
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 6: // giugno
                    return giorno >= 1 && giorno <= 30; // tra 1 e 30
                
                case 7: // luglio
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 8: // agosto
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 9: // settembre
                    return giorno >= 1 && giorno <= 30; // tra 1 e 30

                case 10: // ottobre
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                case 11: // novembre
                    return giorno >= 1 && giorno <= 30; // tra 1 e 30

                case 12: // dicembre
                    return giorno >= 1 && giorno <= 31; // tra 1 e 31

                default:
                    return false;
            }
            #endregion
        }

        static void Main(string[] args)
        {
            #region Dichiarazione e assegnamento delle variabili
            int giorno = readInt("Inserisci il numero del giorno: ");
            int mese = readInt("Inserisci il numero del mese: ");
            int anno = readInt("Inserisci il numero dell'anno: ");
            #endregion

            Console.WriteLine("\nLa data inserita è: " + ((giorno < 10)? "0" : "") + giorno + "/" + ((mese < 10) ? "0" : "") + mese + "/" + anno);

            #region Controllo della validità della data usando DatTime
            //try
            //{
            //    DateTime date = new DateTime(anno, mese, giorno);
            //    Console.WriteLine("La data inserita è valida");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("La data inserita non è valida");
            //}
            #endregion

            #region Stampa dei risultati
            if (ControllaData(giorno, mese, anno))
            {
                Console.WriteLine("La data inserita è valida");
            }
            else
            {
                Console.WriteLine("La data inserita non è valida");
            }
            #endregion

            Console.WriteLine("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
