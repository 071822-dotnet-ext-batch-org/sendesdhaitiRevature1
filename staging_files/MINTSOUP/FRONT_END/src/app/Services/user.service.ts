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

  public API1_main_data: string = env.API1;
  public API2_user_data: string = env.API2;


  public loginwithRedirect() : Observable<any>{
    return this.auth.loginWithRedirect()
  }

  public createViewer_On_SignUp(mintsoupID?:string, email?:string ) : Observable<any>
  {
    return this.http.post(this.API1_main_data + "/register", JSON.stringify({"mintsoupID": mintsoupID, "email": email}));
  }
 


  public GET_or_Create_myViewer(mintsoupID?: string, email?: string) : Observable<Viewer>
  {
    let res: any = null;
    console.log(`checking GET_or_Create_myViewer ${mintsoupID} and ${email}`)
    this.createViewer_On_SignUp(mintsoupID, email).subscribe((check: any) => {
      console.log(`This is the return for the create viewer action ${check}`)
    });
    res = this.http.post(this.API1_main_data + "/my-viewer", JSON.stringify({"mintsoupID": mintsoupID}));
    return res
  }

}
