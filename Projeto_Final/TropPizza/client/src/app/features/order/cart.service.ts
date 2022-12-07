import { Injectable } from '@angular/core';
import { CartProduct } from '../product/product.model';

@Injectable({
    providedIn: 'root'
})

export class CartService {

    cartProducts: CartProduct[] = [];
    constructor() { }

    saveProducts(productsToCart: CartProduct[]): void {
        if (this.cartProducts.length === 0) {
            this.cartProducts = productsToCart;
        } else {
            for (let i = 0; i < productsToCart.length; i++) {
                let index = this.cartProducts.map(object => object.id).indexOf(productsToCart[i].id);
                if (index != -1) {
                    this.cartProducts[index].quantity += productsToCart[i].quantity;
                } else {
                    this.cartProducts.push(productsToCart[i]);
                }
            }
        }
    }

    emptyCart(): void {
        this.cartProducts = [];
    }

    retrieveProducts(): CartProduct[] {
        return this.cartProducts;
    }
}