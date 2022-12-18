import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SettingsComponent } from './settings/settings.component';

const routes: Routes = [
  {path: "mint/settings", component: SettingsComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    SettingsComponent
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
export class SettingsModule{
  static forRoot():
  ModuleWithProviders<SettingsModule>{
    return {
      ngModule: AppModule,
      providers: [],
    }
  }
}