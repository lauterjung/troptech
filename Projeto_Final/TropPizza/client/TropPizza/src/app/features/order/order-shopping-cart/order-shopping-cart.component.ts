import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CartService } from '../../cart.service';
import { Customer } from '../../customer/customer.model';
import { AlertDialogComponent } from '../../common/dialog/alert-dialog/alert-dialog.component';
import { OrderService } from '../../order.service';
import { CartProduct } from '../../product/product.model';
import { Order } from '../order.model';
import { DeleteDialogComponent } from '../../common/dialog/delete-dialog/delete-dialog.component';

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

  updatePage(): void {
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

  goShopping(): void {
    this.router.navigate(["order/new"]);
  }

  confirmEmptyCart(): void {
    let dialogRef = this.dialog.open(DeleteDialogComponent,
      {
        data: {
          itemType: "todos os itens ",
          identifier: "do carrinho",
          confirm: false,
        }
      });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result.confirm) {
          this.cartService.emptyCart();
          location.reload();
        }
      }
    )
  }

  submitOrder(): void {
    let order = {} as Order;

    order.cartProducts = this.cartProducts;
    order.orderCustomer = {} as Customer;

    let cpf = this.form.get("cpf")?.value;
    if (typeof cpf != 'undefined' && cpf.toString()) {
      order.orderCustomer.cpf = cpf;
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

  processOrder(): void {
    this.service.getLastKey()
      .pipe(take(1))
      .subscribe((data: number) => {
        this.lastKey = data;
        this.showMessageAndNavigate('Pedido nº ' + this.lastKey + ' realizado com sucesso!', 'order/track/' + this.lastKey);
        this.cartService.emptyCart();
      });
  }

  showMessage(message: string): void {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message }
      });
  }

  showMessageAndNavigate(message: string, navigationString: string): void {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, navigationString }
      });
  }
}
