import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { InventoryProduct } from '../product.model';
import { Router } from '@angular/router';
import { DeleteDialogComponent } from '../../dialog/delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { AlertDialogComponent } from '../../dialog/alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  public products: InventoryProduct[] = [];
  public deletePopUpShowing: boolean = false;
  public productToDeleteIndex: string = "";

  constructor(private service: ProductService, private router: Router, private dialog: MatDialog) { }

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

  // deleteProduct(id: string): void {
  //   this.service.deleteProduct(id)
  //     .pipe(take(1))
  //     .subscribe(
  //       () => {
  //       });
  // }

  showDeleteDialog(id: number, name: string) {
    let dialogRef = this.dialog.open(DeleteDialogComponent,
      {
        data: {
          id: id,
          itemType: "o produto ",
          identifier: name,
          confirm: false,
        }
      });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result.confirm) {
          this.service.deleteProduct(result.id)
            .pipe(take(1))
            .subscribe(
              () => {
              });
          this.showMessage("Produto deletado com sucesso!", true);
          location.reload();
        }
      }
    )
  }

  showMessage(message: string, reloadPage: boolean) {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, reloadPage }
      });
  }
}