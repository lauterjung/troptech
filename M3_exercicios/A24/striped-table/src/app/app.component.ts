import { Component } from '@angular/core';
import { User } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public user1 = new User("AAAAAA", "AAAAAA", "@AAA");
  public user2 = new User("BBBBBB", "BBBBBB", "@BBB");
  public user3 = new User("CCCCCC", "CCCCCC", "@CCC");

  public users: Array<User> = Array<User>(this.user1, this.user2, this.user3);

  public name(): void{
    1 % 2 === 0;
  }
}
