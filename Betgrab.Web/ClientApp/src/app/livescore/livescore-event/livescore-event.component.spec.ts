import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivescoreItemComponent } from './livescore-event.component';

describe('LivescoreItemComponent', () => {
  let component: LivescoreItemComponent;
  let fixture: ComponentFixture<LivescoreItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivescoreItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LivescoreItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
