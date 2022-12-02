import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerEditComponent } from './features/customer/customer-edit/customer-edit.component';
import { CustomerFormsComponent } from './features/customer/customer-forms/customer-forms.component';
import { CustomerManagerComponent } from './features/customer/customer-manager/customer-manager.component';
import { HomeComponent } from './features/home/home.component';
import { ProductEditComponent } from './features/product/product-edit/product-edit.component';
import { ProductFormsComponent } from './features/product/product-forms/product-forms.component';
import { ProductManagerComponent } from './features/product/product-manager/product-manager.component';
import { OrderManagerComponent } from './features/order/order-manager/order-manager.component';
import { OrderProductsComponent } from './features/order/order-products/order-products.component';
import { OrderShoppingCartComponent } from './features/order/order-shopping-cart/order-shopping-cart.component';
import { OrderStatusComponent } from './features/order/order-status/order-status.component';
import { OrderSuccessComponent } from './features/order/order-success/order-success.component';
import { OrderTrackerComponent } from './features/order/order-tracker/order-tracker.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerEditComponent,
    CustomerFormsComponent,
    CustomerManagerComponent,
    HomeComponent,
    ProductEditComponent,
    ProductFormsComponent,
    ProductManagerComponent,
    OrderManagerComponent,
    OrderProductsComponent,
    OrderShoppingCartComponent,
    OrderStatusComponent,
    OrderSuccessComponent,
    OrderTrackerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
