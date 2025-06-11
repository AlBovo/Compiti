/**********************************
* Alan Davide Bovo 4H 2024-10-29 *
*     Gestionale per banche      *
*********************************/

class Cliente
{
    public readonly string nome;
    public readonly string cognome;
    public readonly string codiceFiscale;
    public double stipendio { get; set; }
    private List<PrestitoSemplice> list = new List<PrestitoSemplice>();

    public Cliente(string nome, string cognome, string codiceFiscale, double stipendio)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.codiceFiscale = codiceFiscale;
        this.stipendio = stipendio;
    }
    public Cliente() : this("?", "?", "?", -1) { }

    public void StampaCliente() => Console.WriteLine($"Cliente {nome} {cognome}, {codiceFiscale}, stipendio {stipendio}");
}

class PrestitoSemplice
{
    public int capitale { get; private set; }
    public int interesse { get; private set; }
    public DateTime dataInizio { get; private set; }
    public DateTime dataFine { get; private set; }
    public string codiceFiscale { get; private set; }
    public double rata { get; private set; }
    public virtual double montante { get; protected set; }
    public double durata { get; private set; }

    public PrestitoSemplice(int capitale, int interesse, DateTime dataInizio, DateTime dataFine, string codiceFiscale, double rata)
    {
        this.capitale = capitale;
        this.interesse = interesse;
        this.dataInizio = dataInizio;
        this.dataFine = dataFine;
        this.codiceFiscale = codiceFiscale;
        this.rata = rata;
        
        /* TODO this */
        //this.montante = montante;
        durata = (dataFine - dataInizio).Days;
    }

    public void StampaPrestito() { /* TODO */ }
}

class PrestitoComposto : PrestitoSemplice
{
    public override double montante { get; protected set; }
    public PrestitoComposto(int capitale, int interesse, DateTime dataInizio, DateTime dataFine, string codiceFiscale, double rata)
        : base(capitale, interesse, dataInizio, dataFine, codiceFiscale, rata) { }
}

class Banca
{
    private List<Cliente> clienti = new List<Cliente>();

    public void AddCliente(Cliente cliente) => clienti.Add(cliente);
    public void RemoveCliente(Cliente cliente) => clienti.Remove(cliente);
    public Cliente SearchCliente(Cliente cliente)
    {
        for (int i = 0; i < clienti.Count; i++)
            if(clienti[i].Equals(cliente)) return clienti[i];
        
        throw new Exception("Cliente non trovato");
    }
}

namespace ProgettoBanca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrestitoComposto prestito = new PrestitoComposto();
            Console.WriteLine("Hello, World!");
        }
    }
}
