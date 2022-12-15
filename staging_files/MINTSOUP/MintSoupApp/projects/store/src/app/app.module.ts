import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { GeolocationService } from '@ng-web-apis/geolocation';
// import { NgxGooglemapsTrackingViewModule } from 'ngx-googlemaps-tracking-view';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreComponent } from './store/store.component';

const routes: Routes = [
  {path: "mint/store", component: StoreComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [GeolocationService],
  bootstrap: [AppComponent]
})
export class AppModule { }

@NgModule({})
export class StoreModule{
  static forRoot():
  ModuleWithProviders<StoreModule>{
    return {
      ngModule: AppModule,
      providers: [],
    }
  }
}