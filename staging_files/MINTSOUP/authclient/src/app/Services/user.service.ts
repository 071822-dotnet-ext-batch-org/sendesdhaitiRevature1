import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import {HttpClient} from '@angular/common/http';
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

  check_with_email(email:string): Observable<boolean>{
    return  this.http.get<boolean>(this.API + email, {
      observe: 'body',
      responseType:'json'
    })
  }
  check_with_username(username:string): Observable<boolean>{
      return this.http.get<boolean>(this.API + username, {
        observe: 'body',
        responseType:'json'
      })
  }

  login_email(login_form_email:string, password:string): Observable<string>
  {
   return this.http.post<string>(this.API, {"email": login_form_email, "password": password}  )
  }

  login_username(login_form_username:string, password:string): Observable<string>
  {
   return this.http.post<string>(this.API, {"username": login_form_username, "password": password}  )
  }
}
