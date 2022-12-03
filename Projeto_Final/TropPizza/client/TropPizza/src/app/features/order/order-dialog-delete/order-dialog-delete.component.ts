import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { take } from 'rxjs';
import { OrderService } from '../../order.service';

@Component({
  selector: 'app-order-dialog-delete',
  templateUrl: './order-dialog-delete.component.html',
  styleUrls: ['./order-dialog-delete.component.css']
})
export class OrderDialogDeleteComponent implements OnInit {

  constructor(private matDialogRef: MatDialogRef<OrderDialogDeleteComponent>, private service: OrderService, @Inject(MAT_DIALOG_DATA) public data: number) { }

  ngOnInit(): void {
  }

  ngOnDestroy(){
    this.matDialogRef.close(this.data);
  }

  confirmDelete(): void {
    this.service.deleteOrder(this.data.toString())
      .pipe(take(1))
      .subscribe(
        () => {
        });
    window.alert("Pedido deletado com sucesso!");
    location.reload();
  }

  closePopUp():void {
    this.matDialogRef.close()
  }
}
