import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/app.model';

@Component({
  selector: 'app-product-forms',
  templateUrl: './product-forms.component.html',
  styleUrls: ['./product-forms.component.css']
})
export class ProductFormsComponent implements OnInit {

  // @Output() public register: EventEmitter<Product> = new EventEmitter<Product>();

  public form!: FormGroup;
  public products: Product[] = [new Product("A", 23), new Product("B", 22)];

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
    });
  }

  public submitProduct(): void {
    if (this.form.valid) {
      // this.register.emit(this.form.value);
      this.form.reset();
    }
  }
}
