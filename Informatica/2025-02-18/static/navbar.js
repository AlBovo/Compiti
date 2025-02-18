let counter = 0; // Inizializza la variabile 'counter' a 0.

window.onload = function(){
    // Ottiene il nome della pagina corrente dalla URL e lo prepara per l'uso
    let page = document.location.pathname.substring(1);
    page = page.split('/').pop(); // Ottiene l'ultima parte della path
    page = page.replace(".html", ""); // Rimuove l'estensione '.html'
    page = page.replace("index", ""); // Rimuove 'index' se presente
    
    // Aggiunge la classe "active" al link di navigazione relativo alla pagina corrente
    document.getElementById(`nav${page}`).classList.add("active");

    // Ottiene il valore del contatore dal localStorage e lo visualizza
    document.getElementById('countern').innerText = counter = parseInt(window.localStorage.getItem('count')) || 0;

    // Aggiunge un listener al click del contatore per aumentare il valore e salvarlo
    document.getElementById("counter").addEventListener("click", function(){
        counter += 1; // Incrementa il contatore
        document.getElementById("countern").innerText = counter; // Mostra il nuovo valore
        window.localStorage.setItem('count', counter); // Salva il valore nel localStorage

        // Se il contatore arriva a 420, mostra un messaggio speciale
        if(counter === 420){
            alert(atob("UGVyY2joIGNsaWNjaGkgNDIwIHZvbHRlIGlsIG1pbyBub21lPz8/"));
            counter = 0; // Resetta il contatore
        }
        console.log(counter); // Stampa il valore del contatore nella console
    });
};

function refresh(){
    // Resetta il contatore e ricarica la pagina
    counter = 0;
    window.localStorage.setItem('count', counter); // Salva il contatore resettato nel localStorage
    window.location.reload(); // Ricarica la pagina
}
