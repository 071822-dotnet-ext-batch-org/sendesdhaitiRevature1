import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MSAuthenticationService } from '../../Service/msauthentication.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public emailcheck?:boolean
  public usernamecheck?:boolean
  public isLoginValid?:boolean
  public loginform:FormGroup

  constructor(private msservice: MSAuthenticationService, private formbuilder:FormBuilder, private router:Router) { 
    this.loginform = this.formbuilder.group({
      email: [null,Validators.required],
      username: [null, Validators.required],
      password: [null,Validators.required]
    });

  }



  ngOnInit(): void {
    this.changeElementClass_by_ID_and_CLASSNAME("username", "Hide");
  }

  async login(){
    const val = this.loginform.value
    if(val.email && val.password )
    {
      this.msservice.check_email(val.email)
      let em_ch = await this.msservice.get_email_check()
      this.emailcheck = em_ch;
      let check = this.msservice.Login_email(val.email, val.password)
      if( em_ch )
      {
        check.subscribe(token => {
          this.msservice.keep_token(token);
          this.router.navigate(["home"])
        },
        err => {
          this.isLoginValid = false;
          this.router.navigate(["home"])
        })//End of Subscribe
      }
    }
    else if(val.username && val.password )
    {
      this.msservice.check_username(val.username)
      let us_ch =  await this.msservice.get_username_check()
      this.usernamecheck = us_ch
      let check = this.msservice.Login_username(val.username, val.password)
      if(us_ch)
      {
        check.subscribe(data => {this.msservice.keep_token(data);this.router.navigate(["home"]);}, err => {
          this.isLoginValid = false
        })
      }
    }
  }//END OF LOGIN

  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }//END OF CHANGE ELEMENT BY CLASS
  
  async check_email()
  {
    this.msservice.check_email(this.loginform.value.email)
  }//END OF CHECK EMAIL

  async check_username()
  {
    this.msservice.check_username(this.loginform.value.username)
  }//END OF CHECK USERNAME
  
  
  
  
  








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
