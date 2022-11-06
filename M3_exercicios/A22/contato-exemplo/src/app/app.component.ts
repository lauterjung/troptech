import { Component } from '@angular/core';
import { IContato } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'contato-exemplo';

  public dado1: IContato = {
    nome: "A",
    telefone: "A",
  };
  public dado2: IContato = {
    nome: "B",
    telefone: "A",
  };
  public dado3: IContato = {
    nome: "C",
    telefone: "A",
  };
  
  public contatos: Array<IContato> = new Array<IContato> (this.dado1, this.dado2, this.dado3);
  public contatos2: IContato[] = [{nome: "1", telefone: "2"}];
}
