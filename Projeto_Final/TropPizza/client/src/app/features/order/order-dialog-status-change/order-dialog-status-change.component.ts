import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-dialog-status-change',
  templateUrl: './order-dialog-status-change.component.html',
  styleUrls: ['./order-dialog-status-change.component.css']
})
export class OrderDialogStatusChangeComponent implements OnInit {

  public form!: FormGroup;

  constructor(private matDialogRef: MatDialogRef<OrderDialogStatusChangeComponent>, @Inject(MAT_DIALOG_DATA) public data: { order: Order, confirm: boolean }) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      statusId: new FormControl(null),
    });

    this.form.patchValue({
      statusId: this.data.order.statusEnum,
    });
  }

  ngOnDestroy(): void {
    this.matDialogRef.close(this.data);
  }

  confirmStatusChange(): void {
    this.data.confirm = true;
    this.data.order.statusEnum = +this.form.get("statusId")?.value;
    this.closePopUp();
  }

  closePopUp(): void {
    this.matDialogRef.close()
  }
}
