import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public form!: FormGroup;
  public products = Array<Product>();

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      quantity: new FormControl(null, [Validators.min(0)]),
      price: new FormControl(null, [Validators.min(0)]),
    });
  }

  public submitProduct(): void {
	if (!this.form.valid) {
		return;
	}
    let name: string = this.form.get('name')?.value;
    let quantity: number = this.form.get('quantity')?.value;
    let price: number = this.form.get('price')?.value;

    let product = new Product(name, quantity, price);
    this.products.push(product);

    this.form.reset()
    console.log(this.products); 
  }
}