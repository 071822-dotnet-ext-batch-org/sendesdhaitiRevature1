import { Component, Input, OnInit, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {NgForm} from '@angular/forms';
import {NgModel} from '@angular/forms'
import { Type } from '@angular/compiler';

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

  constructor(public userservice: UserService) { }

  ngOnInit(): void {
    this.changeElementClass_by_ID_and_CLASSNAME("username", "Hide");
  }

  @Input() email: string = "";
  @Input() username: string = "";
  @Input() password: string = "";

  @Output() form_input:LoginDTO = {
    Email: this.email,
    Username: this.username,
    Password: this.password
  }

  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }

  login(){
    if(( this.form_input?.Email ==  this.email ) && ( this.form_input?.Password ==  this.password))
    {
      this.userservice.login_email(this.email, this.password)
    }
    else if (( this.form_input?.Username ==  this.username) && ( this.form_input?.Password ==  this.password))
    {
      this.userservice.login_username(this.username, this.password)
    }
  }



  hide_and_clear_username(){
    this.username = "";
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
    this.email = "";
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
