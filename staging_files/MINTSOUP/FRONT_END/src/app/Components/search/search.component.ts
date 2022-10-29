import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  hideSearch():void{
    let element_for_searchToggle = document.getElementById('searchmenu')
    if(element_for_searchToggle != null){
      if(element_for_searchToggle.className == 'showSearch')
      {
        //toggle on
        element_for_searchToggle.className = 'hideSearch'
      }
    }
  }


}
