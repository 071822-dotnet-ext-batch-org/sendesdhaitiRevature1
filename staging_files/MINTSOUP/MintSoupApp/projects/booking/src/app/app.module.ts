import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Router, RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookingComponent } from './booking/booking.component';

const routes: Routes = [
  {path: "mint/booking", component: BookingComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    BookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


@NgModule({})
export class BookingModule{
  static forRoot():
  ModuleWithProviders<BookingModule>{
    return {
      ngModule: AppModule,
      providers: [],
    }
  }
}