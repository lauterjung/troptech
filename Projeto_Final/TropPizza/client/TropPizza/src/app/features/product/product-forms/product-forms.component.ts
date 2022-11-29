import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { ProductService } from '../../product.service';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-forms',
  templateUrl: './product-forms.component.html',
  styleUrls: ['./product-forms.component.css']
})
export class ProductFormsComponent implements OnInit {

  public form!: FormGroup;
  public hasImage: boolean = false;

  constructor(private service: ProductService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      expirationDate: new FormControl(null, [Validators.required]),
      unitPrice: new FormControl(null, [Validators.required, Validators.min(0.01)]),
      imagePath: new FormControl(null),
    });
  }

  public submitProduct(): void {
    if (this.form.invalid) {
      return;
    }

    let product: Product = this.formToProduct();
    this.service.saveProduct(product).pipe(take(1)).subscribe(
      () => {
        alert('Produto salvo com sucesso!')
        this.form.reset();
      });
  }

  public formToProduct(): Product {
    let product: Product = {} as Product;
    product.name = this.form.get("name")?.value;;
    product.description = this.form.get("description")?.value;
    product.expirationDate = this.form.get("expirationDate")?.value;
    product.unitPrice = this.form.get("unitPrice")?.value;
    product.imagePath = this.form.get("imagePath")?.value;

    return product;
  }

  public changeHasImage(): void {
    this.hasImage = !this.hasImage;
  }
}
