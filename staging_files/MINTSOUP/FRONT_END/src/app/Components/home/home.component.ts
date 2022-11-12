import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { Viewer } from 'src/app/Models/UserModels';
import { AuthService } from '@auth0/auth0-angular';
import { NavigationBarService } from 'src/app/Services/navigation-bar.service';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public _userService: UserService, public auth: AuthService, public nav: NavigationBarService) { 
    this._userService;
    this.auth;
    this.nav;
  }

  public myData: any;
  public element = document.getElementById('menu')
  public myViewer?: Viewer = {};
  isAuthenticated$ = this.auth.isAuthenticated$
  user$ = this.auth.user$

  // @Input() navSandwichToggle?: Boolean = undefined;



  ngOnInit(): void {

    this.hideElements()

    if(this.isAuthenticated$){
      this.user$.subscribe(data => {
  
        this.myData = data;
        console.log(`This data email is ${this.myData?.email}`)
        if(data != null)
        {
          // this._userService.GET_or_Create_myViewer(data.sub, data.email).subscribe(viewer => {
          //   this.myViewer = viewer;
          //   console.log(`This viewer is ${this.myViewer.Email}`)
          // })
        }
        // console.log(this.myData)
      })

    }
  }//END NG ON INIT


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
