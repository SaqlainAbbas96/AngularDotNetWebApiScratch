import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditExpComponent } from './add-edit-exp.component';

describe('AddEditExpComponent', () => {
  let component: AddEditExpComponent;
  let fixture: ComponentFixture<AddEditExpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditExpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditExpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
