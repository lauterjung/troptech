import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { Product } from '../products.model';
import { ProductService } from '../products.service';

@Component({
  selector: 'app-products-forms',
  templateUrl: './products-forms.component.html',
  styleUrls: ['./products-forms.component.css']
})
export class ProductsFormsComponent implements OnInit {
  public form!: FormGroup;

  constructor(private productService: ProductService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      quantity: new FormControl(null, [Validators.required, Validators.min(0)]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
    });
  }

  public submitProduct(): void {
    if (this.form.valid) {
      let product: Product = this.form.value;

      this.productService.saveProduct(product)
        .pipe(take(1))
        .subscribe(() => {
          alert("Salvo com sucesso!");
        });

      this.form.reset();
    }
  }
}
