import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CustomerService } from '../../customer.service';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {

  public form!: FormGroup;
  public customerToEdit: Customer = {} as Customer;
  public id: number = 1;

  constructor(private service: CustomerService, private router: Router) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      fullName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      cpf: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}")]),
      birthDate: new FormControl(null, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
    });

    this.service.getCustomerById(this.id.toString()).pipe(take(1))
      .subscribe((data: Customer) => {
        this.customerToEdit = data;
      });
  }

  public submitCustomer(): void {
    if (this.form.invalid) {
      return;
    }

    this.service.updateCustomer(this.customerToEdit)
    .pipe(take(1))
    .subscribe(
      () => {
        alert('Cliente editado com sucesso!')
        this.router.navigate(['/customer/manage']);
      });
  }
}
