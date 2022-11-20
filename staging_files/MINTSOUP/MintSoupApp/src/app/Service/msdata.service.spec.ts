import { HttpClient, HttpClientModule, HttpHeaders, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MintSoupAuthModule } from 'projects/authentication/src/app/app.module';
import { environment as env } from 'src/environments/environment';
import { AppComponent } from '../app.component';
import { FooterComponent } from '../Components/footer/footer.component';
import { NavComponent } from '../Components/nav/nav.component';
// import { httpServiceProvider, HTTP_PROVIDER } from './app.config';
import { MSDataService } from './msdata.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('MSDataService', () => {
  let service: MSDataService;
  // let fixture = 
  beforeEach(async () => {
      await TestBed.configureTestingModule({
      imports: [
        // HttpClientTestingModule
        HttpClientModule,
        // MintSoupAuthModule
        // HttpClient, HttpHeaders
      ],
      providers:[
        // HttpClientModule
        // HttpClient, HttpHeaders
        //  HttpHeaders,
        // ,
        // MSDataService
      ]

    });
    service =  TestBed.inject(MSDataService);
    // fixture = service.
  });
  

  it('service should be created', () => {
    expect(service).toBeTruthy();
  });

  it('gettoken function should be created', () => {
    expect(service.getToken).toBeTruthy();
  });

  it('should be created', () => {
    expect(service.getViewer).toBeTruthy();
  });

  it('should be created', () => {
    expect(service.sendRequest_to_GET_Viewer).toBeTruthy();
  });

  it('should be created', () => {
    expect(service.setViewer).toBeTruthy();
  });
});

