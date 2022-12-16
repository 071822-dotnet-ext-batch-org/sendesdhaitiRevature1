import { DatePipe, DATE_PIPE_DEFAULT_TIMEZONE } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {GeolocationService} from '@ng-web-apis/geolocation';
import { StoreService } from '../Services/store.service';
import { Observer } from 'rxjs';
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
  private mstoken:any
  public are__there__any__stores__present:boolean = false
  public do__you__have__your__token:boolean = false
  public stores: Store[] = [];
  private obj:Partial<Observer<Store[]>> = {}
  constructor(private store:StoreService, private geo:GeolocationService) {}
  
  ngOnInit(): void {
    this.get_locations()

    const token = this.store.get_token()
    if(token)
    {
      token.subscribe((ret) => {
        console.log(ret);
        this.do__you__have__your__token = ret;
      });

      if(this.do__you__have__your__token)
      {
        const all_stores = this.store.get_all_stores().subscribe(stores_list => {
          this.stores = stores_list;
          this.are__there__any__stores__present = true;
          let count:number = 0
          for(let store of stores_list)
          {
            count++;
            console.log(store.storename, ` has been counted - stores counted so far ${count}`)
          }
          })
        if(this.are__there__any__stores__present && all_stores)
        {
          // all_stores.unsubscribe();
          
        }
      }
    }
    
    // this.store.get_all_stores().subscribe({
    //   next: stores_list => 
    //   {
    //     let count:number = 0
    //     for(let store of stores_list)
    //     {
    //       count++;
    //       console.log(store.storename, ` has been counted - stores counted so far ${count}`)
    //     }
    //   },
    //   error(err)
    //   {
    //     console.log(`The store were not gotten due to ${err}`)
    //   },
    //   complete: () => {
    //     console.log(`You finished getting the stores`)
    //   }
    // })
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
  storeID:string,
  fk_personID: string,
  storename: string,
  storeimage: string,
  clients: number,
  views: number,
  likes: number,
  comments:number,
  rating: number,
  rank: number,
  privacylevel: number,
  storestatus: number,
  added: Date,
  updated: Date
}
