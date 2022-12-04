import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public isOpen?: boolean;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.isOpen = this.checkIfOpen();
  }

  checkIfOpen(): boolean {
    let currentHour: number = new Date().getHours();
    let openingTime = 18;
    let closingTime = 24;
    if (currentHour >= openingTime && currentHour < closingTime) {
      return true;
    }
    else {
      return false;
    }
  }

  goShopping(): void {
    this.router.navigate(['order/new']);
  }
}
