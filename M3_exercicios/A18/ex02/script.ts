class Product {
    description: string;
    price: number;
    quantity: number;
    isExpired: boolean;

    constructor(description: string, price: number, quantity: number, isExpired: boolean) {
        this.description = description;
        this.price = price;
        this.quantity = quantity;
        this.isExpired = isExpired;
    }
}

let product1 = new Product("A", 1, 5.5, false);
let product2 = new Product("B", 2, 8, true);
let product3 = new Product("C", 3, 12, true);
let product4 = new Product("D", 4, 6, false);
let product5 = new Product("E", 5, 6, false);

let arr0: Array<Product> = [product1, product2, product3, product4, product5];

let arr1: Array<string> = arr0.map((item) => {
    return item.description;
});

let arr2: Array<number> = arr0.map((item) => {
    return item.price;
});

let arr3: Array<number> = arr0.map((item) => {
    return item.quantity;
});

let arr4: Array<boolean> = arr0.map((item) => {
    return item.isExpired;
});

console.log(arr1);
console.log(arr2);
console.log(arr3);
console.log(arr4);
