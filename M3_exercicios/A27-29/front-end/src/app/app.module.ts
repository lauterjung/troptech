import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FlightsListComponent } from './flight/flights-list/flights-list.component';
import { FlightsBookingComponent } from './flight/flights-booking/flights-booking.component';
import { FlightService } from './flight/flight-service';

@NgModule({
  declarations: [
    AppComponent,
    FlightsListComponent,
    FlightsBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [FlightService],
  bootstrap: [AppComponent]
})
export class AppModule { }
