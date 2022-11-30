import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { CustomerService } from '../../customer.service';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-forms',
  templateUrl: './customer-forms.component.html',
  styleUrls: ['./customer-forms.component.css']
})
export class CustomerFormsComponent implements OnInit {

  public form!: FormGroup;
  
  constructor(private service: CustomerService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      fullName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      cpf: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}")]),
      birthDate: new FormControl(null, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
    });
  }

  public submitCustomer(): void {
    if (this.form.invalid) {
      return;
    }

    let customer: Customer = this.formToCustomer();
    this.service.saveCustomer(customer)
    .pipe(take(1))
    .subscribe(
      () => {
        alert('Cliente salvo com sucesso!')
        this.form.reset();
      });
  }

  public formToCustomer(): Customer {
    let customer: Customer = {} as Customer;
    customer.fullName = this.form.get("fullName")?.value;
    customer.cpf = this.form.get("cpf")?.value;
    customer.birthDate = this.form.get("birthDate")?.value;
    customer.address = this.form.get("address")?.value;

    return customer;
  }
}