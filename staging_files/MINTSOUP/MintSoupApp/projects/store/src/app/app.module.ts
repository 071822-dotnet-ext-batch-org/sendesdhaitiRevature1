import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { GeolocationService } from '@ng-web-apis/geolocation';
// import { NgxGooglemapsTrackingViewModule } from 'ngx-googlemaps-tracking-view';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreComponent } from './store/store.component';
import { MakeStoreComponent } from './make-store/make-store.component';
import { MyStoreComponent } from './my-store/my-store.component';
import { MakeProductComponent } from './make-product/make-product.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { StoreDetailComponent } from './store-detail/store-detail.component';

const routes: Routes = [
  {path: "mint/stores", component: StoreComponent},
  {path: "mint/store/new", component: MakeStoreComponent},
  {path: "mint/store/", component: StoreDetailComponent},
  {path: "mint/store/my", component: MyStoreComponent},
  {path: "mint/store/product/new", component: MakeProductComponent},
  {path: "mint/store/product/", component: ProductDetailComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    StoreComponent,
    MakeStoreComponent,
    MyStoreComponent,
    MakeProductComponent,
    ProductDetailComponent,
    StoreDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    ReactiveFormsModule
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