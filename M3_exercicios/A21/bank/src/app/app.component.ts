import { Component } from '@angular/core';

interface IConta {
  nome: string;
  numeroConta: string;
  saldo: number;
  isHidden: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'bank';
  public contas: IConta[] = [
    {
      nome: 'A',
      numeroConta: '1',
      saldo: 10,
      isHidden: true,
    },
    {
      nome: 'B',
      numeroConta: '2',
      saldo: 20,
      isHidden: true,
    },
    {
      nome: 'C',
      numeroConta: '3',
      saldo: 30,
      isHidden: true,
    },
    {
      nome: 'D',
      numeroConta: '4',
      saldo: 40,
      isHidden: true,
    },
    {
      nome: 'E',
      numeroConta: '5',
      saldo: 50,
      isHidden: true,
    }
  ];

  public showhide(conta: IConta): void {
    conta.isHidden = !conta.isHidden;
  }
  
}