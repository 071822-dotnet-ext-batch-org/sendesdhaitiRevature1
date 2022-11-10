import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { Viewer } from '../Models/UserModels';
// import { environment as env } from 'src/environments/environment';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public mySET_User: any
  public getAccount?: object 
  // private  accoun?: Viewer = {}

  constructor(public http: HttpClient, public auth: AuthService) { 
    this.http;
    this.auth;
  }

  public static heldChecks:boolean;


  public API1_main_data: string = env.API1;
  public API2_user_data: string = env.API2;


  public loginwithRedirect() : Observable<any>{
    return this.auth.loginWithRedirect()
  }

  // public CHECK_IF_EMAIL_EXISTS(email: string) : boolean
  // {
  //   this.http.get<boolean>(this.API2_user_data + `check-email/${email}`).subscribe((data:boolean) => UserService.heldChecks = data)
  //   return UserService.heldChecks;
  // }

  // public CHECK_IF_USERNAME_EXISTS(username: string) : boolean
  // {
  //   this.http.get<boolean>(this.API2_user_data + `check-username/${username}`).subscribe((data:boolean) => UserService.heldChecks = data)
  //   return UserService.heldChecks;
  // }

  // public SignUp(email?:string, username?:string, password?:string ) : Observable<boolean>
  // {
  //   return this.http.post<boolean>(this.API1_main_data + "/signup", JSON.stringify({"email": email, "username": username, "password": password}));
  // }

  // public Login_email(email?:string, password?:string) : Observable<any>
  // {
  //   return this.http.post<any>(this.API2_user_data + `login-email`, JSON.stringify({"email":email, "password":password}))
  // }

  // public Login_username(username?:string, password?:string) : Observable<any>
  // {
  //   return this.http.post<any>(this.API2_user_data + `login-username`, JSON.stringify({"username":username, "password":password}))
  // }

  // public CHANGE_PASSWORD()
  // {
    
  // }
 


}
