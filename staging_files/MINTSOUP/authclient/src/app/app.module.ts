import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import {MSGuard} from './Services/ms.guard';
import { Router, RouterModule } from '@angular/router';
import { AuthSoupToken } from './Services/user.service';
import { JwtHelperService , JWT_OPTIONS} from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { PoliciesComponent } from './Components/policies/policies.component';
import { ChangePasswordComponent } from './Components/change-password/change-password.component';
import { PasswordChangedComponent } from './Components/password-changed/password-changed.component';
import { NavComponent } from './Components/nav/nav.component';


import { UserService } from './Services/user.service';
import { HomeComponent } from './Components/home/home.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { AccountComponent } from './Components/account/account.component';

export function getMSTOKEN(){
  return localStorage.getItem("MINTSOUPTOKEN")
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    PoliciesComponent,
    ChangePasswordComponent,
    PasswordChangedComponent,
    NavComponent,
    HomeComponent,
    LogoutComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
      {path: 'account', component: AccountComponent , canActivate: [MSGuard]},
      {path: 'logout', component: LogoutComponent},
      {path: 'forgot-password', component: ForgotPasswordComponent},
      {path: 'change-password', component: ChangePasswordComponent},
      {path: 'password-changed', component: PasswordChangedComponent},
      {path: 'policies', component: PoliciesComponent},
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: getMSTOKEN,
        allowedDomains: ["localhost:7215", "localhost:7094"],
        disallowedRoutes: []
      }
    }),
    
  ],
  providers: [ {
    provide:JWT_OPTIONS, useValue: JWT_OPTIONS
  }, MSGuard, JwtHelperService, ],
  bootstrap: [AppComponent]
})
export class AppModule { }
