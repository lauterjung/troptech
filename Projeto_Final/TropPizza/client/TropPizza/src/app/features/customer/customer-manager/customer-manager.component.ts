import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CustomerService } from '../../customer.service';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-manager',
  templateUrl: './customer-manager.component.html',
  styleUrls: ['./customer-manager.component.css']
})
export class CustomerManagerComponent implements OnInit {

  public customers: Customer[] = [];
  public deletePopUpShowing: boolean = false;
  public customerToDeleteIndex: string = "";

  constructor(private service: CustomerService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllCustomers()
      .pipe(take(1))
      .subscribe((data: Customer[]) => {
        this.customers = data;
      });
  }

  editCustomer(id: number)
  {
    this.router.navigate(['/customer/edit']);
  }

  showDeletePopUp(id: number): void {
    this.deletePopUpShowing = true;
    this.customerToDeleteIndex = id.toString();
  }

  closeDeletePopUp(): void {
    this.deletePopUpShowing = false;
    this.customerToDeleteIndex = "";
  }

  confirmDelete(): void {
    this.service.deleteCustomer(this.customerToDeleteIndex)
    window.alert("Cliente deletado com sucesso!")
    location.reload();
  }
}

