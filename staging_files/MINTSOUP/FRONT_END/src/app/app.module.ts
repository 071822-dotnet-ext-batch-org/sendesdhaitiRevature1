import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { AuthModule , AuthHttpInterceptor} from '@auth0/auth0-angular';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

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
    // AuthModule.forRoot({
    //   // ...env.Auth0.domain,
    //   ...env.Auth0.clientId,
    //   ...env.API.audience,
    //   httpInterceptor: {
    //     allowedList: [
    //       `${env.API.DATA_API}/del-my-showlike`,
    //       `${env.API.audience.audience}/update-my-viewer`,
    //       `${env.API.audience.audience}/my-viewer`,
    //       `${env.API.audience.audience}/my-admin`,
    //       `${env.API.audience.audience}/login`,
    //       `${env.API.audience.audience}/register`
    //     ]
    //   }
    // }),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
