import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { OrderService } from '../../order.service';
import { OrderDialogDeleteComponent } from '../order-dialog-delete/order-dialog-delete.component';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-manager',
  templateUrl: './order-manager.component.html',
  styleUrls: ['./order-manager.component.css']
})
export class OrderManagerComponent implements OnInit {
  public orders: Order[] = [];
  public deletePopUpShowing: boolean = false;
  public orderToDeleteIndex: string = "";

  constructor(private service: OrderService, private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getAllOrders()
      .pipe(take(1))
      .subscribe((data: Order[]) => {
        this.orders = data;
      });
  }

  trackOrder(id: number) {
    this.router.navigate(['/order/track', id]);
  }

  showOrderProducts(order: Order): string {
    let message: string[] = [];
    if (order.cartProducts.length <= 0) {
      return "";
    }
    order.cartProducts.forEach(product => {
      let item: string = product.quantity + "x " + product.name;
      message.push(item);
    });
    return message.join(", ");
  }

  showDeleteDialog(id: number) {
    this.dialog.open(OrderDialogDeleteComponent,
    {
      data: id,
    });
  }

  showUpdateStatusDialog(id: number) {
    // this.dialog.open(OrderDialogDeleteComponent,
    // {
    //   data: id,
    // });
  }
}