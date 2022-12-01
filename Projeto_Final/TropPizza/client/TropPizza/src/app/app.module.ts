import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerManagerComponent } from './features/customer/customer-manager/customer-manager.component';
import { CustomerFormsComponent } from './features/customer/customer-forms/customer-forms.component';
import { ProductFormsComponent } from './features/product/product-forms/product-forms.component';
import { ProductManagerComponent } from './features/product/product-manager/product-manager.component';
import { OrderTrackerComponent } from './features/order/order-tracker/order-tracker.component';
import { OrderStatusComponent } from './features/order/order-status/order-status.component';
import { OrderManagerComponent } from './features/order/order-manager/order-manager.component';
import { OrderProductsComponent } from './features/order/order-products/order-products.component';
import { OrderShoppingCartComponent } from './features/order/order-shopping-cart/order-shopping-cart.component';
import { ProductService } from './features/product.service';
import { CustomerService } from './features/customer.service';
import { OrderService } from './features/order.service';
import { ProductEditComponent } from './features/product/product-edit/product-edit.component';
import { CustomerEditComponent } from './features/customer/customer-edit/customer-edit.component';
import { DatePipe } from '@angular/common';
import { HomeComponent } from './features/home/home.component';
import { OrderSuccessComponent } from './features/order/order-success/order-success.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerManagerComponent,
    CustomerFormsComponent,
    ProductFormsComponent,
    ProductManagerComponent,
    OrderTrackerComponent,
    OrderStatusComponent,
    OrderManagerComponent,
    OrderProductsComponent,
    OrderShoppingCartComponent,
    ProductEditComponent,
    CustomerEditComponent,
    HomeComponent,
    OrderSuccessComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [CustomerService, ProductService, OrderService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
