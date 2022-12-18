import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  {path: "mint/orders", component: OrdersComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent
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
export class OrdersModule{
  static forRoot():
  ModuleWithProviders<OrdersModule>{
    return {
      ngModule: AppModule,
      providers: [],
    }
  }
}