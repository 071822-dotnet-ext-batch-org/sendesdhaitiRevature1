import { Component, Input, OnInit, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {FormBuilder, FormGroup, FormsModule, NgForm, Validators} from '@angular/forms';
import {NgModel} from '@angular/forms'
import { Type } from '@angular/compiler';
import { JsonPipe } from '@angular/common';
import { environment } from 'src/environments/environment';

export interface LoginDTO{
  Email?:string,
  Username?:string,
  Password?:string
 }

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public userservice: UserService, private formbuilder:FormBuilder) { 

    this.loginform = this.formbuilder.group({
      email: [null,Validators.required],
      username: [null, Validators.required],
      password: [null,Validators.required]
  });
  }

  ngOnInit(): void {
    this.changeElementClass_by_ID_and_CLASSNAME("username", "Hide");
  }

  public loginform: FormGroup;
  public static username_check:boolean;
  public static email_check:boolean;

  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }

  add_mstoken_to_session_storage(email?:string, token?:string):void
  {
    if(email && token)
    {
      let mystorage =  sessionStorage.getItem(email)
      if(mystorage)
      {
        sessionStorage.removeItem(email)
        sessionStorage.setItem(email, token)
      }
      else
      {
        sessionStorage.setItem(email, token)
      }
    }
  }

  check_email(email?:string):boolean{
    if(email)
    {
      var check = this.userservice.CHECK_IF_EMAIL_EXISTS(email).subscribe((data:boolean) => {LoginComponent.email_check = data; console.log(`The login data: ${data}`)})
      let s = LoginComponent.email_check
      if(s)
      {
        // check.add
        return s;
      }
      else
      {
        // check.unsubscribe()
        return s;
      }
    }
    else return false;
  }








  check_username(username?:string):boolean{
    // let check:boolean = false;
    if(username)
    {
      var check = this.userservice.CHECK_IF_USERNAME_EXISTS(username).subscribe(data => {LoginComponent.username_check = data;console.log(`The login data: ${data}`)})
      if(LoginComponent.username_check)
      {
        check.unsubscribe()
        return LoginComponent.username_check;
      }
      else
      {
        check.unsubscribe()
        return false;
      }
    }
    else return false;
  }






  login(){
    const val = this.loginform.value
    if(val.email && val.password )
    {
      this.check_email(val.email)
      let check = this.userservice.Login_email(val.email, val.password)
      if(LoginComponent.email_check)
      {
        check.subscribe(data => {
          this.add_mstoken_to_session_storage(val.email, data);

          // //Add authentication headers as params
          // var params = {
          //   access_token: data,
          // };

          // //Add authentication headers in URL
          // var url = [ environment.API.main_api, $.param(params)].join('?');

          // //Open window
          // window.open(url);


          // window.location.href = 'http://localhost:52812/';
        })//End of Subscribe
      }
    }
    else if(val.username && val.password )
    {
      this.check_username(val.username)
      let check = this.userservice.Login_username(val.username, val.password)
      if(LoginComponent.username_check)
      {
        check.subscribe(data => {this.add_mstoken_to_session_storage(val.email, data);window.location.href = 'http://localhost:52812/'})
      }
    }
  }








  hide_and_clear_username(){
    let val = this.loginform.value
    this.loginform.reset();
    val.username = null;
    this.changeElementClass_by_ID_and_CLASSNAME('username', 'Hidding').then(() =>
    {
      this.changeElementClass_by_ID_and_CLASSNAME('username', 'Hide')
    })
    .then(() => 
    {
      this.changeElementClass_by_ID_and_CLASSNAME('email','Show')
    })
  }

  hide_and_clear_email(){
    let val = this.loginform.value
    this.loginform.reset();
    val.email = null;
    this.changeElementClass_by_ID_and_CLASSNAME('email', 'Hidding').then(() =>
    {
      this.changeElementClass_by_ID_and_CLASSNAME('email', 'Hide')
    })
    .then(() => 
    {
      this.changeElementClass_by_ID_and_CLASSNAME('username','Show')
    })
  }

}
