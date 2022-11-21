import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Contact } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public form!: FormGroup;
  public contacts = Array<Contact>();

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      phoneNumber: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
    });
  }

  public submitContact(): void {
	if (!this.form.valid) {
		return;
	}
	
    let name: string = this.form.get('name')?.value;
    let phoneNumber: string = this.form.get('phoneNumber')?.value;
    let email: string = this.form.get('email')?.value;

    let contact = new Contact(name, phoneNumber, email);
    this.contacts.push(contact);

    this.form.reset()
    console.log(this.contacts); 
  }
}