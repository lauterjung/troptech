import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { OrderService } from '../../order.service';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-manager',
  templateUrl: './order-manager.component.html',
  styleUrls: ['./order-manager.component.css']
})
export class OrderManagerComponent implements OnInit {
  public orders: Order[] = [];
  // public deletePopUpShowing: boolean = false;
  // public OrderToDeleteIndex: string = "";

  constructor(private service: OrderService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllOrders()
      .pipe(take(1))
      .subscribe((data: Order[]) => {
        this.orders = data;
        console.log(this.orders);
      });
  }

  // editOrder(id: number)
  // {
  //   this.router.navigate(['/Order/edit', id]);
  // }

  // showDeletePopUp(id: number): void {
  //   this.deletePopUpShowing = true;
  //   this.OrderToDeleteIndex = id.toString();
  // }

  // closeDeletePopUp(): void {
  //   this.deletePopUpShowing = false;
  //   this.OrderToDeleteIndex = "";
  // }

  // confirmDelete(): void {
  //   this.deleteOrder(this.OrderToDeleteIndex)
  //   window.alert("Produto deletado com sucesso!")
  //   location.reload();
  // }

  // changeIsActive(id: number): void {
  //   let Order: Order = this.Orders[id - 1];
  //   Order.isActive = !Order.isActive;
  //   this.updateOrder(Order);
  // }

  // addQuantity(id: number): void {
  //   let Order: Order = this.Orders[id - 1];
  //   Order.quantity += 1;
  //   this.updateOrder(Order);
  // }

  // updateOrder(Order: Order): void {
  //   this.service.updateOrder(Order).pipe(take(1)).subscribe(
  //     () => {
  //     });
  // }

  deleteOrder(id: string): void {
    this.service.deleteOrder(id).pipe(take(1)).subscribe(
      () => {
      });
  }
}