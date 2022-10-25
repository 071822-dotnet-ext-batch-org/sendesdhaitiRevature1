import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { Viewer } from '../Models/UserModels';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public mySET_User: any
  public getAccount?: object 
  // private  accoun?: Viewer = {}

  constructor(private http: HttpClient, private auth: AuthService) { 
    this.http;
    this.auth;
  }

  private API: string = "https://localhost:7094/mint-soup";


  public loginwithRedirect() : Observable<any>{
    let res = this.auth.loginWithRedirect()
    return res;
  }

  public createViewer_On_SignUp(auth0ID:string, email:string ) : Observable<Viewer>
  {
    // this.auth.buildAuthorizeUrl().subscribe(url => {
    //   return this.API + url;
    // })
    let res = this.http.post(this.API + "/register", {"auth0ID": auth0ID, "email": email});
    return res
  }
  public getAuthAfterLogin()
  {
    return this.mySET_User = this.auth.getAccessTokenSilently()
  }


  public GET_myViewer(auth0ID:string) : Observable<Viewer>
  {
    let res = this.http.post(this.API + "/my-viewer", {"auth0ID": auth0ID});
    return res
  }

  public SET_userFromAuth0_IN_UserSERVE(userData?:any) :void
  {
    this.mySET_User = userData;
  }

  public GET_userFromAuth0_setIN_UserSERVE() :any
  {
    return this.mySET_User;
  }
}
