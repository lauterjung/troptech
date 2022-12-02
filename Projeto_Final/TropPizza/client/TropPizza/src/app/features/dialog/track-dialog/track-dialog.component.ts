import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-track-dialog',
  templateUrl: './track-dialog.component.html',
  styleUrls: ['./track-dialog.component.css']
})
export class TrackDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: number) { }

  ngOnInit(): void {
  }

}
