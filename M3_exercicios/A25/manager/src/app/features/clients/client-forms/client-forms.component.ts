import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Client } from 'src/app/app.model';

@Component({
  selector: 'app-client-forms',
  templateUrl: './client-forms.component.html',
  styleUrls: ['./client-forms.component.css']
})
export class ClientFormsComponent implements OnInit {

  // @Output() public register: EventEmitter<Client> = new EventEmitter<Client>();

  public form!: FormGroup;
  public clients = Array<Client>();

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      cpf: new FormControl(null, [Validators.required]),
      phoneNumber: new FormControl(null),
    });
  }

  public submitClient(): void {
    if (this.form.valid) {
      // const clients = JSON.parse(localStorage.getItem("Clientes")!) || [];
      // clients.push(this.form.value);
      // this.register.emit(this.form.value);
      // localStorage.setItem("Clientes", JSON.stringify(clients));
      this.form.reset();
    }
  }
}


