/**********************************
* Alan Davide Bovo 4H 2024-11-15 *
*  Classe per Dijkstra su grafi  *
*********************************/

namespace Grafi
{
    public class GrafoDiretto
    {
        #region struct per salvare le informazioni su un arco
        public struct Arco
        {
            public int nodo_partenza;   // nodo di partenza dall'arco
            public int nodo_arrivo;     // nodo di arrivo dell'arco
            public int costo;           // costo dell'arco
        }
        #endregion

        #region struct per salvare le informazioni su un nodo
        protected struct Nodo
        {
            public string nome;                     // nome del nodo
            public List<Arco> uscenti, entranti;    // lista di archi entranti e uscenti dal nodo
        }
        #endregion

        protected List<Nodo> nodi;  // lista di nodi del grafo
        protected int index = 0;    // indice in cui allocare il prossimo nodo
        public int NumeroNodi { get => nodi.Count; } // proprietà per ritornare il numero totale di nodi

        // costruttore della classe in cui viene inizializzata la lista di nodi
        public GrafoDiretto(int numero_max_nodi = 1000) => nodi = new List<Nodo>(numero_max_nodi);

        #region metodi della classe
        public void AggiungiNodo(string nome)
        {
            if (index == nodi.Capacity) // raggiunta la massima capacità della lista impostata nel costruttore
                throw new Exception("Il grafo è pieno di nodi, è impossibile aggiungerne altri");

            // aggiunta del nodo nella lista
            nodi.Add(
                new Nodo
                {
                    nome = nome,
                    entranti = new List<Arco>(),
                    uscenti = new List<Arco>()
                }
            );
            index++;
        }

        // metodo per aggiungere un arco
        public void AggiungiArco(string nome_nodo_partenza, string nome_nodo_arrivo, int costo)
        {
            // conversione dei dati passati alla funzione in un'istanza della struct arco

            // conversione dei nomi in indici
            int nodo_partenza = this[nome_nodo_partenza];
            int nodo_arrivo = this[nome_nodo_arrivo];
            
            // creazione dell'istanza dell'arco
            Arco arco = new Arco 
            {
                nodo_partenza = nodo_partenza, 
                nodo_arrivo = nodo_arrivo, 
                costo = costo
            };

            // chiamata alla stessa funzione con firma diversa
            AggiungiArco(arco);
        }

        // metodo virtual per aggiungere un arco
        public virtual void AggiungiArco(Arco arco)
        {
            // controllo dell'indice dei nodi
            if (!ControllaIndiceNodo(arco.nodo_partenza)) 
                throw new ArgumentException("Nodo non ancora inserito nel grafo");
            if (!ControllaIndiceNodo(arco.nodo_arrivo)) 
                throw new ArgumentException("Nodo non ancora inserito nel grafo");

            nodi[arco.nodo_arrivo].entranti.Add(arco); // aggiunta dell'arco negli entranti dell'arrivo
            nodi[arco.nodo_partenza].uscenti.Add(arco); // aggiunta dell'arco negli uscenti della partenza
        }
        
        // metodo per controllare se l'indice di un nodo è valido
        public bool ControllaIndiceNodo(int nodo) => nodo < index;
        #endregion

        #region indicizzatori della classe
        // indicizzatore per ottenere il nome di un nodo dal suo indice
        public string this[int nodo] { get => nodi[nodo].nome; }

        // indicizzatore per ottenere l'indice di un nodo dal suo nome
        public int this[string nome_nodo]
        {
            get
            {
                for (int i = 0; i < nodi.Count; i++)
                    if (nodi[i].nome == nome_nodo)
                        return i; // se trovato ritorno l'indice
                return -1; // se non trovato ritorno -1
            }
        }
        #endregion

        #region enumerazioni degli archi entranti e uscenti
        public IEnumerable<Arco> ArchiUscenti(int nodo) => nodi[nodo].uscenti;

        public IEnumerable<Arco> ArchiEntranti(int nodo) => nodi[nodo].entranti;
        #endregion

        public class GrafoNonDiretto : GrafoDiretto
        {
            // richiamo il costruttore della classe base
            public GrafoNonDiretto(int numero_max_nodi = 1000) : base(numero_max_nodi) { }

            // metodo per aggiungere un arco nel grafo non diretto
            public override void AggiungiArco(Arco arco)
            {
                // controllo dell'indice dei nodi
                if (!ControllaIndiceNodo(arco.nodo_partenza)) 
                    throw new ArgumentException("Nodo non ancora inserito nel grafo");
                if (!ControllaIndiceNodo(arco.nodo_arrivo)) 
                    throw new ArgumentException("Nodo non ancora inserito nel grafo");

                #region aggiunta degli archi in entrambi le liste di entrambi i nodi
                nodi[arco.nodo_arrivo].entranti.Add(arco);
                nodi[arco.nodo_arrivo].uscenti.Add(arco);
                nodi[arco.nodo_partenza].entranti.Add(arco);
                nodi[arco.nodo_partenza].uscenti.Add(arco);
                #endregion
            }
        }
    }
}