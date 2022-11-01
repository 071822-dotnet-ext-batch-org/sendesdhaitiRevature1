import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { Viewer } from '../Models/UserModels';
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

  public API: string = env.API.audience.audience;


  public loginwithRedirect() : Observable<any>{
    return this.auth.loginWithRedirect()
  }

  public createViewer_On_SignUp(auth0ID?:string, email?:string ) : Observable<any>
  {
    return this.http.post(this.API + "/register", JSON.stringify({"auth0ID": auth0ID, "email": email}));
  }
 


  public GET_or_Create_myViewer(auth0ID?: string, email?: string) : Observable<Viewer>
  {
    let res: any = null;
    console.log(`checking GET_or_Create_myViewer ${auth0ID} and ${email}`)
    this.createViewer_On_SignUp(auth0ID, email).subscribe((check: any) => {
      console.log(`This is the return for the create viewer action ${check}`)
    });
    res = this.http.post(this.API + "/my-viewer", JSON.stringify({"auth0ID": auth0ID}));
    return res
  }

}
