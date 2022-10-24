import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { LoginDTO } from 'src/app/Models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public userservice: UserService) { 
    this.userservice;
  }
  // public email: string = "";
  public loginForm : LoginDTO = {
    "email" : "",
    "auth0ID": ""
  }
  public myUser : any

  ngOnInit(): void {
  }

  login() : void
  {
    let _list: string[] = []
    for (let index = 0; index < sessionStorage.length; index++) {
      const element = sessionStorage[index];
      console.log(`${element} was gotten from the storage`)
      _list.push(element)
    }
    if(this.loginForm.email == null){
      //email is null
    }
    else{
      if(_list.includes(this.loginForm.email))
      {
        // email is already saved with a auth0ID in storage 
        sessionStorage.getItem(this.loginForm.email)
        this.userservice.SET_CurrentUsersID_OnLoad(this.loginForm.email)
      }
      else{
        let res =  this.userservice.loginwithRedirect(this.loginForm);
        this.myUser = res;
        //this email hasnt been saved to the storage with an auth0ID yet
        sessionStorage.setItem(`${this.loginForm.email}`, this.myUser.user$)
        console.log(this.myUser.user$)
      }
    }
  }
  checkIf_auth0ID_is_present(){
    
  }

  

}
