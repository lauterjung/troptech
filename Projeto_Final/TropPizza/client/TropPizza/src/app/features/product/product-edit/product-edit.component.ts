import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  
  public form!: FormGroup;
  public hasImage: boolean = false;
  public productToEdit: Product = {} as Product;
  public id: number = 1;

  constructor(private service: ProductService, private router: Router) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      expirationDate: new FormControl(null, [Validators.required]),
      unitPrice: new FormControl(null, [Validators.required, Validators.min(0.01)]),
      quantity: new FormControl(null, [Validators.required, Validators.min(0)]),
      imagePath: new FormControl(null),
    });

    this.service.getProduct(this.id.toString())
    .pipe(take(1))
    .subscribe((data: Product) => {
      this.productToEdit = data;
    });
  }

  public submitProduct(): void {
    if (this.form.invalid) {
      return;
    }

    this.service.updateProduct(this.productToEdit).pipe(take(1)).subscribe(
      () => {
        alert('Produto editado com sucesso!')
        this.router.navigate(['/product/manage'])
      });
  }

  public changeHasImage(): void {
    this.hasImage = !this.hasImage;
  }
}
