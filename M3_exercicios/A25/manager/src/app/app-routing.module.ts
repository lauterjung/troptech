import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientFormsComponent } from './features/clients/client-forms/client-forms.component';
import { ClientTableComponent } from './features/clients/client-table/client-table.component';
import { ProductFormsComponent } from './features/products/product-forms/product-forms.component';
import { ProductTableComponent } from './features/products/product-table/product-table.component';

const routes: Routes = [
  {
    path: 'clients',
    children: [
      {
        path: 'new',
        component: ClientFormsComponent,
      },
      {
        path: 'table',
        component: ClientTableComponent,
      },
    ]
  },
  {
    path: 'products',
    children: [
      {
        path: 'new',
        component: ProductFormsComponent,
      },
      {
        path: 'table',
        component: ProductTableComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
