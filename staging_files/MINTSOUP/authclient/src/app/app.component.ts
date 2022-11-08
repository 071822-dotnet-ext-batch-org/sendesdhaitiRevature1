import { Component , OnInit} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'authclient';
  ngOnInit(): void {
    this.changeElementClass_by_ID_and_CLASSNAME("signup", "Hidden");
  }
  async changeElementClass_by_ID_and_CLASSNAME(element:string, elementclassName:string){
    let ele = document.getElementById(element);
    if(ele != null)
    {
      ele.className = elementclassName;
    }
  }

  async show_or_focus_login_and_hide_signup(){
    await this.changeElementClass_by_ID_and_CLASSNAME('signup', 'Hidding')
      .then(() => {
        this.changeElementClass_by_ID_and_CLASSNAME("signup", "Hidden");
      })
      .then(() =>{
        this.changeElementClass_by_ID_and_CLASSNAME("login","Shown");
      })
  }

  async show_or_focus_signup_and_hide_login(){
    await this.changeElementClass_by_ID_and_CLASSNAME('login', 'Hidding')
      .then(() => {
        this.changeElementClass_by_ID_and_CLASSNAME("login", "Hidden");
      })
      .then(() =>{
        this.changeElementClass_by_ID_and_CLASSNAME("signup","Shown");
      })
  }
}
