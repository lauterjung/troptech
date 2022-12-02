import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { TrackDialogComponent } from '../../dialog/track-dialog/track-dialog.component';
import { OrderService } from '../../order.service';
// import { DialogDataExample } from '../dialog/dialog.component';
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

  showDeletePopUp(id: number): void {
    this.deletePopUpShowing = true;
    this.orderToDeleteIndex = id.toString();
  }

  closeDeletePopUp(): void {
    this.deletePopUpShowing = false;
    this.orderToDeleteIndex = "";
  }

  confirmDelete(): void {
    this.deleteOrder(this.orderToDeleteIndex)
    this.closeDeletePopUp();
    window.alert("Produto deletado com sucesso!")
    location.reload();
  }

  deleteOrder(id: string): void {
    this.service.deleteOrder(id)
      .pipe(take(1))
      .subscribe(
        () => {
        });
  }

  showTrackOrderPopUp(id: number) {
    this.dialog.open(TrackDialogComponent,
    {
      data: id,
    });
  }
}