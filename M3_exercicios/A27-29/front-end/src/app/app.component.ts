import { Component, OnInit } from '@angular/core';
import { of, take } from 'rxjs';
import { Flight } from './flight/flight';
import { Ticket } from './ticket/ticket';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  public title: string = "SerraAirlines";
  
  public tickets: Ticket[] = [];

  ngOnInit(): void {
  }  
}
