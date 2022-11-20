import { Component, OnInit } from '@angular/core';
import { MSAuthenticationService } from '../../Service/msauthentication.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private msservice:MSAuthenticationService) { }
  public amIsignedIn?:boolean
  ngOnInit(): void {
    this.amIsignedIn = this.msservice.isAuthenticated()
  }

  logout():void{
    this.msservice.logout()
  }



}
