const submitButton = document.getElementById("buttonSubmit");
const nextPageButton = document.getElementById("buttonNextPage");
const removeLocalStorageButton = document.getElementById("removeLocalStorageButton");
const form = document.getElementById("clientForm");
const table = document.getElementById("tableData");

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

function loadTable() {
    let clients = localStorageToArray();

    for (let i = 0; i < clients.length; i++) {
        let row = table.insertRow();
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);

        cell1.textContent = `${clients[i].name}`;
        cell2.textContent = `${clients[i].cpf}`;
        cell3.textContent = `${clients[i].birthDate}`;
        cell4.textContent = `${clients[i].observation}`;
    }
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

    }
    form.classList.add("was-validated")
}, false)

window.addEventListener("load", () => {
    console.log("loaded");
    loadTable();
}, false);

nextPageButton.addEventListener("click", () => {
    changePage();
}, false);