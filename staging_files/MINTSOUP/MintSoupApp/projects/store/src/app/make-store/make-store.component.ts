import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StoreService } from '../Services/store.service';
import { Address } from '../store/store.component';
@Component({
  selector: 'app-make-store',
  templateUrl: './make-store.component.html',
  styleUrls: ['./make-store.component.css']
})
export class MakeStoreComponent implements OnInit {
  public have_address?:boolean
  // public keep_private?:boolean
  public make_store_form:FormGroup
  public address_form:FormGroup
  constructor(private form:FormBuilder, private store:StoreService, private router:Router) { 

    this.make_store_form = this.form.group({
      storename: [null, Validators.required],
      image: [null, Validators.required],// Validators.pattern('.jpeg'), Validators.pattern('.png')],
      privacy_level: [false, Validators.required],
      address_check: [false, Validators.required]
    });

    this.address_form = this.form.group({
      street: [null,Validators.required],
      city: [null, Validators.required],
      state: [null , Validators.required],
      country: [null, Validators.required],
      areacode: [null, Validators.required]
    });

  }
  ngOnInit(): void {
    this.hide_and_show_address_form()
  }
  ngOnDestroy():void{
    this.store.create_store()
      .subscribe().unsubscribe()
  }

  create_store():void{
    let store_form = this.make_store_form.value
    let addy_form = this.address_form.value
    let adr: Address = {
      street: addy_form.street,
      city:addy_form.city,
      state:addy_form.state,
      country:addy_form.country,
      areacode:addy_form.areacode
    }
    if(store_form.storename  && 
      store_form.image &&
      (store_form.address_check == true))
      {
        if(addy_form.street   &&
          addy_form.city  &&
          addy_form.state  &&
          addy_form.country  &&
          addy_form.areacode )
          {
            const saved = this.store.create_store(store_form.storename, store_form.image,store_form.privacy_level, adr )
            saved.subscribe(saved => {
              console.log(`your store has been saved as ${saved}`)
              this.router.navigate(["mint/store "]);
            },
            err => {
              console.log(`an error occured as ${err}`)
            })
          }
          else{
            console.log("address must be filled out \n", `${JSON.stringify(store_form.status)} for ${JSON.stringify(store_form)} \n`, `${JSON.stringify(addy_form.status)} for ${JSON.stringify(addy_form)}`)
          }
      }
      else if(store_form.storename   && 
        store_form.image  &&
        (store_form.address_check == false))
        {
          const saved = this.store.create_store(store_form.storename, store_form.image,store_form.privacy_level, adr )
          saved.subscribe(saved => {
            console.log(`your store has been saved as ${saved}`)
            this.router.navigate(["mint/store"]);
          },
          err => {
            console.log(`an error occured as ${err}`)
          })
          this.router.navigate(["stores"]);
        }
      else{
        console.log("form not filled out \n", `${JSON.stringify(store_form.status)} for ${JSON.stringify(store_form)} \n`, `${JSON.stringify(addy_form.status)} for ${JSON.stringify(addy_form)}`)
      }
  }

  hide_and_show_address_form()
  {
    let val = this.make_store_form.value
    if(val.address_check == false){
      console.log("hiding")
      hide_and_clear_element(this.address_form, "address_form")
    }
    else{
      console.log("showing")
      show_element(this.address_form, "address_form")
    }
  }



}
export async function changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
  let ele = document.getElementById(element);
  if(ele != null)
  {
    ele.className = elementclassName;
  }
}//END OF CHANGE ELEMENT BY CLASS

export async function hide_and_clear_element(form:FormGroup,id_of_element_to_hide:string){
  // let val = form.value
  form.reset();
  changeElementClass_by_ID_and_CLASSNAME(id_of_element_to_hide, 'Hiding')
  .then(() =>
  {
    changeElementClass_by_ID_and_CLASSNAME(id_of_element_to_hide, 'Hidden')
  })
}//END OF HIDE AND CLEAR ELEMENT

export async function show_element(form:FormGroup,id_of_element_to_show:string){
  // let val = form.value
  form.reset();
  changeElementClass_by_ID_and_CLASSNAME(id_of_element_to_show, 'Shown')
  // .then(() =>
  // {
  //   changeElementClass_by_ID_and_CLASSNAME(id_of_element_to_show, 'Show')
  // })
}//END OF HIDE AND CLEAR ELEMENT