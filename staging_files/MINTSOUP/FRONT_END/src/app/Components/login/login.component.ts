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
    this.userservice.loginwithRedirect();
  }
}

