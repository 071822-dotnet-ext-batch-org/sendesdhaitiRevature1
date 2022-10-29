import { Component, Input} from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @Input() public message?: string;
  title = 'THE SOUP';

  constructor(public auth: AuthService){}

  onLoad(){
    
  }
}

