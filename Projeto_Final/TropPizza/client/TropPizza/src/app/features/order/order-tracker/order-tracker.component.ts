import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-tracker',
  templateUrl: './order-tracker.component.html',
  styleUrls: ['./order-tracker.component.css']
})
export class OrderTrackerComponent implements OnInit {

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  public input: string = "";

}
