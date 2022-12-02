import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { InventoryProduct } from '../product.model';
import { Router, ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';
import { CustomValidators } from 'src/app/validators/custom.validators';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  public form!: FormGroup;
  public productToEdit: InventoryProduct = {} as InventoryProduct;
  public id: number = 0;

  constructor(private service: ProductService, private router: Router, private route: ActivatedRoute) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      expirationDate: new FormControl(null, [Validators.required, CustomValidators.futureDate()]),
      unitPrice: new FormControl(null, [Validators.required, Validators.min(0.01)]),
      quantity: new FormControl(null, [Validators.required, Validators.min(0)]),
      hasImage: new FormControl(null),
      imageName: new FormControl(null),
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.getProduct(this.id.toString())
      .pipe(take(1))
      .subscribe((data: InventoryProduct) => {
        this.productToEdit = data;
        this.populateForm(); ////////
      });

    // this.populateForm();
  }

  public populateForm(): void {
    this.form.patchValue({
      name: this.productToEdit.name,
      description: this.productToEdit.description,
      expirationDate: formatDate(this.productToEdit.expirationDate!, "yyyy-MM-dd", "en"),
      unitPrice: this.productToEdit.unitPrice,
      quantity: this.productToEdit.quantity,
      hasImage: this.productToEdit.hasImage,
      imageName: this.productToEdit.imageName,
    });
  }

  public formsToProduct(): InventoryProduct {
    let inventoryProduct: InventoryProduct = {} as InventoryProduct;

    inventoryProduct.id = this.productToEdit.id;
    inventoryProduct.isActive = this.productToEdit.isActive;
    inventoryProduct.name = this.form.get("name")?.value;
    inventoryProduct.description = this.form.get("description")?.value;
    inventoryProduct.expirationDate = this.form.get("expirationDate")?.value;
    inventoryProduct.unitPrice = this.form.get("unitPrice")?.value;
    inventoryProduct.quantity = this.form.get("quantity")?.value;
    inventoryProduct.imageName = this.form.get("imageName")?.value;

    return inventoryProduct;
  }

  public submitProduct(): void {
    if (this.form.invalid) {
      return;
    }

    let inventoryProduct = this.formsToProduct();
    this.service.updateProduct(inventoryProduct)
      .pipe(take(1))
      .subscribe(
        () => {
          alert('Produto editado com sucesso!')
          this.router.navigate(['/product/manage'])
        });
  }

  // public changeHasImage(): void {
  //   this.productToEdit.hasImage = !this.productToEdit.hasImage;
  // }

  public returnToManager() {
    this.router.navigate(['/product/manage'])
  }
}
