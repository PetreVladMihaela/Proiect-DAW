import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditLandmarkComponent } from './add-edit-landmark.component';

describe('AddEditLandmarkComponent', () => {
  let component: AddEditLandmarkComponent;
  let fixture: ComponentFixture<AddEditLandmarkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditLandmarkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditLandmarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
