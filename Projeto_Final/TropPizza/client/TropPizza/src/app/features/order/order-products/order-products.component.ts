import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CartService } from '../../cart.service';
import { AlertDialogComponent } from '../../dialog/alert-dialog/alert-dialog.component';
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

  constructor(private router: Router, private service: ProductService, private cartService: CartService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getVisibleProducts()
      .pipe(take(1))
      .subscribe((data: InventoryProduct[]) => {
        this.inventoryProducts = data;
        this.resetQuantityToCart();
      });
  }

  resetQuantityToCart(): void {
    for (let i = 0; i < this.inventoryProducts.length; i++) {
      this.quantityToCart.push(0);
    }
  }

  addQuantity(index: number): void {
    this.quantityToCart[index] += 1;
  }

  removeQuantity(index: number): void {
    if (this.quantityToCart[index] === 0) {
      return;
    }
    this.quantityToCart[index] -= 1;
  }

  validateAddToCart(index: number, quantity: number): boolean {
    let quantityInStock: number = this.inventoryProducts[index].quantity;
    if (quantity > quantityInStock) {
      this.showMessage("Quantidade indisponível no estoque!\nQuantidade disponível: " + quantityInStock + "x", false);
      return false;
    }

    if (quantity <= 0) {
      this.showMessage("A quantidade deve ser maior que zero!", false);
      return false;
    }

    return true;
  }

  addToCart(index: number, quantity: number, inventoryProduct: InventoryProduct): void {
    if (!this.validateAddToCart(index, quantity)) {
      return;
    }
    this.quantityToCart[index] = 0;


    // se já existir, só add quantidade em cima
    // let existingCart
    //if in existing cart, add quantity, else create product and push
    let cartProduct: CartProduct = {} as CartProduct;

    cartProduct.id = inventoryProduct.id;
    cartProduct.name = inventoryProduct.name;
    cartProduct.unitPrice = inventoryProduct.unitPrice;
    cartProduct.quantity = quantity;
    cartProduct.totalPrice = quantity * inventoryProduct.unitPrice;
    
    this.cartProducts.push(cartProduct);
    this.cartService.saveProducts(this.cartProducts);
    this.cartProducts = [];
    this.showMessage("Produto adicionado com sucesso!", false);
  }

  showMessage(message: string, reloadPage: boolean) {
    this.dialog.open(AlertDialogComponent,
      {
        data: {message, reloadPage}
      });
  }

  goToCart() {
    this.router.navigate(["order/cart"]);
  }
}
