import { TestBed } from '@angular/core/testing';

import { MainMSGuardGuard } from './main-msguard.guard';

describe('MainMSGuardGuard', () => {
  let guard: MainMSGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(MainMSGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
