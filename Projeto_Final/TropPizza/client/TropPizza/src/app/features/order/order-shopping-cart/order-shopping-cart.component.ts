import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../../cart.service';
import { CartProduct } from '../../product/product.model';

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

  constructor(private cartService: CartService, private router: Router) { }

  ngOnInit(): void {
    this.cartProducts = this.cartService.retrieveProducts();
    this.isEmptyCart = this.cartProducts.length === 0 ? true : false;
    this.totalPrice = this.calculateTotalPrice();

    this.form = new FormGroup({
      cpf: new FormControl(null, [Validators.pattern("[0-9]{11}")]),
    });
  }
  
  updatePage()
  {
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

  }
}
