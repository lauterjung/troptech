import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-alert-dialog',
  templateUrl: './alert-dialog.component.html',
  styleUrls: ['./alert-dialog.component.css']
})
export class AlertDialogComponent implements OnInit {

  constructor(private router: Router, private matDialogRef: MatDialogRef<AlertDialogComponent>, @Inject(MAT_DIALOG_DATA) public data:
    { message: string, reloadPage: boolean, navigationString: string }) { }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    this.matDialogRef.close(this.data.message);
    if (this.data.navigationString) {
      this.router.navigate([this.data.navigationString])
    }
    if (this.data.reloadPage) {
      location.reload();
    }
  }

  closePopUp(): void {
    this.matDialogRef.close();
  }
}
