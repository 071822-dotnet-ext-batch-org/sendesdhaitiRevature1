import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MainMSGuardGuard implements CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = localStorage.getItem("JWT");
      if(token && !this.jwtHelper.isTokenExpired(token)){
        return true;
      }
      else{
        this.router.navigate([""]);
        return false;
      }
  }
  
}
