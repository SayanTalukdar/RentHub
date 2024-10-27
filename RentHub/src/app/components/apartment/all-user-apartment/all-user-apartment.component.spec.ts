import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllUserApartmentComponent } from './all-user-apartment.component';

describe('AllUserApartmentComponent', () => {
  let component: AllUserApartmentComponent;
  let fixture: ComponentFixture<AllUserApartmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllUserApartmentComponent]
    });
    fixture = TestBed.createComponent(AllUserApartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
