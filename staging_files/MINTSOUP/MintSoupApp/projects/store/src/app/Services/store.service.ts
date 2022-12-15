import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { GeolocationService } from '@ng-web-apis/geolocation';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http:HttpClient, private helper:JwtHelperService, private geo:GeolocationService) { }
  private tokencheck:boolean = false;
  private API:string = env.API.Data.Data;

  get_token()
  {
    let token = localStorage.getItem("MINTSOUPTOKEN")
    if(token && !this.helper.isTokenExpired(token))
    {
      this.tokencheck = true;
    }
  }//END

  get_location() 
  {
    return this.geo
  }

  get_api_location(): Observable<any>
  {
    return this.http.get('https://ipapi.co/json/', );
  }

  public get_all_stores(): Observable<any> | void
  {
    if(this.tokencheck)
    {
      this.http.get<any>(this.API + "", {responseType: "json"})
    }
  }//END
}
