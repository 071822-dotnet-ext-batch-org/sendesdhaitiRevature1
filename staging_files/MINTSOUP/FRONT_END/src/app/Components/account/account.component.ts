import { Component, OnInit } from '@angular/core';
import { Viewer } from 'src/app/Models/UserModels';
import { AuthService } from '@auth0/auth0-angular';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  private myData: any
  public myViewer?: Viewer = {}
  constructor(public auth: AuthService, public userservice: UserService ) { 
    this.auth;
    this.userservice;
  }

  ngOnInit(): void {
    this.auth.user$.subscribe(data => {
      this.myData = data
    })
    this.getmyViewerAccount()
  }

  getmyViewerAccount()
  {
    // this.userservice.GET_or_Create_myViewer(this.myData.sub, this.myData.email).subscribe((viewer :Viewer) => {
    //   this.myViewer = viewer;
    // })
  }

}
