import { TestBed } from '@angular/core/testing';

import { MSGuard } from './ms.guard';

describe('MSGuard', () => {
  let guard: MSGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(MSGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
