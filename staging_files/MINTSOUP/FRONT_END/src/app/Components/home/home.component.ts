import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.hideElements()
  }

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
