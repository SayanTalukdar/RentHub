import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewApartmentComponent } from './new-apartment.component';

describe('NewApartmentComponent', () => {
  let component: NewApartmentComponent;
  let fixture: ComponentFixture<NewApartmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewApartmentComponent]
    });
    fixture = TestBed.createComponent(NewApartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
