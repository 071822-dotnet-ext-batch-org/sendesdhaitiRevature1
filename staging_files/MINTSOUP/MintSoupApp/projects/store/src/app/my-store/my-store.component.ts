import { Component, OnInit, OnDestroy } from '@angular/core';
import { StoreService } from '../Services/store.service';
import { Store } from '../store/store.component';

@Component({
  selector: 'app-my-store',
  templateUrl: './my-store.component.html',
  styleUrls: ['./my-store.component.css']
})
export class MyStoreComponent implements OnInit, OnDestroy {

  private mystore?:Store
  constructor(private store:StoreService) { }

  ngOnInit(): void {
  }
  ngOnDestroy():void{
    this.store.get_my_store()
      .subscribe()
      .unsubscribe()
  }

  get_my_store():void
  {
    const mystore = this.store.get_my_store()
    mystore.subscribe(store =>
      {
        this.mystore = store
      })
  }

}
