import { Component, OnInit } from '@angular/core';
// import { msservice } from 'src/app/Services/user.service';
import { MSAuthenticationService } from '../../Service/msauthentication.service';
import {FormBuilder, FormGroup, FormsModule, NgForm, Validators} from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  public registerform: FormGroup;
  public email_check?:boolean
  public username_check?:boolean
  public invalidSignUp?:boolean

  constructor(public msservice: MSAuthenticationService, private formbuilder:FormBuilder) {

    this.registerform = this.formbuilder.group({
      email: [null,Validators.required],
      username: [null, Validators.required],
      password: [null,Validators.required]
     });

   }

  ngOnInit(): void {
  }

  async register(){
    let val = this.registerform.value;
    if(val.email && val.username && val.password)
    {
      let em_ch = await this.msservice.get_email_check()
      this.email_check = em_ch;

      let us_ch =  await this.msservice.get_username_check()
      this.username_check = us_ch;

      console.log(`The signup checks were ${this.email_check} for email and ${this.username_check} for username`)
      
      if((em_ch && us_ch) != undefined || null  )
      {
        if((em_ch === false) && (us_ch === false))
        {
          this.msservice.SignUp(val.email, val.username, val.password).subscribe(saved => console.log(`${saved} at ${Date.now} - checked if signed up with ${val.email}`))
        }
        else if((em_ch === true) && (us_ch === false))
        {
          console.log(`The email '${val.email}' is registered already`)
        }
        else if((em_ch === false) && (us_ch === true))
        {
          console.log(`The username '${val.username}' is registered already`)
        }
        else{
          this.invalidSignUp = true;
          console.log(`The email '${val.email}' and username '${val.username}' are registered already`)
        }
      }
    }
  }

  









  async check_email()
  {
    this.msservice.check_email(this.registerform.value.email)
  }

  async check_username()
  {
    this.msservice.check_username(this.registerform.value.username)
  }
}
