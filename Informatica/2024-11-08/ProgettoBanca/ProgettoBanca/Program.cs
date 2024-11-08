/**********************************
* Alan Davide Bovo 4H 2024-10-29 *
*     Gestionale per banche      *
*********************************/

/// <summary>
/// Classe per memorizzare i dati di un cliente di una banca
/// </summary>
class Cliente
{
    #region Proprietà della classe cliente
    public readonly string nome;
    public readonly string cognome;
    public readonly string codiceFiscale;
    public double stipendio;
    #endregion

    #region Metodi per stampare dati del cliente
    // metodo per stampare i dati del cliente
    public void StampaCliente() => Console.WriteLine($"Cliente {nome} {cognome}, {codiceFiscale}, stipendio {stipendio}");
    #endregion

    #region Costruttori della classe cliente
    // costruttore per istanziare un cliente
    public Cliente(string nome, string cognome, string codiceFiscale, double stipendio)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.codiceFiscale = codiceFiscale;
        this.stipendio = stipendio;
    }
    // costruttore per istanziare un cliente nullo
    public Cliente() : this("?", "?", "?", -1) { }
    #endregion
}

/// <summary>
/// Classe per memorizzare i dati di un prestito semplice
/// </summary>
class PrestitoSemplice
{
    #region Proprietà della classe prestito
    public int capitale { get; private set; }
    public int interesse { get; private set; }
    public DateTime dataInizio { get; private set; }
    public DateTime dataFine { get; private set; }
    public string codiceFiscale { get; private set; }
    #endregion
    
    #region Metodi per il calcolo di dati relativi al prestito
    // metodo per il calcolo della rata annuale
    public double Rata() => capitale / Durata() / 12;
    // metodo per il calcolo del montante del prestito
    public virtual double Montante() => capitale * (1 + Durata() * interesse);
    // metodo per il calcolo della durata del prestito in anni
    public double Durata() => (dataFine - dataInizio).Days / 365;
    // metodo per stampare i dati del prestito
    public void StampaPrestito() => Console.WriteLine($"{capitale}€-{interesse}-{Durata()} anni-{codiceFiscale}-{Rata()},{Montante()}");
    #endregion

    #region Costruttore della classe
    public PrestitoSemplice(int capitale, int interesse, DateTime dataInizio, DateTime dataFine, string codiceFiscale)
    {
        this.capitale = capitale;
        this.interesse = interesse;
        this.dataInizio = dataInizio;
        this.dataFine = dataFine;
        this.codiceFiscale = codiceFiscale;
    }
    #endregion
}

/// <summary>
/// Classe per memorizzare i dati di un prestito composto
/// </summary>
class PrestitoComposto : PrestitoSemplice
{
    // override del calcolo del montante da semplice a complesso
    public override double Montante() => capitale * Math.Pow(1 + interesse, Durata());

    // costruttore della classe
    public PrestitoComposto(int capitale, int interesse, DateTime dataInizio, DateTime dataFine, string codiceFiscale)
        : base(capitale, interesse, dataInizio, dataFine, codiceFiscale) { }
}

/// <summary>
/// Classe per memorizzare i dati di una banca
/// </summary>
class Banca
{
    #region Liste contenenti i dati dei clienti e dei prestiti
    private List<Cliente> clienti = new List<Cliente>();
    private List<PrestitoSemplice> prestiti = new List<PrestitoSemplice>();
    #endregion

    #region Metodi per i clienti
    // funzione per aggiungere un cliente
    public void AddCliente(Cliente cliente) => clienti.Add(cliente);
    // funzione per rimuovere un cliente
    public void RemoveCliente(Cliente cliente) => clienti.Remove(cliente);
    // funzione per vedere se un cliente esiste nel "database della banca
    public Cliente SearchCliente(Cliente cliente)
    {
        for (int i = 0; i < clienti.Count; i++)
            if(clienti[i].codiceFiscale == cliente.codiceFiscale) return clienti[i];
        
        throw new Exception("Cliente non trovato");
    }
    #endregion

    #region Metodi per i prestiti
    // funzione per aggiungere un prestito nella banca
    public void AddPrestito(PrestitoSemplice prestito) => prestiti.Add(prestito);
    // funzione per trovare tutti i prestiti di un soggetto
    public List<PrestitoSemplice> SearchPrestiti(string codiceFiscale)
    {
        List<PrestitoSemplice> result = new List<PrestitoSemplice>();
        foreach(PrestitoSemplice prestitoSemplice in prestiti)
            if(prestitoSemplice.codiceFiscale == codiceFiscale)
                result.Add(prestitoSemplice);
        return result;
    }
    // funzione per calcolare il totale montante dei prestiti di un soggetto
    public double TotalePrestiti(string codiceFiscale) => SearchPrestiti(codiceFiscale).Sum(x => x.Montante());
    #endregion
}

namespace ProgettoBanca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca banca = new();

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ...");
            Console.ReadKey();
        }
    }
}
