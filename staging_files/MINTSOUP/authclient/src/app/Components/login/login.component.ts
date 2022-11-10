import { Component, Input, OnInit, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {FormBuilder, FormGroup, FormsModule, NgForm, Validators} from '@angular/forms';
import {NgModel} from '@angular/forms'
import { Type } from '@angular/compiler';
import { JsonPipe } from '@angular/common';

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
    this.email_check = false;
    this.username_check = false;

    this.loginform = this.formbuilder.group({
      email: ['',Validators.required],
      username: ['', Validators.required],
      password: ['',Validators.required]
  });
  }

  ngOnInit(): void {
    this.changeElementClass_by_ID_and_CLASSNAME("username", "Hide");
  }

  @Input() email?: string;
  @Input() username?: string;
  @Input() password?: string;

  @Output() form_input:LoginDTO = {
    Email: this.email,
    Username: this.username,
    Password: this.password
  }

  public loginform: FormGroup;
  public username_check:boolean;
  public email_check:boolean;

  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }

  check_email(email?:string):boolean{
    if(email != undefined)
    {
      return this.userservice.CHECK_IF_EMAIL_EXISTS(email)
    }
    else return false;
  }

  check_username(username?:string):boolean{
    if(username != undefined)
    {
      return this.userservice.CHECK_IF_USERNAME_EXISTS(username)
    }
    else return false;
  }

  // login(){
  //   if(( this.email !=  null ) && ( this.password != null))
  //   {
  //     this.userservice.Login_email(this.email, this.password).subscribe(data => console.log(data))
  //   }
  //   else if (( this.username != null ) && ( this.password != null))
  //   {
  //     this.userservice.Login_username(this.username, this.password).subscribe(data => console.log(data))
  //   }
  // }
  login(){
    const val = this.loginform.value
    if(val.email && val.password && (val.username == ''))
    {
      this.email_check = this.userservice.CHECK_IF_EMAIL_EXISTS( encodeURI(val.email) )
      console.log(this.email_check)
      if(this.email_check)
      {
        this.userservice.Login_email(val.email, val.password).subscribe(data => console.log(`The login data: ${JSON.stringify(data)}`))//, error => console.log(JSON.stringify(error) ))
      }
    }
    else if(val.username && val.password && (val.email == ''))
    {
      this.username_check = this.userservice.CHECK_IF_USERNAME_EXISTS(encodeURI(val.username))
      console.log(this.username_check)
      if(this.username_check)
      {
        this.userservice.Login_username(val.username, val.password).subscribe(data => console.log(JSON.stringify(data)))
      }
    }
  }



  hide_and_clear_username(){
    let val = this.loginform.value
    val.username = '';
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
    val.email = '';
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
