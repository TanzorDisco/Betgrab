import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivescoreIndexComponent } from './livescore-index.component';

describe('LivescoreComponent', () => {
  let component: LivescoreIndexComponent;
  let fixture: ComponentFixture<LivescoreIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivescoreIndexComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LivescoreIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
