import { Injectable } from '@angular/core';
import { MS_Service_Actions_and_Operations as MSACTIONS } from './ms_service_actions_and_operations';
import { HttpClient, HttpHeaders as Headers} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment as env } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MSAuthenticationService {

  private API:any = env.API.Auth
  private static  emailcheck?:boolean
  private static  usernamecheck?:boolean

  constructor(private http: HttpClient, private msaction: MSACTIONS) { 
    let token = localStorage.getItem("MINTSOUPTOKEN")
    let check = this.isAuthenticated()
    if((check == true) && (token))
    {
      this.keep_token(token)
    }
  }

  ngOnInit(): void {
  }

  //-----------------------------------------------REQUESTS SECTION---------------------------------------------------------------------
  public check_Email(email:string): Observable<boolean> | null
  {
    console.log(this.API)
    return this.http.get<boolean>(this.API + "check-email/" + encodeURI(email.toLocaleLowerCase()) )
  }

  public check_Username(username:string): Observable<boolean> | null
  {
    return this.http.get<boolean>(this.API + "check-email/" + encodeURI(username.toLocaleLowerCase()) )
  }

  public SignUp(_email:string, _username:string, _password:string ) : Observable<boolean>
  {
    return this.http.post<boolean>(this.API + "signup", {email: _email.toLocaleLowerCase(), username: _username.toLocaleLowerCase(), password: _password.toLocaleLowerCase()});
  }

  public Login_email(_email:string, _password:string) : Observable<any>
  {
    // this.requestheader.append("email",_email)
    // this.requestheader.append("password",_password)
    // console.log(`The request header parameters ${this.requestheader.getAll}`)
    return this.http.post(this.API + `login-email`, {email: _email.toLocaleLowerCase(), password: _password.toLocaleLowerCase()}, {responseType: 'text'})
  } 

  public Login_username(_username:string, _password:string) : Observable<any>
  {
    return this.http.post(this.API + `login-username`, {username: _username.toLocaleLowerCase(), password: _password.toLocaleLowerCase()}, {responseType: 'text'})
  }

  //-----------------------------------------------ACTIONS SECTION---------------------------------------------------------------------
  check_email(email:string){
    if(email)
    {
      let check = this.check_Email(email);
      check?.subscribe( (_check: boolean) => {
        MSAuthenticationService.emailcheck = _check;
        console.log(`This username is ${MSAuthenticationService.emailcheck}`);
      },
        err => {
          MSAuthenticationService.emailcheck = false;
          console.log(`This username is ${MSAuthenticationService.emailcheck} due to an error`);
      })
      let s = MSAuthenticationService.emailcheck
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

  check_username(username:string){
    if(username)
    {
      let check = this.check_Username(username);
      check?.subscribe( (_check: boolean) => {
        MSAuthenticationService.usernamecheck = _check;
        console.log(`This username is ${MSAuthenticationService.usernamecheck}`);
      },
        err => {
          MSAuthenticationService.usernamecheck = false;
          console.log(`This username is ${MSAuthenticationService.usernamecheck} due to an error`);
      })
      let s = MSAuthenticationService.usernamecheck
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
    return MSAuthenticationService.emailcheck?.valueOf()
  }
  async get_username_check()
  {
    return MSAuthenticationService.usernamecheck?.valueOf()
  }

  isAuthenticated():boolean
  {
    return this.msaction.isAuthenticated();
  }
  logout():void
  {
    this.msaction.logout()
  }

  keep_token(token?:string):void
  {
    if(token)
    {
      this.msaction.add_mstoken_to_session_storage(token)
    }
  }
}
