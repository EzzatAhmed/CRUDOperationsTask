import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddemployeeComponentComponent } from './addemployee-component.component';

describe('AddemployeeComponentComponent', () => {
  let component: AddemployeeComponentComponent;
  let fixture: ComponentFixture<AddemployeeComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddemployeeComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddemployeeComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
