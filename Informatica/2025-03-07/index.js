/* Evento chiamato al caricamento della pagina */
window.onload = () => {
    controlla_saldo();
    document.getElementById("saldo").innerText = `${window.localStorage["saldo"]}€`; // mostro il saldo nella pagina
    controlla_saldo();
};
/* Funzione per controllare se il saldo ha un valore valido */
function controlla_saldo() {
    const saldo = parseInt(window.localStorage["saldo"]); // lettura del saldo dal localstore
    if (!isFinite(saldo)) // il valore non è valido
        ricomincia(); // saldo impostato di default a 50
    if (saldo === 0) // se il saldo è pari a 0
        document.getElementById("ricomincia").removeAttribute("hidden"); // mostro il bottone per ricominciare
}
/* Funzione per ricominciare la partita */
function ricomincia() {
    window.localStorage["saldo"] = 50;
    window.location.reload();
}
/* Funzione per gestire una giocata */
function gioca(){
    // lettura della quantità scommessa
    const scommessa = document.getElementById("scommessa");
    // lettura del numero scomesso
    const numero = document.getElementById("numero");
    
    const s = parseInt(scommessa.value); // parsing della scommessa
    const n = parseInt(numero.value); // parsing del numero scommesso
    
    // controllo del numero scommesso
    if (!isFinite(n) || n < 1 || n > 12) {
        alert("Il numero inserito non è nel range [1; 12]"); // il valore non è valido
        return;
    }
    controlla_saldo();
    // lettura del saldo dell'utente
    let saldo = parseInt(window.localStorage["saldo"]);
    // controllo della scommessa
    if (!isFinite(s) || s > saldo || s < 0) {
        alert("La scommessa non è valida, riprova"); // scommessa non valida
        return;
    }
    
    const dado1 = Math.floor(Math.random()*6) + 1; // calcolo del valore del primo dado
    const dado2 = Math.floor(Math.random()*6) + 1; // calcolo del valore del secondo dado

    if (dado1 + dado2 === n) { // se la somma è uguale al numero scommesso
        saldo += s; // aggiungo la vincita al saldo
        alert("Hai vinto complimenti!"); // messaggio all'utente
    }
    else {
        saldo -= s; // rimuovo la quantità scommessa
    }

    // aggiorno il saldo nello storage e nella pagina
    window.localStorage["saldo"] = saldo;
    document.getElementById("saldo").innerText = `${saldo}€`;

    // rimuovo i dadi, se presenti, della giocata precedente
    const giocata = document.getElementById("giocata");
    if (giocata.children.length > 1) {
        for (let i = 0; i < 2; i++)
            giocata.removeChild(giocata.lastChild);
    }

    // aggiungo i dadi della giocata corrente
    giocata.innerHTML += `<h1 class="bi bi-dice-${dado1} mx-2"></h1>`
    giocata.innerHTML += `<h1 class="bi bi-dice-${dado2} mx-2"></h1>`

    // ricontrollo il saldo
    controlla_saldo();
}