import { Component, Input, OnInit } from '@angular/core';
import { IContato } from '../app.model';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})

export class ContatoComponent implements OnInit {

  constructor() {};

  ngOnInit(): void {
  };

  @Input() public contato?: IContato;
}
