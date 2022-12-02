import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { CustomValidators } from 'src/app/validators/custom.validators';
import { CustomerService } from '../../customer.service';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-forms',
  templateUrl: './customer-forms.component.html',
  styleUrls: ['./customer-forms.component.css']
})
export class CustomerFormsComponent implements OnInit {

  public form!: FormGroup;
  public existingCustomer: Customer = {} as Customer;

  constructor(private service: CustomerService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      fullName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      cpf: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}")]),
      birthDate: new FormControl(null, [Validators.required, CustomValidators.pastDate()]),
      address: new FormControl(null, [Validators.required]),
    });
  }

  public submitCustomer(): void {
    // this.existingCustomer = {} as Customer;

    if (this.form.invalid) {
      return;
    }

    let customer: Customer = this.formToCustomer();

    // this.setExistingCustomer(customer.cpf);
    // window.alert("bbbb");

    this.service.saveCustomer(customer)
      .pipe(take(1))
      .subscribe(
        {
          next: () => {
            alert('Cliente salvo com sucesso!')
            this.form.reset();
          },
          error: (erro: Response) => { // erro
            if (erro.status == 400) { //erro.error.message
              alert('Cliente já existente!')
              return;
            }
          }
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

  // public setExistingCustomer(stringg: string) {
  //   this.service.getCustomerByCpf(stringg)
  //   .pipe(take(1))
  //   .subscribe((data: Customer) => {

  //      `function;'ao s[o o subscrube'`
  //     this.existingCustomer = data;
  //     if (this.existingCustomer.cpf)
  //     {
  //       console.log(this.existingCustomer.cpf);
  //       window.alert("aaaaaaaaa");
  //       return;
  //     }
  //   });
  // }
}