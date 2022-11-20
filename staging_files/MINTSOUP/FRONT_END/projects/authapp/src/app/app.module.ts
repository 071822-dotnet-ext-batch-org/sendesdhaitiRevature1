import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { RegisterComponent } from './Components/register/register.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './Components/change-password/change-password.component';
import { AccountComponent } from './Components/account/account.component';
import { JwtHelperService, JWT_OPTIONS, JwtModuleOptions } from '@auth0/angular-jwt';
import { AuthSoupToken } from './Services/user.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { NavComponent } from './Components/nav/nav.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthSoupService } from './Services/user.service';

const providers:any = [{
    provide:JWT_OPTIONS, useValue: JWT_OPTIONS
  },
  // {HTTP_INTERCEPTORS:HTTP_INTERCEPTORS},
  JwtHelperService

]

// const JWT_Module_Options: JwtModuleOptions = {
//   config: {
//       tokenGetter: AuthSoupService.get_mstoken_from_local_storage,
//       whitelistedDomains: []
//   }
// };
const routes: Routes = [
  // {path: '', redirectTo: "account"},
  {path: 'mint/login', component: LoginComponent},
  {path: 'mint/logout', component: LogoutComponent},
  {path: 'mint/register', component: RegisterComponent},
  {path: 'mint/forgot-password', component: ForgotPasswordComponent},
  {path: 'mint/account', component: AccountComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ChangePasswordComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: providers,
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