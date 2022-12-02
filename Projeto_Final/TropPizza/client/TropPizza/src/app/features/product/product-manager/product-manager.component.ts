import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { InventoryProduct } from '../product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  public products: InventoryProduct[] = [];
  public deletePopUpShowing: boolean = false;
  public productToDeleteIndex: string = "";

  constructor(private service: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllProducts()
      .pipe(take(1))
      .subscribe((data: InventoryProduct[]) => {
        this.products = data;
      });
  }

  editProduct(id: number) {
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
    this.closeDeletePopUp();
    window.alert("Produto deletado com sucesso!")
    location.reload();
  }

  changeIsActive(index: number): void {
    let product: InventoryProduct = this.products[index];
    product.isActive = !product.isActive;
    this.updateProduct(product);
  }

  addQuantity(index: number): void {
    let product: InventoryProduct = this.products[index];
    product.quantity += 1;
    this.updateProduct(product);
  }

  removeQuantity(index: number): void {
    let product: InventoryProduct = this.products[index];
    if (product.quantity === 0) {
      return;
    }
    product.quantity -= 1;
    this.updateProduct(product);
  }

  updateProduct(product: InventoryProduct): void {
    this.service.updateProduct(product)
      .pipe(take(1))
      .subscribe(
        () => {
        });
  }

  deleteProduct(id: string): void {
    this.service.deleteProduct(id)
      .pipe(take(1))
      .subscribe(
        () => {
        });
  }
}

  // getProductById(id: string): InventoryProduct {
  //   let product = {} as InventoryProduct;
  //   this.service.getProduct(id)
  //     .pipe(take(1))
  //     .subscribe((data: InventoryProduct) => {
  //       this.product1 = data;
  //     });

  //   return product;
  // }

  // changeQuantity(id: number): void {
  //   let product: InventoryProduct = this.products[index];
  //   product.quantity += 1;
  //   this.updateProduct(product);
  // }