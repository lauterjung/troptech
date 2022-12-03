import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CustomerService } from '../../customer.service';
import { AlertDialogComponent } from '../../dialog/alert-dialog/alert-dialog.component';
import { DeleteDialogComponent } from '../../dialog/delete-dialog/delete-dialog.component';
import { Customer } from '../customer.model';

@Component({
  selector: 'app-customer-manager',
  templateUrl: './customer-manager.component.html',
  styleUrls: ['./customer-manager.component.css']
})
export class CustomerManagerComponent implements OnInit {

  public customers: Customer[] = [];

  constructor(private service: CustomerService, private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getAllCustomers()
      .pipe(take(1))
      .subscribe((data: Customer[]) => {
        this.customers = data;
      });
  }

  editCustomer(id: number) {
    this.router.navigate(['/customer/edit', id]);
  }

  showDeleteDialog(id: number, name: string) {
    let dialogRef = this.dialog.open(DeleteDialogComponent,
      {
        data: {
          id: id,
          itemType: "o cliente ",
          identifier: name,
          confirm: false,
        }
      });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result.confirm) {
          this.service.deleteCustomer(result.id)
            .pipe(take(1))
            .subscribe(
              () => {
              });
          this.showMessage("Cliente deletado com sucesso!", true);
        }
      }
    )
  }

  showMessage(message: string, reloadPage: boolean) {
    this.dialog.open(AlertDialogComponent,
      {
        data: {message, reloadPage}
      });
  }
}
