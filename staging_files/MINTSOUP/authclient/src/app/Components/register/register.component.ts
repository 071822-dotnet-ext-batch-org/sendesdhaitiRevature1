import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import {FormBuilder, FormGroup, FormsModule, NgForm, Validators} from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerform: FormGroup;
  public static register_check1:boolean
  public static register_check2:boolean

  constructor(public userservice: UserService, private formbuilder:FormBuilder) {

    this.registerform = this.formbuilder.group({
      email: ['',Validators.required],
      username: ['', Validators.required],
      password: ['',Validators.required]
     });

   }

  ngOnInit(): void {
  }

  register(){
    let val = this.registerform.value;
    if(val.email && val.username && val.password)
    {
      this.userservice.CHECK_IF_EMAIL_EXISTS(val.email).subscribe(data => RegisterComponent.register_check1 = data);
      this.userservice.CHECK_IF_USERNAME_EXISTS(val.username).subscribe(data => RegisterComponent.register_check2 = data);
      if((RegisterComponent.register_check1 && RegisterComponent.register_check2) === false)
      {
        this.userservice.SignUp(val.email, val.username, val.password).subscribe(saved => console.log(`${saved} at ${Date.now} - checked if signed up with ${val.email}`))
      }
      else{
        console.log(`The user with '${val.email} is registered already`)
      }
    }
  }

}
