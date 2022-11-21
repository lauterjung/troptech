import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/app.model';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent {

  @Input() public products: Product[] = [];

}
