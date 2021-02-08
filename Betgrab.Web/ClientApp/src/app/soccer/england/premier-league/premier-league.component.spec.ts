import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PremierLeagueComponent } from './premier-league.component';

describe('PremierLeagueComponent', () => {
  let component: PremierLeagueComponent;
  let fixture: ComponentFixture<PremierLeagueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PremierLeagueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PremierLeagueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
