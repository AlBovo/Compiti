// A string containing special symbols to be used in password validation
const symbols = '!@#^&%*$?';

// Function to validate the user's name or surname
function checkName(name) {
    // Regular expression to allow only letters and spaces, and limit the length to 1-25 characters
    const regex = /[a-z ]{1,25}$/i;
    return regex.test(name);  // Returns true if the name matches the regex pattern
}

// Function to validate the user's birthdate
function checkBirth(birth) {
    const date = new Date(birth);  // Convert birthdate string into a Date object
    const currDate = new Date();   // Get the current date

    // If the birthdate is in the future, return false
    if (date >= currDate) return false;

    const age = currDate.getFullYear() - date.getFullYear();  // Calculate age based on the current year
    // If age is less than or equal to 0 or greater than or equal to 100, return false
    if (age <= 0 || age >= 100) return false;

    return true;  // Return true if the age is valid
}

// Function to validate the username
function checkUsername(username) {
    // Regular expression to allow letters, numbers, dots, underscores, and hyphens, and limit the length to 1-25 characters
    const regex = /[a-z0-9._-]{1,25}$/i;
    return regex.test(username);  // Returns true if the username matches the regex pattern
}

// Function to validate the password
function checkPassword(password) {
    // Check if password length is between 8 and 30 characters
    if (password.length < 8 || password.length > 30) return false;
    
    let num = false;  // Variable to check if the password contains a number
    let sym = false;  // Variable to check if the password contains a symbol

    // Loop through each character in the password to check if it contains a number or symbol
    for (let i = 0; i < password.length; i++) {
        num |= '0' <= password[i] && password[i] <= '9';  // Check if it's a number
        for (let e = 0; e < symbols.length; e++) {
            // Check if the character matches any of the defined symbols
            sym |= password[i] == symbols[e];
        }
    }

    // Returns true if the password contains either a number or a symbol
    return num || sym;
}

// Function to validate the email (currently empty)
function checkEmail(email) {
    // https://stackoverflow.com/a/8829363
    const regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/
    return regex.test(email);
}

// Main function to check all the fields when the user submits the form
async function check() {
    // Get the values of the input fields using jQuery
    const name = $('#name')[0].value;
    const surname = $('#surname')[0].value;
    const birthdate = $('#birthdate')[0].value;
    const username = $('#username')[0].value;
    const email = $('#email')[0].value;
    const password = $('#password')[0].value;

    // Validate all fields; if all are valid, show a success message, otherwise show an error
    if (checkName(name) && checkName(surname) && checkBirth(birthdate) &&
        checkUsername(username) && checkPassword(password) && checkEmail(email)) {
        alert('Your data has been submitted successfully');    
    } else {
        alert('There\'s an error in your data');  // Show error message if any validation fails
    }
}