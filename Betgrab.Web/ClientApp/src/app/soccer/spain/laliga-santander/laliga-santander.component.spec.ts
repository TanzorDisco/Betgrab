import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LaligaSantanderComponent } from './laliga-santander.component';

describe('LaligaSantanderComponent', () => {
  let component: LaligaSantanderComponent;
  let fixture: ComponentFixture<LaligaSantanderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LaligaSantanderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LaligaSantanderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
