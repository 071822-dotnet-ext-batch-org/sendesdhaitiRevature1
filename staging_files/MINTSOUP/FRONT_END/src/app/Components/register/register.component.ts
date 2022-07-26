import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public auth: AuthService) { 
    this.auth;
  }

  ngOnInit(): void {
  }

  register(){
    this.auth.loginWithRedirect({ initialScreen: 'SignUp' })
  }

}
