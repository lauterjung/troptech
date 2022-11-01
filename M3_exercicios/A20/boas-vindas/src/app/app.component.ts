import { Component, OnInit  } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'boas-vindas';
  public message: string = "Boas vindas!"
  public name: string = ""

  public ngOnInit(): void {
    //
  }

  public updateName(): void {
    let userInput = document.getElementById("user-input") as HTMLInputElement;
    this.name = userInput.value;
  }

  public updateMessage(): void {
    if(this.name) {
      this.message = `Boas vindas, ${this.name}!`
    }
  }
}
