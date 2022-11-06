import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.css']
})
export class TimelineComponent {
  @Output() public onUpdate: EventEmitter<string> = new EventEmitter<string>();

  input: string = "";

  public updateComponent(): void {
		this.onUpdate.emit(this.input);
	}

  public handleChildOnChange(value: string): void {
    this.input = value;
    this.updateComponent()
  }
}
