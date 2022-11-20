// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

// import {API} from "../../../../API.json";
// import Auth from "../../../../../MintSoupApp/API.json";
import { HttpClient } from '@angular/common/http';
import Auth from '../../../../API/API.json'
// export class API {
//   public static jsonStr:any
//   constructor(public http:HttpClient){
//     this.http.get('../../../../API.json').subscribe((res) => {
//       API.jsonStr = res;
//       console.log('--- result :: ',  API.jsonStr);
//     })
//   }

//   static getAPI(){
//     return API.jsonStr;
//   }
// }
// const API = JSON.parse(Auth)
export const environment = {
  production: false,
  API: {
    // Auth: API.getAPI()
    Auth: Auth.Auth
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
