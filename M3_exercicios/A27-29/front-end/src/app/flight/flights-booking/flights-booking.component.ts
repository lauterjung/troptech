import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { Ticket } from 'src/app/ticket/ticket';
import { Flight } from '../flight';
import { FlightService } from '../flight-service';

@Component({
  selector: 'app-flights-booking',
  templateUrl: './flights-booking.component.html',
  styleUrls: ['./flights-booking.component.css']
})
export class FlightsBookingComponent implements OnInit {

  public form!: FormGroup;
  public flights: Flight[] = [];
  public tickets: Ticket[] = [];

  constructor(private flightService: FlightService) { }

  public ngOnInit(): void {
    this.form = new FormGroup({
      clientCpf: new FormControl(null, [Validators.required, Validators.minLength(11)]),
      originTicket: new FormControl(null, [Validators.required]),
      returnTicket: new FormControl(null),
    }, { updateOn: 'submit' });

    this.tickets = [
      new Ticket(1, "A", "B", new Date("2022-12-01").toLocaleDateString(), new Date("2022-12-01").toLocaleDateString(), false),
      new Ticket(2, "A", "B", new Date("2022-12-02").toLocaleDateString(), new Date("2022-12-02").toLocaleDateString(), true),
      new Ticket(3, "A", "B", new Date("2022-12-03").toLocaleDateString(), new Date("2022-12-03").toLocaleDateString(), true),
      new Ticket(4, "A", "B", new Date("2022-12-04").toLocaleDateString(), new Date("2022-12-04").toLocaleDateString(), true),
      new Ticket(5, "A", "B", new Date("2022-12-05").toLocaleDateString(), new Date("2022-12-05").toLocaleDateString(), true),
      new Ticket(6, "B", "A", new Date("2022-12-01").toLocaleDateString(), new Date("2022-12-01").toLocaleDateString(), false),
      new Ticket(7, "B", "A", new Date("2022-12-02").toLocaleDateString(), new Date("2022-12-02").toLocaleDateString(), true),
      new Ticket(8, "B", "A", new Date("2022-12-03").toLocaleDateString(), new Date("2022-12-03").toLocaleDateString(), true),
      new Ticket(9, "B", "A", new Date("2022-12-04").toLocaleDateString(), new Date("2022-12-04").toLocaleDateString(), true),
      new Ticket(10, "B", "A", new Date("2022-12-05").toLocaleDateString(), new Date("2022-12-05").toLocaleDateString(), true)
    ];
  }

  public submitFlight(): void {
    if (this.form.valid) {
      const flights = JSON.parse(localStorage.getItem("Flights")!) || [];
      let flight: Flight = this.form.value; // pode dar erro
      flight.id = this.generateFlightId(flights);
      flight.isActive = true;
      flights.push(flight);
      localStorage.setItem("Flights", JSON.stringify(flights));
      this.form.reset();
      // window.alert("Salvo com sucesso!");
    } else {
      // if(this.form.get('originTicket')?.value === null) {
      //   window.alert("AAAAAAAAAAAAAAAAAAA")
      // }
      window.alert("Erro no formulário!");
      this.form.markAsPristine();
      this.form.markAsPending();
      this.form.markAsTouched();
    }
  }

  public generateFlightId(flights: Flight[]): number {
    if (flights.length === 0) {
      return 1;
    }
    let maxId: number = Math.max(...flights.map(o => o.id!))
    return maxId + 1;
  }

  public submitFlight2(): void {
    if (this.form.valid) {
      let flight: Flight = this.form.value;

      this.flightService.saveFlight(flight)
        .pipe(take(1))
        .subscribe(() => {
          // window.alert("Salvo com sucesso!");
        });
      this.form.reset();

    } else {
      // window.alert("Erro no formulário!");
    }
  }

  // public getTicket(id: number): Ticket | undefined {
  //   for (let i = 0; i < this.tickets.length; i++) {
  //     if (this.tickets[i].id === id) {
  //       return this.tickets[i];
  //     }
  //   }

  //   return undefined;
  // }

  // public getTicket(id: number): Ticket | undefined {
  //   const result = words.filter(word => word.length > 6);

  // }
  // public getTicket(tickets: Ticket[], id: number): Ticket | undefined {
  //   const result: Ticket = tickets.filter(tickets => tickets.id === id)[0];
  //   return result
  // }
  // public getTicket(tickets: Ticket[], id: number): Ticket | undefined {
  //   const result: Ticket = tickets.filter(tickets => tickets.id === id)[0];
  //   return result
  // }
}



