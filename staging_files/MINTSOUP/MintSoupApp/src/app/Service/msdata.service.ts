import { HttpClient, HttpHeaders as Headers, HttpHeaders , HttpClientModule} from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { Inject, Injectable , Injector, NgModule} from '@angular/core';
import { MS_Service_Actions_and_Operations as MSACTIONS } from 'projects/authentication/src/app/Service/ms_service_actions_and_operations';
import { IViewer, Viewer } from './Viewer';
import { Observable, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
// import * as jwt_decode from "jwt-decode";
// import { HTTP_PROVIDER } from './app.config';


@Injectable({
  providedIn: 'root'

})

// @NgModule()  
export class MSDataService {
  private API:any = env.API.Data
  private mstoken:any
  // private requestheader?:HttpHeaders;
  private MSTOKEN_HEADER_CHECK?:boolean; 
  private DO__YOU__HAVE__THE__TOKEN?:boolean;
  public myviewer: Viewer = new Viewer();

  // constructor( private http: HttpClient) {
  //   // this.addToken_to_header()
  //   // this.sendRequest_to_GET_Viewer()
  //  }
  constructor(private http:HttpClient){
    this.getToken()
    // let go = of(this.sendRequest_to_GET_Viewer())
    // if(this.DO__YOU__HAVE__THE__TOKEN)
    // {
    //   go.subscribe()
    //   console.log(`This is my Viewer - ${this.myviewer.myViewer?.MSToken}`)
    // }
  }
  Does__Component__Have__Token():boolean | undefined{
    return this.DO__YOU__HAVE__THE__TOKEN;
  }

  getToken()
  {
    let token = localStorage.getItem("MINTSOUPTOKEN")
    if(token)
    {
      // const newtok = JSON.stringify(token)
      const helper = new JwtHelperService();

      //decode the token 
      const decodedToken = helper.decodeToken(token);
      this.mstoken = decodedToken;
      this.DO__YOU__HAVE__THE__TOKEN = true;
      console.log(`At ${Date.now()} - token gotten was ${this.mstoken.sid} - converted is `)
      return this.mstoken;
    }
    this.mstoken = null
    this.DO__YOU__HAVE__THE__TOKEN = false;
    console.log(`At ${Date.now()} - token gotten was ${this.mstoken}`)
    return this.mstoken;
  }
  // private addToken_to_header()
  // {
  //   let token = this.getToken()
  //   if(token)
  //   {
  //     this.requestheader.append("Authorization",`Bearer ${token}`)
  //     console.log(`At ${Date.now} - headers added as '${this.MSTOKEN_HEADER_CHECK}' - true means it exists`)
  //   }
  // }

  // private addKeyval_to_header(key:string, val:any)
  // {
  //   this.requestheader.append(key,val);
  //   console.log(`At ${Date.now} - headers added as '${this.MSTOKEN_HEADER_CHECK}' - true means it exists`);
  // }

  // private removeKeyval_from_header(key:string)
  // {
  //   this.requestheader.delete(key)
  //   console.log(`At ${Date.now} - header was deleted as '${this.MSTOKEN_HEADER_CHECK}' - false is nonexistant`);
  // }
  setViewer(viewer:IViewer):void{
    this.myviewer.setViewer(viewer)
    console.log(`At ${Date.now()} - the viewer was gotten successfully with ${this.myviewer.myViewer?.MSToken}`)
  }
  sendRequest_to_GET_Viewer(): Observable<IViewer>
  {
    return this.http.get<IViewer>(this.API + "my-viewer/", {headers:this.mstoken.sid})
    // console.log(`At ${Date.now()} - headers added as to the request as '${this.MSTOKEN_HEADER_CHECK}' - true means it exists`)
    // if(this.MSTOKEN_HEADER_CHECK)
    // {
    //   if(viewer)
    //   {
    //     viewer.subscribe(
    //       {
    //         next: (ret:IViewer) => {
    //           this.setViewer(ret)
    //         },
    //         error: (err) => {
    //           console.log(`At ${Date.now()} - the viewer was not gotten successfully with ${err}`)
    //         },
    //         complete: () =>
    //         {
    //           console.log(`At ${Date.now()} - the viewer request completed`)
    //         }
    //       }
    //     )//End of subscribe

        
    //   }
    // }
  }

  getViewer()
  {
    return this.myviewer.myViewer;
  }
  
  
}
