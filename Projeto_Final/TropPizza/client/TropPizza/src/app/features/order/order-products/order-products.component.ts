import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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

  constructor(private service: ProductService, private cartService: CartService, private dialog: MatDialog) { }

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
      this.showMessage("Quantidade indisponível no estoque!\nQuantidade disponível: " + quantityInStock + "x");
      return false;
    }

    if (quantity <= 0) {
      this.showMessage("A quantidade deve ser maior que zero!");
      return false;
    }

    return true;
  }

  addToCart(index: number, id: number, quantity: number, unitPrice: number): void {
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
    this.showMessage("Produto adicionado com sucesso!");
  }

  showMessage(message: string) {
    this.dialog.open(AlertDialogComponent,
      {
        data: message,
      });
  }
}
