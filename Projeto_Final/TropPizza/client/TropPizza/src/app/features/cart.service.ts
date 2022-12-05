import { Injectable } from '@angular/core';
import { CartProduct } from './product/product.model';

@Injectable({
    providedIn: 'root'
})

export class CartService {

    cartProducts: CartProduct[] = [];
    constructor() { }

    saveProducts(productsToCart: CartProduct[]) {
        if (this.cartProducts.length === 0) {
            this.cartProducts = productsToCart;     
        } else {
            this.cartProducts.push(...productsToCart);
        }
    }

    emptyCart() {
        this.cartProducts = [];
    }

    retrieveProducts() {
        return this.cartProducts;
    }

}