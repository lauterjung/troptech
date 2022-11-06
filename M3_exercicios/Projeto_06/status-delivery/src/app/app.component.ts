import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'status-delivery';
  input: string = "1";
  
  public handleChildOnChange(value: string): void {
    this.input = value;
  }
}
