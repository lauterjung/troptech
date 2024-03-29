import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { CustomerService } from '../customer.service';
import { Customer } from '../customer.model';
import { formatDate } from '@angular/common';
import { CustomValidators } from 'src/app/validators/custom.validators';
import { AlertDialogComponent } from '../../common/dialog/alert-dialog/alert-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {

  public form!: FormGroup;
  public customerToEdit: Customer = {} as Customer;
  public id: number = 0;

  constructor(private service: CustomerService, private router: Router, private route: ActivatedRoute, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      fullName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      cpf: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}")]),
      birthDate: new FormControl(null, [Validators.required, CustomValidators.pastDate()]),
      address: new FormControl(null, [Validators.required]),
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.getCustomerById(this.id.toString())
      .pipe(take(1))
      .subscribe((data: Customer) => {
        this.customerToEdit = data;
        this.populateForm();
      });
  }

  populateForm(): void {
    this.form.patchValue({
      fullName: this.customerToEdit.fullName,
      cpf: this.customerToEdit.cpf,
      birthDate: formatDate(this.customerToEdit.birthDate, "yyyy-MM-dd", "en"),
      address: this.customerToEdit.address,
    });
  }

  formsToCustomer(): Customer {
    let customer: Customer = {} as Customer;

    customer.id = this.customerToEdit.id;
    customer.fidelityPoints = this.customerToEdit.fidelityPoints;
    customer.fullName = this.form.get("fullName")?.value;
    customer.cpf = this.form.get("cpf")?.value;
    customer.birthDate = this.form.get("birthDate")?.value;
    customer.address = this.form.get("address")?.value;

    return customer;
  }

  returnToManager(): void {
    this.router.navigate(['/customer/manage'])
  }

  submitCustomer(): void {
    if (this.form.invalid) {
      return;
    }

    const customer = this.formsToCustomer();

    this.service.updateCustomer(customer)
      .pipe(take(1))
      .subscribe(
        {
          next: () => {
            this.showMessage('Cliente salvo com sucesso!', false, '/customer/manage');
          },
          error: (error: HttpErrorResponse) => {
            if (error.status == 400) {
              this.showMessage(error.error, false, '');
            }
          }
        });
  }

  showMessage(message: string, reloadPage: boolean, navigationString: string): void {
    this.dialog.open(AlertDialogComponent,
      {
        data: { message, reloadPage, navigationString }
      });
  }
}
