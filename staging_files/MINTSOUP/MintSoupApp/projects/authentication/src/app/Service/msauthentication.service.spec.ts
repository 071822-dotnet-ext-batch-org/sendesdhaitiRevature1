import { TestBed } from '@angular/core/testing';

import { MSAuthenticationService } from './msauthentication.service';

describe('MSAuthenticationService', () => {
  let service: MSAuthenticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MSAuthenticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
