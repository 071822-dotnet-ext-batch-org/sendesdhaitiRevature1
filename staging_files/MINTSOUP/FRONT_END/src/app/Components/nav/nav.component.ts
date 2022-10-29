import { STRING_TYPE } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-angular';
import { UserService } from 'src/app/Services/user.service';
import { NavigationBarService } from 'src/app/Services/navigation-bar.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  public user: User = {}

  static navSandwichToggle?: Boolean = false;

  constructor(public nav: NavigationBarService, public auth: AuthService, public userserve: UserService) { this.auth;this.user;}

   

  ngOnInit(): void {
  }

  showMenu():void{
    let element_for_menuToggle = document.getElementById('menu')
    let router_element_to_Move = document.getElementById('router')
    if((element_for_menuToggle != null) && (router_element_to_Move != null)){
      if(element_for_menuToggle.className != 'showMenu')
      {
        //toggle on
        element_for_menuToggle.className = 'showMenu'
        router_element_to_Move.className = 'moveRouter'
      }
      else
      {
        //toggle off
        element_for_menuToggle.className = 'hideMenu'
        router_element_to_Move.className = 'moveRouterBack'
      }
    }
  }

  showSearch():void{
    let element_for_menuToggle = document.getElementById('menu')
    let router_element_to_Move = document.getElementById('router')
    let element_for_searchToggle = document.getElementById('searchmenu')
    if((element_for_menuToggle != null) && (router_element_to_Move != null) && (element_for_searchToggle != null)){
      if(element_for_searchToggle.className != 'showSearch')
      {
        //toggle on
        element_for_menuToggle.className = 'hideMenu'
        router_element_to_Move.className = 'moveRouterBack'
        element_for_searchToggle.className = 'showSearch'
      }
    }
  }

}
