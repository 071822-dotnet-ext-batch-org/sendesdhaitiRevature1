import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LoginComponent } from './Components/login/login.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { RegisterComponent } from './Components/register/register.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './Components/change-password/change-password.component';
import { AccountComponent } from './Components/account/account.component';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { NavComponent } from './Components/nav/nav.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

const providers:any = []
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
    RouterModule.forRoot(routes)
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