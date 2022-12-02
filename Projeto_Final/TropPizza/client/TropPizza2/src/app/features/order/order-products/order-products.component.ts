import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { CartService } from '../../cart.service';
import { ProductService } from '../../product.service';
import { CartProduct, InventoryProduct } from '../../product/product.model';

@Component({
  selector: 'app-order-products',
  templateUrl: './order-products.component.html',
  styleUrls: ['./order-products.component.css']
})
export class OrderProductsComponent implements OnInit {

  public inventoryProducts: InventoryProduct[] = [];
  public cartProducts: CartProduct[] = [];
  public quantityToCart: number[] = [];

  constructor(private service: ProductService, private cartService: CartService) { }

  ngOnInit(): void {
    this.service.getVisibleProducts()
      .pipe(take(1))
      .subscribe((data: InventoryProduct[]) => {
        this.inventoryProducts = data;
        this.resetQuantityToCart();
      });
  }

  public resetQuantityToCart(): void {
    for (let i = 0; i < this.inventoryProducts.length; i++) {
      this.quantityToCart.push(0);   
    }
  }

  public addQuantity(index: number): void {
    this.quantityToCart[index] += 1;    
  }

  public removeQuantity(index: number): void {
    if(this.quantityToCart[index] === 0) {
      return;
    }
    this.quantityToCart[index] -= 1;    
  }

  public validateAddToCart(index: number, quantity: number): boolean {    
    if (quantity >= this.inventoryProducts[index].quantity) {
      window.alert("Quantidade indisponível no estoque!");
      return false;
    }

    if (quantity <= 0) {
      window.alert("A quantidade deve ser maior que zero!");
      return false;
    }

    return true;
  }

  public addToCart(index: number, id: number, quantity: number, unitPrice: number): void {
    if (!this.validateAddToCart(index, quantity)) {
      return;
    }
    this.quantityToCart[index] = 0;


    // se já existir, só add quantidade em cima
    let cartProduct: CartProduct = {} as CartProduct;
    cartProduct.id = id;
    cartProduct.quantity = quantity;
    cartProduct.totalPrice = quantity * unitPrice;

    this.cartProducts.push(cartProduct);
    console.log(this.cartProducts);
    this.cartService.saveIds(this.cartProducts);
    window.alert("Produto adicionado com sucesso!");
  }

  
}