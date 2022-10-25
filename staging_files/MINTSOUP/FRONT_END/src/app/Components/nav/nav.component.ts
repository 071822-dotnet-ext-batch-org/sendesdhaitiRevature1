import { STRING_TYPE } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-angular';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  public user: User = {}

  constructor(public auth: AuthService, public userserve: UserService) { this.auth;this.user;}

  ngOnInit(): void {
  }
  // login():void{
  //   let data_tosubscribe_to = this.auth.loginWithRedirect()
  //   data_tosubscribe_to.subscribe(data => {
  //     let _data :any 
  //     _data = data
  //     console.log(_data.email, Date.now)
  //     this.CHECKIF_auth0ACCOUNT_is_in_sessionStorage_if_not_then_SAVE(_data.email, _data)
  //     this.userserve.SET_CurrentUsersID_OnLoad(_data.sub, _data.email);
  //   })
  //   // this.userserve.GET_CurrentUsersID_OnLoad()
  // }

  //This is the method to save the auth0 ID and authOBJ to the sessionStorage
  

}
