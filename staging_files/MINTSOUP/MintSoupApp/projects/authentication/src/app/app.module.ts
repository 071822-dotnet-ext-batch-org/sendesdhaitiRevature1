import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpHeaders } from '@angular/common/http';
import { JwtHelperService, JWT_OPTIONS , JwtModule } from '@auth0/angular-jwt';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MSAuthenticationService } from './Service/msauthentication.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './Components/nav/nav.component';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { RegisterComponent } from './Components/register/register.component';
import { AccountComponent } from './Components/account/account.component';
import { AboutComponent } from './Components/about/about.component';
import { MS_Service_Actions_and_Operations as MSACTIONS} from './Service/ms_service_actions_and_operations';
import { MSGuard } from './Service/ms.guard';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';


const providers:any = [{
  provide:JWT_OPTIONS, useValue: JWT_OPTIONS, 
  },
  // {MSACTIONS},
  // {HTTP_INTERCEPTORS:HTTP_INTERCEPTORS},
  JwtHelperService

]
const routes:Routes = [
  {path: "", component: NavComponent},
  {path: "mint", component: AboutComponent},
  // {path: "mint/about", component: AboutComponent},
  {path: "mint/login", component: LoginComponent},
  {path: "mint/logout", component: LogoutComponent},
  {path: "mint/register", component: RegisterComponent},
  {path: "mint/account", component: AccountComponent},//, canActivate: [MSGuard]}
  {path: "mint/forgot-password", component: ForgotPasswordComponent}

]


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent,
    AccountComponent,
    AboutComponent,
    ForgotPasswordComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getMSTOKEN,
        allowedDomains: ["localhost:7215", "localhost:7094"],
        disallowedRoutes: []
      }})
  ],
  providers: [
    MSGuard, 
    // HttpHeaders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


@NgModule({})
export class MintSoupAuthModule{
  static forRoot():
  ModuleWithProviders<MintSoupAuthModule>{
    return {
      ngModule: AppModule,
      providers: providers,
    }
  }
}


export abstract class moduleToken
{
  static token:any = localStorage.getItem("MINTSOUPTOKEN")
  static istokenExpired?:boolean
  constructor(public  jwthelper:JwtHelperService){
    console.log(`The token in the module is ${moduleToken.token}`)
    moduleToken.istokenExpired = !this.jwthelper.isTokenExpired(moduleToken.token)
  }

  public static getToken():null | any{
    let token =  this.token
    if(token && moduleToken.istokenExpired)
    {
      return token;
    }
    else{
      localStorage.removeItem("MINTSOUPTOKEN")
      return null
    }
  }
}
export function getMSTOKEN(): null | any{
  console.log(`The token in the module is ${moduleToken.token}`)
  let token =  moduleToken.getToken()
  if(token)
  {
    return token;
  }
  else{
    return null
  }
}
