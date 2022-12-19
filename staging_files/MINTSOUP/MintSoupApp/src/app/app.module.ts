import { NgModule } from '@angular/core';
import { Injector } from  '@angular/core';
import { BrowserModule } from '@angular/platform-browser';



import { MintSoupAuthModule } from 'projects/authentication/src/app/app.module';
import { BookingModule } from 'projects/booking/src/app/app.module';





import { Routes, RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavComponent } from './Components/nav/nav.component';
import { HomeComponent } from './Components/home/home.component';
import { FooterComponent } from './Components/footer/footer.component';
import { MSDataService } from './Service/msdata.service';
import { MenuComponent } from './Components/menu/menu.component';
import { CustomerModule } from 'projects/customer/src/app/app.module';
import { EmployeeModule } from 'projects/employee/src/app/app.module';
import { OrdersModule } from 'projects/orders/src/app/app.module';
import { SettingsModule } from 'projects/settings/src/app/app.module';
import { StoreModule } from 'projects/store/src/app/app.module';

const routes: Routes = [
  {path: '', loadChildren:  () => MintSoupAuthModule},
  {path: '', loadChildren:  () => BookingModule},
  {path: '', loadChildren:  () => CustomerModule},
  {path: '', loadChildren:  () => EmployeeModule},
  {path: '', loadChildren:  () => OrdersModule},
  {path: '', loadChildren:  () => SettingsModule},
  {path: '', loadChildren:  () => StoreModule},
  // {path: "home", component: HomeComponent},
  // { path: '**', redirectTo: ''}
]
  
  @NgModule({
    declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      FooterComponent,
      MenuComponent
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      RouterModule.forRoot(routes),
      HttpClientModule,
      MintSoupAuthModule.forRoot(),
      BookingModule.forRoot(),
      CustomerModule.forRoot(),
      EmployeeModule.forRoot(),
      OrdersModule.forRoot(),
      SettingsModule.forRoot(),
      StoreModule.forRoot()
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
