const returnButton = document.getElementById("returnButton");
const table = document.getElementById("tableData");

function localStorageToArray() {
    let stringClientsFromMemory = window.localStorage.getItem("clients");

    if (stringClientsFromMemory === "undefined" || !stringClientsFromMemory) {
        return [];
    }

    return (JSON.parse(stringClientsFromMemory));
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
    document.location.href = "index.html";
}

window.addEventListener("load", () => {
    console.log("loaded");
    loadTable();
}, false);

returnButton.addEventListener("click", () => {
    changePage() 
}, false);

