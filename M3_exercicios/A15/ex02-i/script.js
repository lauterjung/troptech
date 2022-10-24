class Product {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }
}

const LOCAL_STORAGE_STRING = "clients";

const products =
    [
        new Product("Produto 1", 35.00),
        new Product("Produto 2", 45.00),
        new Product("Produto 3", 55.00),
        new Product("Produto 4", 65.00),
        new Product("Produto 5", 75.00),
        new Product("Produto 6", 85.00)
    ];

function localStorageToArray() {
    let stringClientsFromMemory = window.localStorage.getItem(LOCAL_STORAGE_STRING);

    if (stringClientsFromMemory === "undefined" || !stringClientsFromMemory) {
        return [];
    }

    return (JSON.parse(stringClientsFromMemory));
}

function addToCart(product) {
    let cart = localStorageToArray();
    cart.push(product);
    arrayToLocalStorage(cart);
}

function arrayToLocalStorage(array) {
    let arrayString = JSON.stringify(array);
    window.localStorage.setItem(LOCAL_STORAGE_STRING, arrayString);
}

function populateProducts() {
    const cards = document.querySelectorAll('.card-body')
    let cardsArray = Array.from(cards);

    for (let i = 0; i < cardsArray.length; i++) {
        cardsArray[i].querySelector(".card-title").textContent = products[i].name;
        cardsArray[i].querySelector(".product-price").textContent = "R$ " + (products[i].price).toFixed(2);
        cardsArray[i].querySelector(".btn").addEventListener("click", () => {
            addToCart(products[i])
        }, false);
    }
}

populateProducts()