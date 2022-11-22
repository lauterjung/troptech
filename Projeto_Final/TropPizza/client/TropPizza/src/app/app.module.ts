import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerManagerComponent } from './features/client/customer-manager/customer-manager.component';
import { CustomerFormsComponent } from './features/client/customer-forms/customer-forms.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerManagerComponent,
    CustomerFormsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [], // CustomerService
  bootstrap: [AppComponent]
})
export class AppModule { }
