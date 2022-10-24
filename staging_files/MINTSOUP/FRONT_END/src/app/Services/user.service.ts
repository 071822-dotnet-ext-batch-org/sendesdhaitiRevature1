import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginDTO, Viewer } from '../Models/User';
import { AuthService } from '@auth0/auth0-angular';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private currentuser: any;
  private mySET_User: Viewer = {}
  private getAccount: object = {
    auth0ID : "",
    email: ""
  }
  private  account: Viewer = {}
  constructor(private http: HttpClient, private auth: AuthService) { 
    this.http;
  }

  private API: string = "https://localhost:7094/";
  public loginwithRedirect(loginDTO: LoginDTO) : Observable<any>{
    let res = this.auth.loginWithRedirect()
    res.subscribe(data => {
        this.currentuser = data
    })
    console.log(this.currentuser.user$)
    return this.currentuser;
    // let user = {
    //   id: this.currentuser.user$
    // }
    // this.loginUser()
  }
  public loginUser(getAccount: object) : Observable<Viewer>
  {
    let res = this.http.post(this.API + "/mint-soup/login", this.getAccount);
    return res
  }
  public SET_CurrentUsersID_OnLoad(setUserID:string) :void
  {
    this.mySET_User.Auth0ID = setUserID;
  }
  public GET_CurrentUsersID_OnLoad(): Viewer
  {
    return this.mySET_User;
  }
}
