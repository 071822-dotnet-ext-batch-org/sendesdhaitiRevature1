import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { Viewer } from 'src/app/Models/UserModels';
import { AuthService } from '@auth0/auth0-angular';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public _userService: UserService, public auth: AuthService) { 
    this._userService;
    this.auth;
  }

  public myData: any;

  public myViewer: Viewer = {
    ID : "my123ID",
    Auth0ID : "myID",
    Fn : "john",
    Ln : "doe",
    Email : "example@email.com",
    Image : "string",
    Username : "myUsername",
    AboutMe : "aboutme",
    StreetAddy : "string",
    City : "string",
    State : "string",
    Country : "string",
    AreaCode : "string",
    Role : 0,
    MembershipStatus : 0,
    DateSignedUp : new Date(),
    LastSignedIn : new Date()
  };


  ngOnInit(): void {
    this.hideElements()
    this.getUserAccount_if_haveone()
    this.auth.user$.subscribe(data => {
      this.myData = JSON.stringify(data, null ,2) ;
      if(this.myData == null){
        this.auth.getAccessTokenSilently({}).subscribe(data =>
          {
            this.myData = data
            console.log(`getAccessTokenSilently - ${this.myData}`)
          })
      }
      console.log(this.myData)
    })

  }
  // setCurrentUser(input:any): void{
  //   this._userService.SET_userFromAuth0_IN_UserSERVE(input)
  //   console.log(`passed in data is '${input.email}' while '${this.userData?.email}' is going to be the user`)
  // }


  getUserAccount_if_haveone(): void
  {
    this._userService.getAuthAfterLogin().subscribe(data => {
      this.myData = data;
      console.log(`getUserAccount_if_haveone - ${this.myData}`)

    })
    // this.auth.user$.subscribe(data => {
    //   return this.myData = data;

    // })

    if(this.myData != null){}
    else
    {
      this.myData = {
        "sub" : "nullAuth",
        "email" : "nullEmail",
        "username" : "null Username"
      }
    }
    
  }//END of getUserAccount_if_haveone
  

  showMyShows()
  {
    let id = document.getElementById("myshows")
    let btn = document.getElementById("myshowbtn")
    if((id !== null) && (btn !== null))
    {
      if(id.style.display == "none")
      {
        id.style.display = "block"
        btn.innerText = "Hide my shows"
      }
      else
      {
        id.style.display = "none"
        btn.innerText = "Show my shows"
      }

    }
  }

  showMyShowSubs()
  {
    let id = document.getElementById("myshowsubs")
    let btn = document.getElementById("myshowsubbtn")
    if((id !== null) && (btn !== null))
    {
      if(id.style.display == "none")
      {
        id.style.display = "block"
        btn.innerText = "Hide my subscriptions"
      }
      else
      {
        id.style.display = "none"
        btn.innerText = "Show my subscriptions"
      }

    }
  }
  
  showMyFollowers()
  {
    let id = document.getElementById("myfollowers")
    let btn = document.getElementById("myfollowersbtn")
    if((id !== null) && (btn !== null))
    {
      if(id.style.display == "none")
      {
        id.style.display = "block"
        btn.innerText = "Hide my followers"
      }
      else
      {
        id.style.display = "none"
        btn.innerText = "Show my followers"
      }

    }
  }

  showMyFriends()
  {
    let id = document.getElementById("myfriends")
    let btn = document.getElementById("myfriendsbtn")
    if((id !== null) && (btn !== null))
    {
      if(id.style.display == "none")
      {
        id.style.display = "block"
        btn.innerText = "Hide my friends"
      }
      else
      {
        id.style.display = "none"
        btn.innerText = "Show my friends"
      }

    }
  }
  
  hideElements()
  {
    let id = document.getElementById("myshows")
    let id2 = document.getElementById("myfriends")
    let id3 = document.getElementById("myfollowers")
    let id4 = document.getElementById("myshowsubs")
    if((id !== null) && (id2 !== null) && (id3 !== null) && (id4 !== null))
    {
      id.style.display = "none"
      id2.style.display = "none"
      id3.style.display = "none"
      id4.style.display = "none"
    }
  }

}
