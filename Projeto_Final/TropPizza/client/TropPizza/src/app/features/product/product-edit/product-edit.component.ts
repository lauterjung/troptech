import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { Product } from '../product.model';
import { Router, ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  public form!: FormGroup;
  public hasImage: boolean = false; ///////////
  public productToEdit: Product = {} as Product;
  public id: number = 0;

  constructor(private service: ProductService, private router: Router, private route: ActivatedRoute) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      expirationDate: new FormControl(null, [Validators.required]),
      unitPrice: new FormControl(null, [Validators.required, Validators.min(0.01)]),
      quantity: new FormControl(null, [Validators.required, Validators.min(0)]),
      imagePath: new FormControl(null),
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.getProduct(this.id.toString())
      .pipe(take(1))
      .subscribe((data: Product) => {
        this.productToEdit = data;
        this.populateForm(); ////////
      });

    // this.populateForm();
  }

  public populateForm(): void {
    this.form.patchValue({
      name: this.productToEdit.name,
      description: this.productToEdit.description,
      expirationDate: formatDate(this.productToEdit.expirationDate, "yyyy-MM-dd", "en"),
      unitPrice: this.productToEdit.unitPrice,
      quantity: this.productToEdit.quantity,
      imagePath: this.productToEdit.imagePath,
    });
  }

  public formsToProduct(): Product {
    let product: Product = {} as Product;

    product.id = this.productToEdit.id;
    product.isActive = this.productToEdit.isActive;
    product.name = this.form.get("name")?.value;
    product.description = this.form.get("description")?.value;
    product.expirationDate = this.form.get("expirationDate")?.value;
    product.unitPrice = this.form.get("unitPrice")?.value;
    product.quantity = this.form.get("quantity")?.value;
    product.imagePath = this.form.get("imagePath")?.value;

    return product;
  }

  public submitProduct(): void {
    if (this.form.invalid) {
      return;
    }

    let product = this.formsToProduct();
    this.service.updateProduct(product).pipe(take(1)).subscribe(
      () => {
        alert('Produto editado com sucesso!')
        this.router.navigate(['/product/manage'])
      });
  }

  public changeHasImage(): void {
    this.hasImage = !this.hasImage;
  }

  public returnToManage() {
    this.router.navigate(['/product/manage'])
  }
}
