import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-actions',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.css']
})
export class ActionsComponent {

  @Output() public onChange: EventEmitter<string> = new EventEmitter<string>();

  public changeForm(): void {
    let selectBox: HTMLInputElement = document.getElementById("selectBox") as HTMLInputElement;
		this.onChange.emit(selectBox.value);
	}
}
