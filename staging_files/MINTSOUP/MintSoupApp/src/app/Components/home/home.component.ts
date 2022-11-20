import { HttpClient } from '@angular/common/http';
import { Component, Inject, InjectionToken, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { TimeInterval } from 'rxjs/internal/operators/timeInterval';
import { MSDataService } from 'src/app/Service/msdata.service';
import { IViewer, Viewer } from 'src/app/Service/Viewer';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [
    // {provide: VIEWER_PROVIDER, useFactory: viewerServiceProvider, deps: [MSDataService]},
    // {provide: HTTP_PROVIDER, useFactory: httpServiceProvider, deps: [HttpClient]}
  ]
})
export class HomeComponent implements OnInit {

    is_token_here?:boolean
    public myViewer?:Viewer = new Viewer()
    constructor(private msservice:MSDataService){
      this.msservice.getToken()
    }
    
  ngOnInit(): void {
    let check = this.msservice.Does__Component__Have__Token()
    if(check == true)
    {
      this.is_token_here = true;
      
    }
    else{
      this.is_token_here = false;
    }
    // this.msservi  ce.
  }
  setViewer(requestReturn:IViewer):void{
    this.myViewer = new Viewer(requestReturn)
  }
  getViewer():Viewer|undefined{
    return this.myViewer;
  }

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
  }
  send_request_for_viewer():void{
    // console.log(`At ${Date.now()} - headers added as to the request as '' - true means it exists`)
    if(this.is_token_here == true)
    {

      // let viewer = this.http.get<IViewer>(this.API + "my-viewer/", {headers:this.mstoken.sid})
      let viewer = this.msservice.sendRequest_to_GET_Viewer()
      if(viewer)
      {
        viewer.subscribe(
          {
            next: (ret:IViewer) => {
              this.setViewer(ret)
            },
            error: (err) => {
              console.log(`At ${Date.now()} - the viewer was not gotten successfully with ${err}`)
            },
            complete: () =>
            {
              console.log(`At ${Date.now()} - the viewer request completed`)
            }
          }
        )//End of subscribe

        
      }
    }
  }

}
