import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Product } from '../products.model';
import { ProductService } from '../products.service';

@Component({
  selector: 'app-products-table',
  templateUrl: './products-table.component.html',
  styleUrls: ['./products-table.component.css']
})
export class ProductsTableComponent implements OnInit {

  public products: Product[] = [];

  constructor(private productService: ProductService) { }

  public ngOnInit(): void {
    this.productService.getProducts()
      .pipe(take(1))
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
}
