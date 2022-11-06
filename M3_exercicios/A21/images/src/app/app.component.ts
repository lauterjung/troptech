import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'images';
  public isImage1: boolean = false;
  public isImage2: boolean = false;

  public showImage1() {
    this.isImage1 = true;
    this.isImage2 = false;
  }

  public showImage2() {
    this.isImage2 = true;
    this.isImage1 = false;
  }
}