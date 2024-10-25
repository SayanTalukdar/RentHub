import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllApartmentComponent } from './all-apartment.component';

describe('AllApartmentComponent', () => {
  let component: AllApartmentComponent;
  let fixture: ComponentFixture<AllApartmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllApartmentComponent]
    });
    fixture = TestBed.createComponent(AllApartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
