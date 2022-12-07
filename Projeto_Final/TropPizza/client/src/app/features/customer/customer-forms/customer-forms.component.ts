import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { take } from 'rxjs';
import { CustomValidators } from 'src/app/validators/custom.validators';
import { CustomerService } from '../../customer.service';
import { AlertDialogComponent } from '../../common/dialog/alert-dialog/alert-dialog.component';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-forms',
  templateUrl: './customer-forms.component.html',
  styleUrls: ['./customer-forms.component.css']
})
export class CustomerFormsComponent implements OnInit {

  public form!: FormGroup;
  public existingCustomer: Customer = {} as Customer;

  constructor(private service: CustomerService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      fullName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      cpf: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}")]),
      birthDate: new FormControl(null, [Validators.required, CustomValidators.pastDate()]),
      address: new FormControl(null, [Validators.required]),
    });
  }

  submitCustomer(): void {
    if (this.form.invalid) {
      return;
    }

    const customer: Customer = this.formToCustomer();

    this.service.saveCustomer(customer)
      .pipe(take(1))
      .subscribe(
        {
          next: () => {
            this.showMessage('Cliente salvo com sucesso!', false);
            this.form.reset();
          },
          error: (error: HttpErrorResponse) => {
            if (error.status == 400) {
              this.showMessage(error.error, false);
            }
          }
        });
  }

  formToCustomer(): Customer {
    let customer: Customer = {} as Customer;
    customer.fullName = this.form.get("fullName")?.value;
    customer.cpf = this.form.get("cpf")?.value;
    customer.birthDate = this.form.get("birthDate")?.value;
    customer.address = this.form.get("address")?.value;

    return customer;
  }

  showMessage(message: string, reloadPage: boolean): void {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, reloadPage }
      });
  }
}