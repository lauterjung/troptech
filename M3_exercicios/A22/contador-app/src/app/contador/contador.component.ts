import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-contador',
  templateUrl: './contador.component.html',
  styleUrls: ['./contador.component.css']
})
export class ContadorComponent implements OnInit {
  
  @Output() public onCapture: EventEmitter<number> = new EventEmitter<number>();

	public counter: number = 0;

  ngOnInit(): void {
    setInterval(() => {
      this.counter++;
    }, 1000)
  }

  public capturar(): void {
		this.onCapture.emit(this.counter);
	}
}





	// public inscrever(): void {
	// 	this.onInscricao.emit("a");
	// }