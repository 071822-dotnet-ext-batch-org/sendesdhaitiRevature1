import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeStoreComponent } from './make-store.component';

describe('MakeStoreComponent', () => {
  let component: MakeStoreComponent;
  let fixture: ComponentFixture<MakeStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MakeStoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MakeStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
