import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientTableComponent } from './features/clients/client-table/client-table.component';
import { ClientFormsComponent } from './features/clients/client-forms/client-forms.component';
import { ProductFormsComponent } from './features/products/product-forms/product-forms.component';
import { ProductTableComponent } from './features/products/product-table/product-table.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ClientTableComponent,
    ClientFormsComponent,
    ProductFormsComponent,
    ProductTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
