import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public userservice: UserService, public auth: AuthService) { 
    this.userservice;
    this.auth;
  }

  public myUser: any

  ngOnInit(): void {
    
  }

  login():void
  {
    var loggedIn_TOKEN = this.userservice.loginwithRedirect();
    this.auth.getAccessTokenSilently()
    this.auth.user$.subscribe(data => {
      this.myUser = data
    })
  }
}

