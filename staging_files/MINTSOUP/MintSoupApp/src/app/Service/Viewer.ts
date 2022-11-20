import { Inject, Injectable } from "@angular/core";

export interface IViewer{
        ID?:any,
        MSToken?:any,
        FirstName?:string,
        LastName?:string,
        Email?:string,
        Image?:string,
        Username?:string,
        AboutMe?:string,
        StreetAddress?:string,
        City?:string,
        State?:string,
        Country?:string,
        AreaCode?:number,

        Role?:number,
        MembershipStatus?:number,

        DateSignedUp?:Date,
        LastSignedIn?:Date
}



export class Viewer
{
  myViewer?:IViewer = {};
  constructor(public myviewer?:IViewer){
    this.setViewer(myviewer)
  }

  public CHECK_IF_IhaveAViewer()
  {
    let check = this.getViewer()
    if(check)
    {
      return true;
    }
    return false;
  }

  public setViewer(viewer?:IViewer):void
  {
    this.myViewer = viewer;
  }
  public getViewer()
  {
    return this.myViewer;
  }

}