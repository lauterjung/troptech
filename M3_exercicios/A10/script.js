// ex 01
function sum() {
    let number_1 = document.querySelector("#firstNumber").valueAsNumber;
    let number_2 = document.querySelector("#secondNumber").valueAsNumber;
    let result = number_1 + number_2;
    document.querySelector("h4").innerText = "Resultado: " + result;
}

function subtract() {
    let number_1 = document.querySelector("#firstNumber").valueAsNumber;
    let number_2 = document.querySelector("#secondNumber").valueAsNumber;
    let result = number_1 - number_2;
    document.querySelector("h4").innerText = "Resultado: " + result;
}

function multiply() {
    let number_1 = document.querySelector("#firstNumber").valueAsNumber;
    let number_2 = document.querySelector("#secondNumber").valueAsNumber;
    let result = number_1 * number_2;
    document.querySelector("h4").innerText = "Resultado: " + result;
}

function divide() {
    let number_1 = document.querySelector("#firstNumber").valueAsNumber;
    let number_2 = document.querySelector("#secondNumber").valueAsNumber;
    let result = number_1 / number_2;
    document.querySelector("h4").innerText = "Resultado: " + result;
}

function power() {
    let number_1 = document.querySelector("#firstNumber").valueAsNumber;
    let number_2 = document.querySelector("#secondNumber").valueAsNumber;
    let result = number_1 ** number_2;
    document.querySelector("h4").innerText = "Resultado: " + result;
}

function calculate() {
    let operation = document.querySelector("#operation").value;
    switch (operation) {
        case "+":
            sum();
            break;
        case "-":
            subtract();
            break;
        case "x":
            multiply();
            break;
        case "/":
            divide();
            break;
        case "^":
            power();
            break;
    }
}

function validate() {
    let array = [];

    if (!isValidName()) {
        array.push("O campo nome deve ter no mínimo 6 caracteres!")
    }

    if (!isValidAge()) {
        array.push("O campo idade deve ser maior que 0!")
    }

    if (!isValidCpf()) {
        array.push("O campo CPF deve conter 11 caracteres!")
    }

    if (array.length !== 0) {
        document.querySelector("#validate-text").style.color = "red";
        document.querySelector("#validate-text").innerHTML = array.join("<br>");
    } else {
        document.querySelector("#validate-text").style.color = "green";
        document.querySelector("#validate-text").textContent = "* Campos válidos!";
    }

}

function isValidName() {
    let name = document.querySelector("#name").value;
    return name.length >= 6 ? true : false;
}

function isValidAge() {
    let age = document.querySelector("#age").value;
    return age.length > 0 ? true : false;
}

function isValidCpf() {
    let cpf = document.querySelector("#cpf").value;
    return cpf.length === 11 ? true : false;
}