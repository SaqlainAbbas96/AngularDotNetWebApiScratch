import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowExpComponent } from './show-exp.component';

describe('ShowExpComponent', () => {
  let component: ShowExpComponent;
  let fixture: ComponentFixture<ShowExpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowExpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowExpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
