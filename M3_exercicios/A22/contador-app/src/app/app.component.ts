import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'contador-app';
  public parentTimer: number = 0;
  public isParentTimerVisible: boolean = false;

  public showParentTimer(counter: number): void {
    this.isParentTimerVisible = true;
    this.parentTimer = counter;
  }
}
