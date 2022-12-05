import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CartService } from '../../cart.service';
import { Customer } from '../../customer/customer.model';
import { AlertDialogComponent } from '../../dialog/alert-dialog/alert-dialog.component';
import { OrderService } from '../../order.service';
import { CartProduct } from '../../product/product.model';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-shopping-cart',
  templateUrl: './order-shopping-cart.component.html',
  styleUrls: ['./order-shopping-cart.component.css']
})
export class OrderShoppingCartComponent implements OnInit {

  public form!: FormGroup;
  public cartProducts: CartProduct[] = [];
  public isEmptyCart: boolean = true;
  public totalPrice: string = "";
  public lastKey?: number;

  constructor(private dialog: MatDialog, private service: OrderService, private cartService: CartService, private router: Router) { }

  ngOnInit(): void {
    this.cartProducts = this.cartService.retrieveProducts();
    this.isEmptyCart = this.cartProducts.length === 0 ? true : false;
    this.totalPrice = this.calculateTotalPrice();

    this.form = new FormGroup({
      cpf: new FormControl(null, [Validators.pattern("[0-9]{11}")]),
    });
  }

  updatePage() {
    this.isEmptyCart = this.cartProducts.length === 0 ? true : false;
    this.totalPrice = this.calculateTotalPrice();
  }

  calculateTotalPrice(): string {
    let totalPrice: number = 0;
    this.cartProducts.forEach(product => {
      totalPrice += product.totalPrice;
    });

    return totalPrice.toFixed(2);
  }

  addQuantity(index: number): void {
    this.cartProducts[index].quantity += 1;
    this.cartProducts[index].totalPrice = this.cartProducts[index].quantity * this.cartProducts[index].unitPrice;
    this.updatePage();
  }

  removeQuantity(index: number): void {
    this.cartProducts[index].quantity -= 1;
    this.cartProducts[index].totalPrice = this.cartProducts[index].quantity * this.cartProducts[index].unitPrice;
    if (this.cartProducts[index].quantity === 0) {
      this.cartProducts.splice(index, 1);
    }
    this.updatePage();
  }

  deleteItem(index: number): void {
    this.cartProducts.splice(index, 1);
    this.updatePage();
  }

  goShopping() {
    this.router.navigate(["order/new"]);
  }

  confirmEmptyCart() {

  }

  submitOrder() {
    let order = {} as Order;

    order.cartProducts = this.cartProducts;
    order.orderCustomer = {} as Customer;

    let cpf = this.form.get("cpf")?.value;
    if (typeof cpf != 'undefined' && cpf) {
      order.orderCustomer!.cpf = cpf;
    } else {
      order.orderCustomer = undefined;
    }

    this.service.saveOrder(order)
      .pipe(take(1))
      .subscribe(
        {
          next: () => {
            this.processOrder();
          },
          error: (error: HttpErrorResponse) => {
            if (error.status == 400) {
              this.showMessage(error.error)
            }
          }
        });
  }
  
  processOrder() {
    this.service.getLastKey()
    .pipe(take(1))
    .subscribe((data: number) => {
      this.lastKey = data;
      this.showMessageNavigate('Pedido nº ' + this.lastKey + ' realizado com sucesso!', 'order/track/' + this.lastKey);
      this.cartService.emptyCart();
    });
  }

  showMessage(message: string) {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message }
      });
  }

  showMessageNavigate(message: string, navigationString: string) {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, navigationString }
      });
  }
}
