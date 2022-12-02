import { Component, OnInit } from '@angular/core';
import { CartService } from '../../cart.service';
import { CartProduct } from '../../product/product.model';

@Component({
  selector: 'app-order-shopping-cart',
  templateUrl: './order-shopping-cart.component.html',
  styleUrls: ['./order-shopping-cart.component.css']
})
export class OrderShoppingCartComponent implements OnInit {

  public cartProducts: CartProduct[] = [];
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cartProducts = this.cartService.retrieveIDs();
  }
}
