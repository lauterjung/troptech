var Product = /** @class */ (function () {
    function Product(description, price, quantity, isExpired) {
        this.description = description;
        this.price = price;
        this.quantity = quantity;
        this.isExpired = isExpired;
    }
    return Product;
}());
var product1 = new Product("A", 1, 5.5, false);
var product2 = new Product("B", 2, 8, true);
var product3 = new Product("C", 3, 12, true);
var product4 = new Product("D", 4, 6, false);
var product5 = new Product("E", 5, 6, false);
var arr0 = [product1, product2, product3, product4, product5];
var arr1 = [product1.description, product2.description, product3.description, product4.description, product5.description];
var arr2 = [product1.price, product2.price, product3.price, product4.price, product5.price];
var arr3 = [product1.quantity, product2.quantity, product3.quantity, product4.quantity, product5.quantity];
var arr4 = [product1.isExpired, product2.isExpired, product3.isExpired, product4.isExpired, product5.isExpired];
console.log(arr1);
console.log(arr2);
console.log(arr3);
console.log(arr4);
var resultado = arr0.map(function (item) {
    return item.description;
});
console.log(resultado);
