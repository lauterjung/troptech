import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightsBookingComponent } from './flight/flights-booking/flights-booking.component';
import { FlightsListComponent } from './flight/flights-list/flights-list.component';

const routes: Routes = [
  // {
  //   path: 'ticket',
  //   // children: [
  //   //   {
  //   //     path: '',
  //   //     component: ClientFormsComponent,
  //   //   },
  //   //   {
  //   //     path: '',
  //   //     component: ClientTableComponent,
  //   //   },
  //   // ]
  // },
  {
    path: 'flight',
    children: [
      {
        path: 'book',
        component: FlightsBookingComponent,
      },
      {
        path: 'list',
        component: FlightsListComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
