import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Flight } from '../flight';
import { FlightService } from '../flight-service';

@Component({
  selector: 'app-flights-list',
  templateUrl: './flights-list.component.html',
  styleUrls: ['./flights-list.component.css']
})
export class FlightsListComponent implements OnInit {

  public flights: Flight[] = [];

  constructor(private flightService: FlightService) { }
  
  ngOnInit(): void {
    this.flightService.getFlights()
      .pipe(take(1))
      .subscribe((data: Flight[]) => {
        this.flights = data;
      });
    // this.flights = JSON.parse(localStorage.getItem("Flights")!) || [];
  }
}
