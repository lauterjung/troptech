class Contact {
    constructor(firstName, lastName, phoneNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
    }
    toString() {
        return `${this.firstName} ${this.lastName} | ${this.phoneNumber}`;
    }
}

let contactList = [];

function getContact() {
    firstName = document.querySelector("#firstName").value;
    lastName = document.querySelector("#lastName").value;
    phoneNumber = document.querySelector("#phoneNumber").value;
    return new Contact(firstName, lastName, phoneNumber);
}

function registerContact() {
    contactList.push(getContact());
    updateContacts();
}

function removeContact() {
    contactList.pop();
    updateContacts();
};

function updateContacts() {
    document.querySelector("#contactList").innerText = '';
    for (let i = 0; i < contactList.length; i++) {
        document.querySelector("#contactList").innerHTML += `Índice[${i}]: ` + contactList[i].toString() + "<br>";
    };
};

function searchContact() {
    let searchedContact = document.querySelector("#searchBox").value;

    document.querySelector("#contactList").innerText = '';
    contactList.forEach(element => {
        if (element.firstName == searchedContact) {
            document.querySelector("#contactList").innerHTML += `Índice[${contactList.indexOf(element)}]: ` + element.toString() + "<br>";
        }
    });
    
};
