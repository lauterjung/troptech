(() => {
    'use strict'

    // // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            } else {
                contactToTable();
            }
            form.classList.add('was-validated')
        }, false)
    })
})()

const table = document.getElementById("tableData");

class Contact {
    constructor(name, phoneNumber) {
        this.name = name;
        this.phoneNumber = phoneNumber;
    }
}

function newContact() {
    let formName = document.getElementById("name").value;
    let formPhoneNumber = document.getElementById("phoneNumber").value;
    return new Contact(formName, formPhoneNumber);
};

function contactToTable() {
    let contact = newContact();

    let row = table.insertRow();
    let cell1 = row.insertCell(0);
    let cell2 = row.insertCell(1);
    let cell3 = row.insertCell(2);

    cell1.textContent = `${contact.name}`;
    cell2.textContent = `${contact.phoneNumber}`;
    cell3.textContent = "Pendente";
}

const manipuladorClick = (event) => {
    let clickedTd = event.target;
    clickedTd.parentNode.childNodes[2].textContent = "Feito";
};

table.addEventListener("click", manipuladorClick);