import { Component, OnInit } from '@angular/core';
import { AuthSoupToken } from 'src/app/Services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private soup:AuthSoupToken) { }
  
  isAuthenticated?: boolean 
  ngOnInit(): void {
    this.soup.isAuthenticated().then(check => {
      this.isAuthenticated = check
    })
  }

  logout()
  {
    this.soup.logout()
    .then(action_ => {
      //redirect to home page
      console.log(`a user has logged out at ${Date.now()}`)

    })
  }

}
