// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
import DATA_API from "../../MINTSOUP_JWT.json"
import AUTHENTICATION_and_AUTHORIZATION_API from "../../MINTSOUP_JWT.json"
// import APIS from "../../MINTSOUP_JWT.json"

export const environment = {
  production: false,
  API1: `${DATA_API}`,
  API2: `${AUTHENTICATION_and_AUTHORIZATION_API}`
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
