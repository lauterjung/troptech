import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsFormsComponent } from './features/products/products-forms/products-forms.component';
import { ProductsTableComponent } from './features/products/products-table/products-table.component';

const routes: Routes = [
  {
    path: 'products',
    children: [
      {
        path: 'new',
        component: ProductsFormsComponent,
      },
      {
        path: 'table',
        component: ProductsTableComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
