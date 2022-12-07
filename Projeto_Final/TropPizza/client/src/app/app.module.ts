import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerEditComponent } from './features/customer/customer-edit/customer-edit.component';
import { CustomerFormsComponent } from './features/customer/customer-forms/customer-forms.component';
import { CustomerManagerComponent } from './features/customer/customer-manager/customer-manager.component';
import { HomeComponent } from './features/common/home/home.component';
import { ProductEditComponent } from './features/product/product-edit/product-edit.component';
import { ProductFormsComponent } from './features/product/product-forms/product-forms.component';
import { ProductManagerComponent } from './features/product/product-manager/product-manager.component';
import { OrderManagerComponent } from './features/order/order-manager/order-manager.component';
import { OrderProductsComponent } from './features/order/order-products/order-products.component';
import { OrderShoppingCartComponent } from './features/order/order-shopping-cart/order-shopping-cart.component';
import { OrderStatusComponent } from './features/order/order-status/order-status.component';
import { OrderTrackerComponent } from './features/order/order-tracker/order-tracker.component';
import { MatDialogModule } from "@angular/material/dialog";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CartService } from './features/order/cart.service';
import { OrderService } from './features/order/order.service';
import { ProductService } from './features/product/product.service';
import { CustomerService } from './features/customer/customer.service';
import { AlertDialogComponent } from './features/common/dialog/alert-dialog/alert-dialog.component';
import { DeleteDialogComponent } from './features/common/dialog/delete-dialog/delete-dialog.component';
import { OrderDialogStatusChangeComponent } from './features/order/order-dialog-status-change/order-dialog-status-change.component';
import { NavbarComponent } from './features/common/navbar/navbar.component';
import { FooterComponent } from './features/common/footer/footer.component';

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
    OrderTrackerComponent,
    AlertDialogComponent,
    DeleteDialogComponent,
    OrderDialogStatusChangeComponent,
    NavbarComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [CartService, CustomerService, OrderService, ProductService],
  bootstrap: [AppComponent],
})
export class AppModule { }
