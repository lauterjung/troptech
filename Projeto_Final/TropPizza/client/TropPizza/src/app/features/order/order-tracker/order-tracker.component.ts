import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { OrderService } from '../../order.service';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-tracker',
  templateUrl: './order-tracker.component.html',
  styleUrls: ['./order-tracker.component.css']
})
export class OrderTrackerComponent implements OnInit {

  public orderToTrack: Order = {} as Order;
  public id: number = 0;

  constructor(private service: OrderService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.getOrder(this.id.toString())
      .pipe(take(1))
      .subscribe((data: Order) => {
        this.orderToTrack = data;
      });
  }

  // returnToManager() {
  //   this.router.navigate(['/order/manage'])
  // }

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

  showClientCpf(order: Order): string {
    return order.orderCustomer?.cpf ? order.orderCustomer?.cpf : "Sem CPF registrado";
  }
}
