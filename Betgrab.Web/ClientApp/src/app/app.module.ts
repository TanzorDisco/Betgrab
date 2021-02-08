import { CommonModule, DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PremierLeagueComponent } from './soccer/england/premier-league/premier-league.component';
import { LaligaSantanderComponent } from './soccer/spain/laliga-santander/laliga-santander.component';
import { EventViewComponent } from './soccer/event-view/event-view.component';
import { LivescoreComponent } from './livescore/livescore.component';
import { SignalrService } from './signalr.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PremierLeagueComponent,
    LaligaSantanderComponent,
    EventViewComponent,
    LivescoreComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'event/:id', component: EventViewComponent },
      { path: 'livescore', component: LivescoreComponent },
      { path: 'england/premier-league', component: PremierLeagueComponent },
      { path: 'spain/laliga-santander', component: LaligaSantanderComponent },
    ]),
  ],
  providers: [SignalrService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
