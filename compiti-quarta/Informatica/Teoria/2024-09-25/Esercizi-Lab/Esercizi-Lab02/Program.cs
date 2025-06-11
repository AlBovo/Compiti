/*********************************
* Alan Davide Bovo 4H 20/09/2024 *
*       Aggiunta la struct       *
*********************************/
namespace Esercizi_Lab
{
    #region Struct per definire i parametri richiesti di un alunno
    public class Studente
    {
        public string nome { get; private set; }            // nome dell'alunno
        public string cognome { get; private set; }         // cognome dell'alunno
        public bool sesso { get; private set; }             // sesso dell'alunno
        public DateOnly dataNascita { get; private set; }   // data di nascita dell'alunno
        public string classe { get; private set; }          // classe dell'alunno
        public string indirizzo { get; private set; }       // indirizzo di studio dell'alunno

        #region Costruttore della struct
        public Studente(string nome, string cognome, bool sesso, DateOnly dataNascita, string classe, string indirizzo)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.dataNascita = dataNascita;
            this.sesso = sesso;
            this.classe = classe;
            this.indirizzo = indirizzo;
        }
        #endregion

        #region Metodo per calcolare l'età dello studente
        public int CalcolaEta() => (int)((DateTime.Now - dataNascita.ToDateTime(TimeOnly.MinValue)).TotalSeconds / 365.0);
        #endregion

        #region Metodo per ritornare la struct come stringa
        override public string ToString() =>
            $"{nome};{cognome};{(sesso ? 'M' : 'F')};{dataNascita.ToShortDateString()};{classe};{indirizzo}";
        #endregion
    }
    #endregion
    internal class Program
    {
        static void Main()
        {
            List<Studente> studenti = new List<Studente>(); // lista degli studenti 
            using (StreamReader reader = new StreamReader(@"..\..\..\elenco-alunni-classi.txt")) // inizializzo lo streamreader con il file di testo
            {
                for (int i = 1; !reader.EndOfStream; i++) // finché non è finito il file
                {
                    string studente = reader.ReadLine(); // lettura della riga dell'alunno
                    string[] dati = studente.Split('\t'); // split dei dati per poterli gestire meglio
                    if (dati.Length != 6) // caso teoricamente da non gestire
                        break;
                    string[] strDate = dati[3].Split('-'); // gestione della data per ottenere anno mese giorno
                    DateOnly date = new DateOnly(int.Parse(strDate[2]), int.Parse(strDate[1]), int.Parse(strDate[0]));

                    Studente alunno = new Studente(dati[0], dati[1], dati[2][0] == 'M', date, dati[4], dati[5]); // inizializzazione dell'istanza della struct
                    studenti.Add(alunno); // aggiunta alla lista degli studenti
                    Console.WriteLine($"L'alunno {i} è {alunno.ToString()}"); // stampa dati dello studente
                }
            }
        }
    }
}
