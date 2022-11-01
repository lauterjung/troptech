import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title = 'teste-interpolacao';
  public animal: string = "";

  public ngOnInit(): void {
    this.animal = "vazio";
  }

  public changeAnimalToDog(): void {
    this.animal = "Cachorro"
  }

  public changeAnimalToHorse(): void {
    this.animal = "Cavalo"
  }

  public resetAnimal(): void {
    this.animal = "vazio"
  }
}

