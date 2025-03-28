/*
 * Alan Davide Bovo 4H 2025-03-21
 * Sito per convalidazione dati
 */
// Attende che il DOM sia completamente caricato
$(document).ready(function () {

    // Aggiunge metodo di validazione 'validName' per nomi validi (solo lettere/spazi, max 25 caratteri)
    $.validator.addMethod("validName", function (value) {
        return /^[a-zA-Z ]+$/.test(value) && value.length <= 25;
    }, "Name must contain only letters and spaces (1-25 characters).");

    // Aggiunge metodo 'validBirthdate' per date di nascita valide (età 1-99 anni)
    $.validator.addMethod("validBirthdate", function (value) {
        const date = new Date(value); // Converte la data inserita
        const currDate = new Date(); // Ottiene data corrente
        if (date >= currDate) return false; // Data futura non valida
        const age = currDate.getFullYear() - date.getFullYear(); // Calcola età
        return age > 0 && age < 100; // Verifica range età
    }, "You must be between 1 and 99 years old.");

    // Aggiunge metodo 'validUsername' per username validi (1-25 caratteri consentiti)
    $.validator.addMethod("validUsername", function (value) {
        return /^[a-zA-Z0-9._-]{1,25}$/.test(value); // Pattern consentito
    }, "Username can include letters, numbers, ., _, - (1-25 characters).");

    // Aggiunge metodo 'validPassword' per password sicure (8-30 caratteri con numero/simbolo)
    $.validator.addMethod("validPassword", function (value) {
        if (value.length < 8 || value.length > 30) return false; // Verifica lunghezza
        let hasNum = false, hasSym = false; // Flag per numeri/simboli
        for (const char of value) { // Controlla ogni carattere
            if (!isNaN(char)) hasNum = true; // Rileva numeri
            if ('!@#^&%*$?'.includes(char)) hasSym = true; // Rileva simboli
        }
        return hasNum || hasSym; // Richiede almeno un numero o simbolo
    }, "Password must be 8-30 characters with at least a number or special symbol.");

    // Configurazione validazione form
    $("#loginForm").validate({
        rules: { // Regole di validazione per ogni campo
            name: { required: true, validName: true },
            surname: { required: true, validName: true },
            birthdate: { required: true, validBirthdate: true },
            username: { required: true, validUsername: true },
            email: { required: true, email: true },
            password: { required: true, validPassword: true }
        },
        messages: { // Messaggi errore personalizzati
            email: "Please enter a valid email address."
        },
        errorElement: "div", // Elemento HTML per errori
        errorClass: "error invalid-feedback", // Classe CSS per errori
        highlight: function (element) { // Evidenziazione errori
            $(element).addClass('is-invalid').removeClass('is-valid');
        },
        unhighlight: function (element) { // Rimozione evidenziazione
            $(element).addClass('is-valid').removeClass('is-invalid');
        },
        submitHandler: function (form) { // Azione al submit valido
            alert('Your data has been submitted successfully');
            form.submit();
        },
        invalidHandler: function () { // Azione in caso di errori
            alert('There are errors in your form');
        }
    });
});