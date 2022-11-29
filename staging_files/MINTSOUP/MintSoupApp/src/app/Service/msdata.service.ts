import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { Injectable} from '@angular/core';
// import { MS_Service_Actions_and_Operations as MSACTIONS } from 'projects/authentication/src/app/Service/ms_service_actions_and_operations';
import { IViewer, Viewer } from './Viewer';
import { Observable, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { formatDate } from '@angular/common';


@Injectable({
  providedIn: 'root'

})

// @NgModule()  
export class MSDataService {
  private API:any = env.API.Data.Data
  private mstoken:any;
  private jwtToken:any;
  private DO__YOU__HAVE__THE__TOKEN?:boolean;
  public myviewer?: IViewer;
  private header: HttpHeaders = new HttpHeaders();

    constructor(private http:HttpClient, private helper:JwtHelperService){
      this.getToken()
  }
  Does__Component__Have__Token():boolean | undefined{
    return this.DO__YOU__HAVE__THE__TOKEN;
  }

  getToken()
  {
    let token = localStorage.getItem("MINTSOUPTOKEN")
    if(token && !this.helper.isTokenExpired(token))
    {
      // const newtok = JSON.stringify(token)
      const helper = new JwtHelperService();
      this.jwtToken = token;

      //decode the token 
      const decodedToken = helper.decodeToken(token);
      this.mstoken = decodedToken;
      this.DO__YOU__HAVE__THE__TOKEN = true;
      
      console.log(`At ${Date.now()} - token gotten was ${this.mstoken.sid}`)
      return this.mstoken;
    }
    else
    {
      localStorage.removeItem("MINTSOUPTOKEN")
      this.mstoken = null
      this.DO__YOU__HAVE__THE__TOKEN = false;
      console.log(`At ${Date.now()} - token gotten was ${this.mstoken}`)
      return this.mstoken;
    }
  }

  // setViewer(iviewer:IViewer):void{
  //   let viewer = new Viewer(iviewer);
  //   this.myviewer = viewer.getViewer();
  //   console.log(`At ${new Date().toLocaleDateString()} ${new Date().toLocaleTimeString()} - the viewer was gotten successfully with ${this.myviewer?.MSToken}`)
  // }
  sendRequest_to_GET_Viewer(): Observable<IViewer>
  {
    this.header = new HttpHeaders({
      "Authorization":`bearer ${JSON.parse(this.jwtToken).token}` ,
      "mstoken": this.mstoken.sid
    })

    return this.http.get<IViewer>(this.API + "my-viewer/", {headers: this.header})
  }

  // getViewer()
  // {
  //   return this.myviewer;
  // }
  
  
}
