import { Component, Inject, Injectable , Input, Output} from '@angular/core';
import { environment as env } from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable, from, of, throwError, catchError, retry} from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

export interface MSToken{
  token?:string
};
//The mintSoup JWT Token class
@Injectable({
  providedIn: 'root'
})
export abstract class  AuthSoupToken{

  @Input() private msToken?:MSToken
  private jwthelper:JwtHelperService
  constructor(public helper:JwtHelperService){
    // this.msToken = mst;
    this.jwthelper = helper;
  }


  public async logout():Promise<void>{
    const MyToken = localStorage.getItem("MINTSOUPTOKEN")
    if(MyToken)
    {
      localStorage.removeItem("MINTSOUPTOKEN")
    }
  }

  public async isAuthenticated(){
    const MyToken = localStorage.getItem("MINTSOUPTOKEN")
    if(MyToken && !this.jwthelper.isTokenExpired(MyToken))
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}


@Injectable({
  providedIn: 'root'
})


export class UserService {

  private API: string = env.API.auth_api;
  @Input() public static username_check?:boolean
  @Input() public static email_check?:boolean
  // private MyToken?:string;

  constructor(private http: HttpClient, private soup: AuthSoupToken, private jwt:JwtHelperService) { this.jwt;}
  static heldChecks:boolean;

  public httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin':'*',
      'X-Requested-With': 'XMLHttpRequest'
    })
   };


  

  public CHECK_IF_EMAIL_EXISTS(email: string) : Observable<boolean>
  {
    return this.http.get<boolean>(this.API + "check-email/" + encodeURIComponent(email.toLocaleLowerCase()) )
  }

  public CHECK_IF_USERNAME_EXISTS(username: string) : Observable<boolean>
  {
    return this.http.get<boolean>(this.API + "check-username/" + encodeURIComponent(username.toLocaleLowerCase()) )
  }

  public SignUp(_email:string, _username:string, _password:string ) : Observable<boolean>
  {
    return this.http.post<boolean>(this.API + "signup", {email: _email.toLocaleLowerCase(), username: _username.toLocaleLowerCase(), password: _password.toLocaleLowerCase()});
  }

  public Login_email(_email:string, _password:string) : Observable<string>
  {
    return this.http.post(this.API + `login-email`, {email: _email.toLocaleLowerCase(), password: _password.toLocaleLowerCase()}, {responseType: 'text'})
  } 

  public Login_username(_username:string, _password:string) : Observable<string>
  {
    return this.http.post(this.API + `login-username`, {username: _username.toLocaleLowerCase(), password: _password.toLocaleLowerCase()}, {responseType: 'text'})
  }

  public CHANGE_PASSWORD()
  {
    
  }





  add_mstoken_to_session_storage(email?:string, token?:string):void
  {
    if(token)
    {
      localStorage.setItem("MINTSOUPTOKEN", token);
    }
  }

  check_email(email:string){
    if(email)
    {
      this.CHECK_IF_EMAIL_EXISTS(email).subscribe((data:boolean) => {UserService.email_check = data; console.log(`The check data: ${data}`)}, err => {
        UserService.email_check = false;
      })
      let s = UserService.email_check
      if(s == true)
      {
        return s;
      }
      else if(s == false)
      {
        return s;
      }
      else{
        return null;
      }
    }
    else return null;
  }

  logout()
  {
    this.soup.isAuthenticated().then(check =>
      {
        //redirect to the logged screen
      })
  }










  check_username(username:string){
    // let check:boolean = false;
    if(username)
    {
      this.CHECK_IF_USERNAME_EXISTS(username).subscribe(data => {UserService.username_check = data;console.log(`The check data: ${data}`)}, err => {
        UserService.username_check = false;
      })
      let s = UserService.username_check
      if(s == true)
      {
        return s;
      }
      else if(s == false)
      {
        return s;
      }
      else{
        return null;
      }
    }
    else return null;
  }
  async get_email_check()
  {
    return UserService.email_check?.valueOf()
  }
  async get_username_check()
  {
    return UserService.username_check?.valueOf()
  }






}
