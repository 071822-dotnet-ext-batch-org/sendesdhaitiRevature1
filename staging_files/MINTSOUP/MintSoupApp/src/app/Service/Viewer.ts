import { Inject, Injectable, Input } from "@angular/core";
// "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
// "msToken": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
// "fn": "string",
// "ln": "string",
// "email": "string",
// "image": "string",
// "username": "string",
// "aboutMe": "string",
// "streetAddy": "string",
// "city": "string",
// "state": "string",
// "country": "string",
// "areaCode": 0,
// "role": 0,
// "membershipStatus": 0,
// "dateSignedUp": "2022-11-24T22:47:02.828Z",
// "lastSignedIn": "2022-11-24T22:47:02.828Z"
export interface IViewer{
        id?:any,
        msToken?:any,
        fn?:string,
        ln?:string,
        email?:string,
        image?:string,
        username?:string,
        aboutMe?:string,
        streetAddy?:string,
        city?:string,
        state?:string,
        country?:string,
        areaCode?:number,

        role?:number,
        membershipStatus?:number,

        dateSignedUp?:Date,
        lastSignedIn?:Date
}
// interface IViewerConstructor {
//   new (...deps: any[]): IViewer;
// }

export class Viewer implements IViewer
{
  private loadedViewer?:IViewer;
  id?: any;
  msToken?:any;
  fn?:string;
  ln?:string;
  email?:string;
  image?:string;
  username?:string;
  aboutMe?:string;
  streetAddy?:string;
  city?:string;
  state?:string;
  country?:string;
  areaCode?:number;

  role?:number;
  membershipStatus?:number;

  dateSignedUp?:Date;
  lastSignedIn?:Date;
  // public myViewer:IViewer = {};
  constructor(  public iviewer:IViewer){
    console.log(`the viewer is created with ${iviewer?.id}`)
    this.setViewer(iviewer)
  }

  public CHECK_IF_IhaveAViewer()
  {
    let check = this.getViewer()
    if(check)
    {
      return true;
    }
    else{
      return false;
    }
  }

  private setViewer(viewer:IViewer):void
  {
    this.loadedViewer = {
      id :this.id,
      msToken: this.msToken,
      fn: this.fn,
      ln: this.ln,
      image: this.image,
      username: this.username,
      email: this.email,
      aboutMe: this.aboutMe,
      streetAddy: this.streetAddy,
      city: this.city,
      state: this.state ,
      country: this.country,
      areaCode: this.areaCode,
      role: this.role,
      membershipStatus: this.membershipStatus ,
      dateSignedUp: this.dateSignedUp ,
      lastSignedIn: this.lastSignedIn ,
    };
    this.id = viewer.id;
    this.msToken = viewer.msToken;
    this.fn = viewer.fn;
    this.ln = viewer.ln;
    this.image = viewer.image;
    this.username = viewer.username;
    this.email = viewer.email;
    this.aboutMe = viewer.aboutMe;
    this.streetAddy = viewer.streetAddy;
    this.city = viewer.city;
    this.state = viewer.state;
    this.country = viewer.country;
    this.areaCode = viewer.areaCode;
    this.role = viewer.role;
    this.membershipStatus = viewer.membershipStatus;
    this.dateSignedUp = viewer.dateSignedUp;
    this.lastSignedIn = viewer.lastSignedIn;
  }

  public getViewer()
  {
    return this.loadedViewer;
  }

}