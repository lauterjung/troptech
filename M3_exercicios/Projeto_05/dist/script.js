var table = document.getElementById("tableData");
var submitButton = document.getElementById("submitButton");
var formDropDown = document.getElementById("form-select");
var formNumeroConta = document.getElementById("numeroConta");
var formValor = document.getElementById("valor");
var MSG_OPERACAO_INVALIDA = "Selecione uma operação!";
var MSG_NUMERO_INVALIDO = "O valor precisa ser maior que zero!";
var MSG_CONTA_NAO_ENCONTRADA = "Conta não encontrada!";
var MSG_SAQUE_SUCESSO = "Saque realizado com sucesso!";
var MSG_DEPOSITO_SUCESSO = "Depósito realizado com sucesso!";
var conta0 = new ContaCorrente("0.000.000-0", "0000-0", "000.000.000-00", 0);
var conta1 = new ContaCorrente("1.111.111-1", "1111-1", "111.111.111-11", 100);
var conta2 = new ContaCorrente("2.222.222-2", "2222-2", "222.222.222-22", 200);
var conta3 = new ContaCorrente("3.333.333-3", "3333-3", "333.333.333-33", 300);
var conta4 = new ContaCorrente("4.444.444-4", "4444-4", "444.444.444-44", 400);
var conta5 = new Poupanca("5.555.555-5", "5555-5", "555.555.555-55");
var conta6 = new Poupanca("6.666.666-6", "6666-6", "666.666.666-66");
var conta7 = new Poupanca("7.777.777-7", "7777-7", "777.777.777-77");
var conta8 = new Poupanca("8.888.888-8", "8888-8", "888.888.888-88");
var conta9 = new Poupanca("9.999.999-9", "9999-9", "999.999.999-99");
var contasBancarias = [conta0, conta1, conta2, conta3, conta4, conta5, conta6, conta7, conta8, conta9];
function loadTable() {
    for (var i = 0; i < contasBancarias.length; i++) {
        var row = table.insertRow();
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);
        var cell5 = row.insertCell(4);
        cell1.textContent = "".concat(contasBancarias[i].numero);
        cell2.textContent = "".concat(contasBancarias[i].agencia);
        cell3.textContent = "".concat(contasBancarias[i].tipo);
        cell4.textContent = "".concat(contasBancarias[i].cpf);
        cell5.textContent = "R$ ".concat(contasBancarias[i].saldo.toFixed(2));
    }
}
function cleanTable() {
    while (table.rows.length > 0) {
        table.deleteRow(0);
    }
}
function manipuladorOperacao() {
    var valor = formValor.valueAsNumber;
    var inputNumeroConta = formNumeroConta.value;
    var contaSelecionada = contasBancarias.filter(function (person) { return person.numero === inputNumeroConta; })[0];
    if (!contaSelecionada) {
        window.alert(MSG_CONTA_NAO_ENCONTRADA);
        return;
    }
    if (valor <= 0) {
        window.alert(MSG_NUMERO_INVALIDO);
        return;
    }
    if (formDropDown.value === "1") {
        window.alert(MSG_OPERACAO_INVALIDA);
        return;
    }
    else if (formDropDown.value === "2") {
        var saque = contaSelecionada.sacar(valor);
        if (saque === false) {
            window.alert("Saldo insuficiente! O saldo atual \u00E9 de R$ ".concat(contaSelecionada.saldo.toFixed(2), "."));
            return;
        }
        window.alert(MSG_SAQUE_SUCESSO);
    }
    else if (formDropDown.value === "3") {
        var deposito = contaSelecionada.depositar(valor);
        if (deposito === false) {
            return;
        }
        window.alert(MSG_DEPOSITO_SUCESSO);
    }
    cleanTable();
    loadTable();
}
submitButton.addEventListener("click", manipuladorOperacao);
loadTable();
