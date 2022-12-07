import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { AlertDialogComponent } from '../../common/dialog/alert-dialog/alert-dialog.component';
import { DeleteDialogComponent } from '../../common/dialog/delete-dialog/delete-dialog.component';
import { OrderService } from '../order.service';
import { OrderDialogStatusChangeComponent } from '../order-dialog-status-change/order-dialog-status-change.component';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-manager',
  templateUrl: './order-manager.component.html',
  styleUrls: ['./order-manager.component.css']
})
export class OrderManagerComponent implements OnInit {
  public orders: Order[] = [];

  constructor(private service: OrderService, private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getAllOrders()
      .pipe(take(1))
      .subscribe((data: Order[]) => {
        this.orders = data;
      });
  }

  trackOrder(id: number): void {
    this.router.navigate(['/order/track', id]);
  }

  showOrderProducts(order: Order): string {
    let message: string[] = [];
    if (order.cartProducts.length <= 0) {
      return "";
    }
    order.cartProducts.forEach(product => {
      const item: string = product.quantity + "x " + product.name;
      message.push(item);
    });
    return message.join(", ");
  }

  showDeleteDialog(id: number): void {
    let dialogRef = this.dialog.open(DeleteDialogComponent,
      {
        data: {
          id: id,
          itemType: "o pedido nº ",
          identifier: id,
          confirm: false,
        }
      });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result.confirm) {
          this.service.deleteOrder(result.id)
            .pipe(take(1))
            .subscribe(
              () => {
              });
          this.showMessage("Pedido deletado com sucesso!", true);
        }
      }
    )
  }

  showUpdateStatusDialog(order: Order): void {
    let dialogRef = this.dialog.open(OrderDialogStatusChangeComponent,
      {
        data: {
          order: order,
          confirm: false,
        }
      });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result.confirm) {          
          this.service.updateOrderStatus(result.order)
            .pipe(take(1))
            .subscribe(
              () => {
              });
          this.showMessage("Status alterado com sucesso!", true);
        }
      }
    )
  }

  showMessage(message: string, reloadPage: boolean): void {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, reloadPage }
      });
  }
}