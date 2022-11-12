import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { LoginDTO } from '../Components/login/login.component';
import { Observable, from, of, throwError, catchError, retry} from 'rxjs';
import { map , interval, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private API: string = env.API.auth_api;
  // private MyToken?:string;

  constructor(private http: HttpClient) { }
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
    return this.http.get<boolean>(this.API + "check-email/" + encodeURIComponent(email) )
  }

  public CHECK_IF_USERNAME_EXISTS(username: string) : Observable<boolean>
  {
    return this.http.get<boolean>(this.API + "check-username/" + encodeURIComponent(username) )
  }

  public SignUp(_email?:string, _username?:string, _password?:string ) : Observable<boolean>
  {
    return this.http.post<boolean>(this.API + "signup", {email: _email, username: _username, password: _password});
  }

  public Login_email(_email?:string, _password?:string) : Observable<string>
  {
    return this.http.post(this.API + `login-email`, {email: _email, password: _password}, {responseType: 'text'})
  } 

  public Login_username(_username?:string, _password?:string) : Observable<string>
  {
    return this.http.post(this.API + `login-username`, {username: _username, password: _password}, {responseType: 'text'})
  }

  public CHANGE_PASSWORD()
  {
    
  }


  // public source$ = interval(1000).pipe(take(4));

  // async function getTotal() {
  //   let total = 0;

  //   await source$.forEach(value => {
  //     total += value;
  //     console.log('observable -> ' + value);
  //   });
  // }


}
