import { DatePipe, DATE_PIPE_DEFAULT_TIMEZONE } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {GeolocationService} from '@ng-web-apis/geolocation';
import { StoreService } from '../Services/store.service';
// import {MatButtonModule} from '@angular/material/button';
// import { TrackedObject } from 'ngx-googlemaps-tracking-view';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

  private location?:GeolocationPosition
  private location2:any
  constructor(private store:StoreService, private geo:GeolocationService) {}

  ngOnInit(): void {
    this.get_locations()
  }
  
  private get_locations():void{
    this.store.get_location().subscribe(l => {
        this.location = l
        console.log(this.location)
      })
    this.store.get_api_location().subscribe(location => {
        this.location2 = location;
        console.log( "Store accessed at" + " " + this.location2.city + ", " + this.location2.region + ", " + this.location2.country_code_iso3 + " " + `at ${new Date()}`)
      })
  }



}

export interface Store{

}