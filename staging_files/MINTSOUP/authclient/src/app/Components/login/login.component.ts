import { Component, Input, OnInit, Output } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {FormBuilder, FormGroup, FormsModule, NgForm, Validators} from '@angular/forms';
import {NgModel} from '@angular/forms'
import { Type } from '@angular/compiler';
import { JsonPipe } from '@angular/common';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
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

  constructor(public userservice: UserService, private formbuilder:FormBuilder, private router: Router) { 
    
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
  public  username_check?:boolean;
  public  email_check?:boolean;
  public invalidLogin?: boolean;
  
  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }
  
  async check_email()
  {
    this.userservice.check_email(this.loginform.value.email)
  }

  async check_username()
  {
    this.userservice.check_username(this.loginform.value.username)
  }
  
  
  
  
  async login(){
    const val = this.loginform.value
    if(val.email && val.password )
    {
      this.userservice.check_email(val.email)
      let em_ch = await this.userservice.get_email_check()
      this.email_check = em_ch;
      let check = this.userservice.Login_email(val.email, val.password)
      if( em_ch )
      {
        check.subscribe(data => {
          this.userservice.add_mstoken_to_session_storage(val.email, data);
          
          // //Add authentication headers as params
          // var params = {
            //   access_token: data,
            // };
            
            // //Add authentication headers in URL
            // var url = [ environment.API.main_api, $.param(params)].join('?');
            
            // //Open window
            // window.open(url);
            
            
            // window.location.port = '59650';
            // this.router.navigate()
        },
        err => {
          this.email_check = true;
          this.username_check = false;
        })//End of Subscribe
      }
    }
    else if(val.username && val.password )
    {
      this.userservice.check_username(val.username)
      let us_ch =  await this.userservice.get_username_check()
      this.username_check = us_ch
      let check = this.userservice.Login_username(val.username, val.password)
      if(us_ch)
      {
        check.subscribe(data => {this.userservice.add_mstoken_to_session_storage(val.email, data);window.location.href = 'http://localhost:52812/'}, err => {
          this.email_check = false;
          this.username_check = true;
        })
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
