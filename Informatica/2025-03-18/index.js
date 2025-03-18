$(document).ready(function () {
    controlla_saldo();
    $("#saldo").text(window.localStorage["saldo"] + "€"); // Mostro il saldo nella pagina
    controlla_saldo();
});

/* Funzione per controllare se il saldo ha un valore valido */
function controlla_saldo() {
    const saldo = parseInt(window.localStorage["saldo"]); // Lettura del saldo dal localStorage
    if (!isFinite(saldo)) { // Il valore non è valido
        ricomincia(); // Saldo impostato di default a 50
    }
    if (saldo === 0) { // Se il saldo è pari a 0
        $("#ricomincia").removeAttr("hidden"); // Mostro il bottone per ricominciare
    }
}

/* Funzione per ricominciare la partita */
function ricomincia() {
    window.localStorage["saldo"] = 50;
    location.reload();
}

/* Funzione per gestire una giocata */
function gioca() {
    // Lettura della quantità scommessa
    const scommessa = $("#scommessa").val();
    // Lettura del numero scommesso
    const numero = $("#numero").val();
    
    const s = parseInt(scommessa); // Parsing della scommessa
    const n = parseInt(numero); // Parsing del numero scommesso
    
    // Controllo del numero scommesso
    if (!isFinite(n) || n < 1 || n > 12) {
        alert("Il numero inserito non è nel range [1; 12]"); // Il valore non è valido
        return;
    }
    
    controlla_saldo();
    
    // Lettura del saldo dell'utente
    let saldo = parseInt(window.localStorage["saldo"]);
    
    // Controllo della scommessa
    if (!isFinite(s) || s > saldo || s < 0) {
        alert("La scommessa non è valida, riprova"); // Scommessa non valida
        return;
    }
    
    const dado1 = Math.floor(Math.random() * 6) + 1; // Calcolo del valore del primo dado
    const dado2 = Math.floor(Math.random() * 6) + 1; // Calcolo del valore del secondo dado

    if (dado1 + dado2 === n) { // Se la somma è uguale al numero scommesso
        saldo += s; // Aggiungo la vincita al saldo
        alert("Hai vinto complimenti!"); // Messaggio all'utente
    } else {
        saldo -= s; // Rimuovo la quantità scommessa
    }

    // Aggiorno il saldo nello storage e nella pagina
    window.localStorage["saldo"] = saldo;
    $("#saldo").text(saldo + "€");

    // Rimuovo i dadi, se presenti, della giocata precedente
    const giocata = $("#giocata");
    if (giocata.children().length > 1) {
        giocata.empty(); // Rimuovo tutti i figli
    }

    // Aggiungo i dadi della giocata corrente
    giocata.append(`<h1 class="bi bi-dice-${dado1} mx-2"></h1>`);
    giocata.append(`<h1 class="bi bi-dice-${dado2} mx-2"></h1>`);

    // Ricontrollo il saldo
    controlla_saldo();
}