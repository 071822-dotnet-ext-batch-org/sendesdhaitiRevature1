import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authentication-page',
  templateUrl: './authentication-page.component.html',
  styleUrls: ['./authentication-page.component.css']
})
export class AuthenticationPageComponent implements OnInit {
  
  constructor() { }

  ngOnInit(): void {
    this.hideRegister()
  }

  hideRegister() :void
  {
    console.log('login hidden')
    let id1 = document.getElementById("login");
    let id2 = document.getElementById("signup");

    if((id1 === null) || (id2 === null))
    {
      console.log('login is null')
    }
    else {
      if(id1.style.display == "block")
      {
        id1.style.display = "block"
        id2.style.display = "none"
      }
      else{
        id1.style.display = "block"
        id2.style.display = "none"
      }
    }
  }//END of hideRegister


  hideLogin() :void
  {
    console.log('login hidden')
    let id1 = document.getElementById("login");
    let id2 = document.getElementById("signup");

    if((id1 === null) || (id2 === null))
    {
      console.log('login is null')
    }
    else {
      if(id1.style.display == "block")
      {
        id1.style.display = "none"
        id2.style.display = "block"
      }
      else{
        id1.style.display = "none"
        id2.style.display = "block"
      }
    }
  }//END of hideRegister




}
