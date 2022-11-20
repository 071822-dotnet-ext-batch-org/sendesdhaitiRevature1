import { JwtHelperService } from "@auth0/angular-jwt";
import { Injectable, Component } from "@angular/core";
import { of, from, interval } from "rxjs";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export abstract class MS_Service_Actions_and_Operations
{
    constructor(private jwthelper:JwtHelperService, private router: Router){}

    public add_mstoken_to_session_storage(token?:string):void{
        if(token)
        {
        localStorage.setItem("MINTSOUPTOKEN", token);
        }
    }

    public getTokenFromStorage(): any | null{
        let token = localStorage.getItem("MINTSOUPTOKEN");
        if(token)
        {
            return token;
        }
        else return null;
    }
    public async  logout():Promise<void>{
        const MyToken = localStorage.getItem("MINTSOUPTOKEN")
        if(MyToken)
        {
          let exe = of(localStorage.removeItem("MINTSOUPTOKEN"))
          const wait = interval(1000 /* number of milliseconds */);
          if(exe)
          {
            exe.subscribe(
                data => {
                    wait.subscribe().unsubscribe()
                    this.router.navigate(["home"])
                }
            )

            
          }
        }
    }
    
    public isAuthenticated(): boolean {
        const MyToken = localStorage.getItem("MINTSOUPTOKEN")
        if(MyToken && !this.jwthelper.isTokenExpired(MyToken))
        {
            console.log(`You are logged in already`)
            return true;
        }
        else
        {
            console.log(`You are not logged in`)
            return false;
        }
    }

    

    
}