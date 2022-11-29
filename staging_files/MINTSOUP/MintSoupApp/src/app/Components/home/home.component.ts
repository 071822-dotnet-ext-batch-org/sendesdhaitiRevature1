import { HttpClient } from '@angular/common/http';
import { Component, Inject, InjectionToken, Input, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { TimeInterval } from 'rxjs/internal/operators/timeInterval';
import { MSDataService } from 'src/app/Service/msdata.service';
import { IShow } from 'src/app/Service/Show';
import { IViewer, Viewer } from 'src/app/Service/Viewer';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: []
})
export class HomeComponent implements OnInit {

  is_token_here?:boolean
  public myViewer?:Viewer;
  public shows: IShow[] = []

  constructor(private msservice:MSDataService){
    this.msservice.getToken()
  }
    
  ngOnInit(): void {
    let check = this.msservice.Does__Component__Have__Token()
    if(check == true)
    {
      this.is_token_here = true;
      this.send_request_for_viewer()
    }
    else{
      this.is_token_here = false;
    }
  }//END NG ON INIT


  setViewer(requestReturn:IViewer):void{
    let viewer = new Viewer(requestReturn);
    this.myViewer = viewer;
  }//END SET VIEWER


  getViewer():IViewer | undefined{
    return this.myViewer?.getViewer();
  }//END GET VIEWER


  public if__Viewer__is__Populated():boolean
  {
    let check = this.is_token_here
    if(check == true)
    {
      return true;
    }
    else
    {
      return false;
    }
  }//END CHECK IF VIEWER IS HERE


  send_request_for_viewer():void{
    // console.log(`At ${Date.now()} - headers added as to the request as '' - true means it exists`)
    if(this.is_token_here == true)
    {
      let viewer = this.msservice.sendRequest_to_GET_Viewer()
      if(viewer)
      {
        viewer.subscribe(
          {
            next: (ret:IViewer) => {
              let c:IViewer = ret
              this.setViewer(ret);
              console.log(`At ${Date.now()} - the viewer was gotten successfully with ${ret.id}`);
            },
            error: (err) => {
              console.log(`At ${Date.now()} - the viewer was not gotten with ${err}`)
            },
            complete: () =>
            {
              console.log(`At ${Date.now()} - the viewer request completed`)
            }
          }
        )//End of subscribe
      }
    }
  }//END OF VIEWER REQUEST TO API

}
