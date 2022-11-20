import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { AuthModule , AuthHttpInterceptor} from '@auth0/auth0-angular';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { LoadChildrenCallback } from '@angular/router';
// import { LoadChildren } from '@angular/router';
import { MintSoupAuthModule } from 'projects/authapp/src/app/app.module';//the mint soup authentication sub application

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { HomeComponent } from './Components/home/home.component';
import { NavComponent } from './Components/nav/nav.component';
import { AuthenticationPageComponent } from './Components/authentication-page/authentication-page.component';
import { FooterComponent } from './Components/footer/footer.component';
import { LoadingComponent } from './Components/loading/loading.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SpinnerComponent } from './Components/spinner/spinner.component';
import { GuestComponent } from './Components/guest/guest.component';
import { MenuComponent } from './Components/menu/menu.component';
import { SearchComponent } from './Components/search/search.component';
import { ShowsComponent } from './Components/shows/shows.component';
import { AccountComponent } from './Components/account/account.component';
import { MSGuard } from 'projects/authapp/src/app/Services/ms.guard';
import { MainMSGuardGuard } from './main-msguard.guard';
const routes: Routes = [
  {path: 'mint', loadChildren:  () => MintSoupAuthModule}
  // { path: '**', redirectTo: ''}
]
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    HomeComponent,
    NavComponent,
    AuthenticationPageComponent,
    FooterComponent,
    LoadingComponent,
    SpinnerComponent,
    GuestComponent,
    MenuComponent,
    SearchComponent,
    ShowsComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    MintSoupAuthModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MainMSGuardGuard,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
