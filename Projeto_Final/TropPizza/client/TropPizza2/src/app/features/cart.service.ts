import { Injectable } from '@angular/core';
import { CartProduct } from './product/product.model';

@Injectable({
    providedIn: 'root'
})
export class CartService {

    productsToCart: CartProduct[] = [];
    constructor() { }

    saveIds(produIds: any) {
        this.productsToCart = produIds;
    }
    retrieveIDs() {
        return this.productsToCart;
    }

}