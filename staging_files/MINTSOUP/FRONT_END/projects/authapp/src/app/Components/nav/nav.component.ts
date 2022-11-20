import { Component, OnInit } from '@angular/core';
import { AuthSoupToken } from '../../Services/user.service';
import { UserService } from 'src/app/Services/user.service';
import { User } from '@auth0/auth0-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private soup:AuthSoupToken, private userservice:UserService, public http:HttpClient ) { }
  
  isAuthenticated?: boolean 
  ngOnInit(): void {
    this.soup.isAuthenticated().then(check => {
      this.isAuthenticated = check
    })
  }

  logout()
  {
    this.soup.logout()
    .then(no_return_data =>
      //redirect to home page
      {
        console.log(`a user has logged out at ${Date.now()}`)
      }

    )
  }

}
