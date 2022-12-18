import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { GeolocationService } from '@ng-web-apis/geolocation';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';
import { Product, Store } from '../store/store.component';
import { HttpHeaders } from '@angular/common/http';
import { getMSTOKEN } from 'projects/authentication/src/app/app.module';


@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http:HttpClient, private helper:JwtHelperService, private geo:GeolocationService) { 
    this.get_token()
  }
  private tokencheck:boolean = false;
  private API:string = env.API.Data.Data;
  private header: HttpHeaders = new HttpHeaders();
  private mstoken:any;
  
  get_token():Observable<boolean>
  {
    let token = localStorage.getItem("MINTSOUPTOKEN")
    if(token && !this.helper.isTokenExpired(token))
    {
      // const newtok = JSON.stringify(token)
      const helper = new JwtHelperService();
      //decode the token 
      const decodedToken = helper.decodeToken(token);
      this.mstoken = decodedToken;
      this.tokencheck = true;
      this.header = new HttpHeaders({ 
        "Authorization":`bearer ${JSON.parse(token).token}` ,
        "mstoken": this.mstoken.sid
      })

      console.log(`${JSON.parse(token)} and ${this.mstoken.sid} and ${JSON.parse(token).token}`)
    }
    return new Observable<boolean>(sub =>
      {
        sub.next(this.tokencheck);
        sub.next(this.mstoken)
      });

  }//END

  get_location() 
  {
    return this.geo
  }

  get_api_location(): Observable<any>
  {
    return this.http.get('https://ipapi.co/json/');
  }

  public get_all_stores(): Observable<Store[]>
  {
    if(this.tokencheck)
    {
      console.log(`getting stores`)
      return this.http.get<Store[]>(this.API + "stores", {responseType: "json",headers: this.header})
    }
    else
    {
      return new Observable<Store[]>();

    }
  }//END

  public get_products(category?:string, type?:number, name?:string)
  {
    
    console.log(`getting products`)
    return this.http.post<Product[]>(this.API + `get-products/`, {
      "category": category,
      "type": type,
      "name": name
    }, {headers: this.header})
  }
}
