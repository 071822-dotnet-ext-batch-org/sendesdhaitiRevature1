import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { LogoutComponent } from './Components/logout/logout.component';
import { ShowsComponent } from './Components/shows/shows.component';
import { AccountComponent } from './Components/account/account.component';
import { AuthGuard } from '@auth0/auth0-angular';



const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'account', component: AccountComponent , canActivate: [AuthGuard]},
  { path: 'shows', component: ShowsComponent , canActivate: [AuthGuard]},
];

@NgModule({
  imports: [
    //This allows for the screen to start at the top on ruote change
    RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
