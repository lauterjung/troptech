import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { CustomValidators } from 'src/app/validators/custom.validators';
import { ProductService } from '../../product.service';
import { InventoryProduct } from '../product.model';

@Component({
  selector: 'app-product-forms',
  templateUrl: './product-forms.component.html',
  styleUrls: ['./product-forms.component.css']
})
export class ProductFormsComponent implements OnInit {

  public form!: FormGroup;
  public productHasImage: boolean = false;

  constructor(private service: ProductService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      expirationDate: new FormControl(null, [Validators.required, CustomValidators.futureDate()]),
      unitPrice: new FormControl(null, [Validators.required, Validators.min(0.01)]),
      hasImage: new FormControl(null), /////////
      imageName: new FormControl(null),
    });
  }

  public submitProduct(): void {
    if (this.form.invalid) {
      return;
    }

    let inventoryProduct: InventoryProduct = this.formToProduct();
    this.service.saveProduct(inventoryProduct)
    .pipe(take(1))
    .subscribe(
      () => {
        alert('Produto salvo com sucesso!')
        this.form.reset();
      });
  }

  public formToProduct(): InventoryProduct {
    let inventoryProduct: InventoryProduct = {} as InventoryProduct;
    inventoryProduct.name = this.form.get("name")?.value;;
    inventoryProduct.description = this.form.get("description")?.value;
    inventoryProduct.expirationDate = this.form.get("expirationDate")?.value;
    inventoryProduct.unitPrice = this.form.get("unitPrice")?.value;
    inventoryProduct.imageName = this.form.get("imageName")?.value;

    return inventoryProduct;
  }

  public changeHasImage(): void {
    this.productHasImage = !this.productHasImage;
  }
}
