import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product, Store } from '../store/store.component';
import 'rxjs/add/operator/filter';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.css']
})
export class StoreDetailComponent implements OnInit {

  private storeid?:string
  constructor(private route:ActivatedRoute) { }

  ngOnInit(): void {
    // this.route.queryParams
    //   .filter(params => params.order)
    //   .subscribe(params => {
    //     console.log(params); // { order: "popular" }

    //     this.storeid = params.order;

    //     console.log(this.storeid); // popular
    //   }
    // );
  }

}
