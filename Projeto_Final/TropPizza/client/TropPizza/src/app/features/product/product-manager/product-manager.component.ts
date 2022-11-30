import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { Product } from '../product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  public products: Product[] = [];
  public deletePopUpShowing: boolean = false;
  public productToDeleteIndex: string = "";

  constructor(private service: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllProducts()
      .pipe(take(1))
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }

  editProduct(id: number)
  {
    this.router.navigate(['/product/edit', id]);
  }

  showDeletePopUp(id: number): void {
    this.deletePopUpShowing = true;
    this.productToDeleteIndex = id.toString();
  }

  closeDeletePopUp(): void {
    this.deletePopUpShowing = false;
    this.productToDeleteIndex = "";
  }

  confirmDelete(): void {
    this.deleteProduct(this.productToDeleteIndex)
    window.alert("Produto deletado com sucesso!")
    location.reload();
  }

  changeIsActive(id: number): void {
    let product: Product = this.products[id - 1];
    product.isActive = !product.isActive;
    this.updateProduct(product);
  }

  addQuantity(id: number): void {
    let product: Product = this.products[id - 1];
    product.quantity += 1;
    this.updateProduct(product);
  }

  removeQuantity(id: number): void {
    let product: Product = this.products[id - 1];
    if (product.quantity === 0) {
      return;
    }
    product.quantity -= 1;
    this.updateProduct(product);
  }

  updateProduct(product: Product): void {
    this.service.updateProduct(product).pipe(take(1)).subscribe(
      () => {
      });
  }

  deleteProduct(id: string): void {
    this.service.deleteProduct(id).pipe(take(1)).subscribe(
      () => {
      });
  }
}

  // getProductById(id: string): Product {
  //   let product = {} as Product;
  //   this.service.getProduct(id)
  //     .pipe(take(1))
  //     .subscribe((data: Product) => {
  //       this.product1 = data;
  //     });

  //   return product;
  // }

  // changeQuantity(id: number): void {
  //   let product: Product = this.products[id - 1];
  //   product.quantity += 1;
  //   this.updateProduct(product);
  // }