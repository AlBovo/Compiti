using System.Collections.Generic;
using System.Text.Json;
using System.Security.Cryptography;
using System.IO;
using System.Windows;
using System;
using System.Text;

namespace LoginWPF
{
    /// <summary>
    /// Classe utilizzata per salvare tutti gli utenti registrati.
    /// </summary>
    internal class Utenti
    {
        /// <summary>
        /// Classe utilizzata per salvare i dati di un singolo utente.
        /// </summary>
        private struct Utente
        {
            public string name      { get; }    // nome dell'utente
            public string surname   { get; }    // cognome dell'utente
            public string username  { get; }    // username dell'utente
            public string password  { get; }    // password hashata dell'utente

            /// <summary>
            /// Classe utilizzata per salvare i dati di un singolo utente.
            /// </summary>
            /// <param name="name">Nome dell'utente registrato.</param>
            /// <param name="surname">Cognome dell'utente registrato.</param>
            /// <param name="username">Username dell'utente registrato.</param>
            /// <param name="password">Password dell'utente registrato.</param>
            public Utente(string name, string surname, string username, string password)
            {
                this.name = name;
                this.surname = surname;
                this.username = username;
                this.password = password;
            }
        }

        private string nomeFile = ""; // nome del file in cui vengono salvati i dati dell'utente
        private Dictionary<string, Utente> utentiRegistrati = new Dictionary<string, Utente>(); // dizionario in cui vengono salvati i dati di tutti gli utenti

        /// <summary>
        /// Classe utilizzata per salvare tutti gli utenti registrati.
        /// </summary>
        /// <param name="file">Nome del file da cui leggere i dati relativi agli utenti.</param>
        public Utenti(string file)
        {
            nomeFile = file;
            using (StreamReader sr = new StreamReader(file)) // lettura del file json
            {
                string data = sr.ReadToEnd(); // leggo tutto il file
                try
                {
                    utentiRegistrati = JsonSerializer.Deserialize<Dictionary<string, Utente>>(data); // deserializzo il json nel dizionario
                    if (utentiRegistrati != null ) // se è null la conversione non è andata a buon fine
                    {
                        utentiRegistrati = new Dictionary<string, Utente>();
                        throw new Exception();
                    }
                }
                catch // se c'è un eccezione la registrazione non è avvenuta
                {
                    MessageBox.Show("I dati relativi agli utenti sono corrotti," +
                                    " non è stato possibile ottenere i dati degli utenti.");
                }
                finally // chiudo il file per evitare errori nell'utilizzo del file
                {
                    sr.Close();
                }
            }
        }

        public bool RegistraUtente(string name, string surname, string username, string password)
        {
            if (utentiRegistrati.ContainsKey(username)) // se l'utente esiste già non può rifare il register
                return false;

            string hashedPassword;
            using (SHA256 sha256 = SHA256.Create()) // genero un oggetto sha256
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // eseguo l'hash della password
                hashedPassword = Convert.ToBase64String(bytes); // ottengo la codifica in base64 dell'hash
            }

            Utente utente = new Utente(name, surname, username, hashedPassword); // genero la struct dell'utente
            utentiRegistrati.Add(username, utente); // aggiungo l'utente alla lista

            using (StreamWriter sr = new StreamWriter(nomeFile)) // apro il file con i dati relativi agli utenti
            {
                string jsonDump = JsonSerializer.Serialize(utentiRegistrati); // serializzazione del dizionario con gli utenti
                sr.Write(jsonDump); // riscrivo tutto il file aggiornato
                sr.Close(); // chiudo il file per evitare errori
            }
            return true; // registrazione effetuata con successo
        }

        public bool AutenticaUtente(string username, string password)
        {
            string hashedPassword; // stringa con l'hash della password
            using (SHA256 sha256 = SHA256.Create()) // genero un oggetto sha256
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // eseguo l'hash della password
                hashedPassword = Convert.ToBase64String(bytes); // ottengo la codifica in base64 dell'hash
            }

            Utente utente;
            if (!utentiRegistrati.TryGetValue(username, out utente)) // se non esiste l'utente non si può fare il login
                return false;

            return utente.password == hashedPassword; // se la password è uguale allora il login è andato a buon fine
        }
    }
}
