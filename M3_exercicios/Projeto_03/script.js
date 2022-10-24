// Código do bootstrap para validar input de formulário:
// // Example starter JavaScript for disabling form submissions if there are invalid fields
(() => {
    'use strict'

    // // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('focusout', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }
            form.classList.add('was-validated')
        }, false)
    })
})()
// Final do código bootstrap para validar formulário

const productList = [];

class Product {
    constructor(name, price, quantity) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    get totalPrice() {
        return this.calculateTotalPrice();
    }

    calculateTotalPrice() {
        return this.price * this.quantity;
    }
    isValidName() {
        return this.name ? true : false;
    }
    isValidPrice() {
        return this.price > 0 ? true : false;
    }
    isValidQuantity() {
        return (Number.isInteger(Number(this.quantity)) && this.quantity > 0) ? true : false;
    }
    isValidProduct() {
        return (this.isValidName() && this.isValidPrice() && this.isValidQuantity()) ? true : false;
    }
}

function createProduct() {
    let productName = document.querySelector("#productName").value;
    let productPrice = document.querySelector("#productPrice").value;
    let productQuantity = document.querySelector("#productQuantity").value;

    return new Product(productName, productPrice, productQuantity);
}

function registerProduct() {
    let product = createProduct();

    if (!product.isValidProduct()) {
        return;
    }

    for (let i = 0; i < productList.length; i++) {
        if (productList[i].name === product.name) {
            productList[i].quantity = Number(productList[i].quantity) + Number(product.quantity);
            showProducts();
            return;
        }
    }

    productList.push(product);
    showProducts();
}

function addOne(i) {
    productList[i].quantity = Number(productList[i].quantity) + 1;
    showProducts();
}

function removeOne(i) {
    productList[i].quantity = Number(productList[i].quantity) - 1;

    if (productList[i].quantity === 0) {
        removeProduct(i);
        return;
    }

    showProducts();
}

function removeProduct(i) {
    productList.splice(i, 1);
    showProducts();
}

function getFinalPrice() {
    let sum = 0;

    productList.forEach(element => {
        sum += element.totalPrice;
    });

    return sum;
}

function showProducts() {
    str = `<tbody>`;
    for (let i = 0; i < productList.length; i++) {
        str += `<tr>`;
        str += `<td>` + (i + 1) + `</td>`;
        str += `<td>` + productList[i].name + `</td>`;
        str += `<td>` + productList[i].quantity + `</td>`;
        str += `<td>` + `R$ ` + Number(productList[i].price).toFixed(2) + `</td>`;
        str += `<td>` + `R$ ` + Number(productList[i].totalPrice).toFixed(2) + `</td>`;
        str += `<td>` + `<button type="button" class="btn btn-success btn-sm" onclick="addOne(` + i + `)">+</button>` + `</td>`;
        str += `<td>` + `<button type="button" class="btn btn-dark btn-sm" onclick="removeOne(` + i + `)">-</button>` + `</td>`;
        str += `<td>` + `<button type="button" class="btn btn-danger btn-sm" onclick="removeProduct(` + i + `)">x</button>` + `</td>`;
        str += `</tr>`;
    };
    str += `</tbody>`
    document.querySelector("#tableData").innerHTML = str;
    document.querySelector("#finalPrice").textContent = `Preço total: R$ ` + getFinalPrice().toFixed(2);
};

const node = document.getElementById("submitButton");
node.addEventListener('keydown', function onEvent(event) {
    if (event.key === "Enter") {
        return false;
    }
});