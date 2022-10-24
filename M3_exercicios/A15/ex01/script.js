const submitButton = document.getElementById("buttonSubmit");
const nextPageButton = document.getElementById("buttonNextPage");
const removeLocalStorageButton = document.getElementById("removeLocalStorageButton");
const form = document.getElementById("clientForm");

class Client {
    constructor(name, cpf, birthDate, observation) {
        this.name = name;
        this.cpf = cpf;
        this.birthDate = birthDate;
        this.observation = observation;
    }
}

function newClient() {
    let name = document.getElementById("name").value;
    let cpf = document.getElementById("cpf").value;
    let birthDate = document.getElementById("birthDate").value;
    let observation = document.getElementById("observation").value;

    return new Client(name, cpf, birthDate, observation);
};

function localStorageToArray() {
    let stringClientsFromMemory = window.localStorage.getItem("clients");

    if (stringClientsFromMemory === "undefined" || !stringClientsFromMemory) {
        return [];
    }

    return (JSON.parse(stringClientsFromMemory));
}

function clientToArray() {
    let clients = localStorageToArray();
    clients.push(newClient());

    return (clients);
}

function arrayToLocalStorage() {
    let clientsString = JSON.stringify(clientToArray());
    console.log(clientsString);
    window.localStorage.setItem("clients", clientsString);
}

function clearLocalStorage() {
    window.localStorage.removeItem("clients");
}

function changePage() {
    document.location.href = "lista-clientes.html";
}

removeLocalStorageButton.addEventListener("click", () => {
    clearLocalStorage();
}, false)

form.addEventListener("submit", event => {
    event.preventDefault()
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
    } else {
        window.alert("Salvo com sucesso!");
        arrayToLocalStorage();
        changePage();
    }
    form.classList.add("was-validated")
}, false)

nextPageButton.addEventListener("click", () => {
    changePage();
}, false);