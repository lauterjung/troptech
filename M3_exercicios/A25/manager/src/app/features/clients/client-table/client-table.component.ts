import { Component, Input, OnInit } from '@angular/core';
import { Client } from 'src/app/app.model';

@Component({
  selector: 'app-client-table',
  templateUrl: './client-table.component.html',
  styleUrls: ['./client-table.component.css']
})
export class ClientTableComponent implements OnInit{
  
  public clients: Client[] = [];

  ngOnInit(): void {
    this.clients = JSON.parse(localStorage.getItem("Clientes")!);
  }

  // public clients: Client[] = [new Client("A", "A", "A"), new Client("B", "B", "B")];

}
