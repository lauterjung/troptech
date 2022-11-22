import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  // {
  //   path: 'customer',
  //   children: [
  //     {
  //       path: 'new',
  //       component: ,
  //     },
  //     {
  //       path: 'manage',
  //       component: ,
  //     },
  //   ]
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
