import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { LoginDTO } from '../Components/login/login.component';
import { Observable, from, of, throwError, catchError, retry} from 'rxjs';
import { map } from 'rxjs';

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


  

  public CHECK_IF_EMAIL_EXISTS(email: string) : any
  {
    this.http.get<any>(this.API + "check-email/" + encodeURIComponent(email)).subscribe((data:any) => {UserService.heldChecks = data; console.log(data)})
    // var xhr = new XMLHttpRequest();
    // xhr.open('get', this.API + `check-email/${encodeURIComponent(email)}`);
    // xhr.withCredentials = true;
    return UserService.heldChecks;
  }

  public CHECK_IF_USERNAME_EXISTS(username: string) : any
  {
    this.http.get<any>(this.API + `check-username/${encodeURIComponent(username)}`).subscribe((data:any) => UserService.heldChecks = data)
    return UserService.heldChecks;
  }

  public SignUp(_email?:string, _username?:string, _password?:string ) : Observable<boolean>
  {
    return this.http.post<boolean>(this.API + "signup", JSON.stringify({email: _email, username: _username, password: _password}));
  }

  public Login_email(_email?:string, _password?:string) : Observable<any>
  {
    return this.http.post<any>(this.API + `login-email`, JSON.stringify({email: _email, password: _password}))
  } 

  public Login_username(_username?:string, _password?:string) : Observable<any>
  {
    return this.http.post<any>(this.API + `login-username`, JSON.stringify({username: _username, password: _password}))
  }

  public CHANGE_PASSWORD()
  {
    
  }

}
