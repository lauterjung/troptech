import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Sale } from '../app.model';

@Component({
  selector: 'app-venda-form',
  templateUrl: './venda-form.component.html',
  styleUrls: ['./venda-form.component.css']
})
export class VendaFormComponent implements OnInit {

  public form!: FormGroup;
  // public sales = Array<Sale>();

  public ngOnInit(): void {
    this.form = new FormGroup({
      salesId: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
      clientName: new FormControl(null, [Validators.required]),
    });
  }

}
