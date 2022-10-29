import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavigationBarService {
  public static navToggle: string = ""
  constructor() { }
  
  public toggleElement(elementID: string, elementCLASSNAME_ON: string, elementCLASSNAME_OFF: string): string{

    let toggleCreds : object = {
      "elementID" : elementID, 
      "elementCLASSNAME_ON" : elementCLASSNAME_ON, 
      "elementCLASSNAME_OFF": elementCLASSNAME_OFF 
    }
    return NavigationBarService.navToggle = JSON.stringify(toggleCreds);
  }
}
