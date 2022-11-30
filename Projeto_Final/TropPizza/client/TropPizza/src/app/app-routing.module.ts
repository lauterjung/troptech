import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerEditComponent } from './features/customer/customer-edit/customer-edit.component';
import { CustomerFormsComponent } from './features/customer/customer-forms/customer-forms.component';
import { CustomerManagerComponent } from './features/customer/customer-manager/customer-manager.component';
import { OrderManagerComponent } from './features/order/order-manager/order-manager.component';
import { OrderProductsComponent } from './features/order/order-products/order-products.component';
import { OrderShoppingCartComponent } from './features/order/order-shopping-cart/order-shopping-cart.component';
import { OrderStatusComponent } from './features/order/order-status/order-status.component';
import { OrderTrackerComponent } from './features/order/order-tracker/order-tracker.component';
import { ProductEditComponent } from './features/product/product-edit/product-edit.component';
import { ProductFormsComponent } from './features/product/product-forms/product-forms.component';
import { ProductManagerComponent } from './features/product/product-manager/product-manager.component';

const routes: Routes = [
  // {
  //   path: '',
  //   component: HomepageComponent,
  // },
  {
    path: 'customer',
    children: [
      {
        path: 'new',
        component: CustomerFormsComponent,
      },
      {
        path: 'manage',
        component: CustomerManagerComponent,
      },
      {
        path: 'edit/:id',
        component: CustomerEditComponent,
      },
    ]
  },
  {
    path: 'product',
    children: [
      {
        path: 'new',
        component: ProductFormsComponent,
      },
      {
        path: 'manage',
        component: ProductManagerComponent,
      },
      {
        path: 'edit/:id',
        component: ProductEditComponent,
      },
    ]
  },
  {
    path: 'order',
    children: [
      {
        path: 'new',
        component: OrderProductsComponent,
      },
      {
        path: 'cart',
        component: OrderShoppingCartComponent,
      },
      {
        path: 'manage',
        component: OrderManagerComponent,
      },
      {
        path: 'change-status',
        component: OrderStatusComponent,
      },
      {
        path: 'track',
        component: OrderTrackerComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
