import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authentication-page',
  templateUrl: './authentication-page.component.html',
  styleUrls: ['./authentication-page.component.css']
})
export class AuthenticationPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  hidetab()
  {
    console.log('running')
    let id1 = document.getElementById('auth-component1')?.style.display
    let id2 = document.getElementById('auth-compnent2')?.style.display
    if(id1 == 'none')
    {
      console.log('it works1')
      id1 = `block`
      id2 = `none`
    }
    else
    {//id1 is already showing
      console.log('it works2')
      id2 = `block`
      id1 = `none`
    }
    // id1?.toUpperCase();// = '<p>hello</p>';
    // id1 = 'none'
    // id2 = 'flex'
  }
  // hidetab2()
  // {

  // }


}
