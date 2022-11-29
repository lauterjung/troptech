import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { Product } from '../../product/product.model';

@Component({
  selector: 'app-order-products',
  templateUrl: './order-products.component.html',
  styleUrls: ['./order-products.component.css']
})
export class OrderProductsComponent implements OnInit {

  public products: Product[] = [];
  
  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.service.getAllProducts()
      .pipe(take(1))
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
}