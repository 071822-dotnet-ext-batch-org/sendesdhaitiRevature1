import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { AuthModule } from '@auth0/auth0-angular';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { HomeComponent } from './Components/home/home.component';
import { NavComponent } from './Components/nav/nav.component';
import { AuthenticationPageComponent } from './Components/authentication-page/authentication-page.component';
import { FooterComponent } from './Components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    HomeComponent,
    NavComponent,
    AuthenticationPageComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    AuthModule.forRoot({
      ...env.Auth0.domain,
      ...env.Auth0.clientId
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
