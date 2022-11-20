import { HttpClient, HttpHandler, HttpXhrBackend } from "@angular/common/http";
import { Inject, InjectionToken } from "@angular/core";

// export function httpServiceProvider():HttpClient
// {
//     const httpClient = new HttpClient(new HttpXhrBackend({ 
//         build: () => new XMLHttpRequest() 
//     }));
//     // let c: HttpClient = new HttpClient()
//   return httpClient;
// }
// export const HTTP_PROVIDER = new InjectionToken<HttpClient>(`HTTP_PROVIDER`)
// export const HTTP_PROVIDER = new InjectionToken<HttpClient>(`httpProvider`)