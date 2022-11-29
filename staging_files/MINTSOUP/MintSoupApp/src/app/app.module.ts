import { NgModule } from '@angular/core';
import { Injector } from  '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MintSoupAuthModule } from 'projects/authentication/src/app/app.module';
import { Routes, RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavComponent } from './Components/nav/nav.component';
import { HomeComponent } from './Components/home/home.component';
import { FooterComponent } from './Components/footer/footer.component';
import { MSDataService } from './Service/msdata.service';
import { ShowComponent } from './Components/show/show.component';
import { ShowSessionComponent } from './Components/show-session/show-session.component';
import { MenuComponent } from './Components/menu/menu.component';

const routes: Routes = [
  {path: '', loadChildren:  () => MintSoupAuthModule},
  {path: 'shows', component: ShowComponent},
  {path: 'shows/sesssion', component: ShowSessionComponent},
  // {path: "home", component: HomeComponent},
  // { path: '**', redirectTo: ''}
]
  
  @NgModule({
    declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      FooterComponent,
      ShowComponent,
      ShowSessionComponent,
      MenuComponent
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      RouterModule.forRoot(routes),
      HttpClientModule,
      MintSoupAuthModule.forRoot()
    ],
    providers: [
      HttpClientModule,//HttpClient, HttpHeaders,
      MSDataService
      // HttpClientModule,HttpClient, HttpHeaders, 
      // MSDataService
    ],
    bootstrap: [AppComponent]
  })
  export class AppModule {
  constructor() {}
}
