import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject, interval, Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpService } from '../../services/http.service';
import { SignalrService } from '../../signalr.service';
import { LivescoreOutput } from '../livescore.models';

@Component({
  selector: 'app-livescore',
  templateUrl: './livescore-index.component.html',
  styleUrls: ['./livescore-index.component.scss']
})
export class LivescoreIndexComponent implements OnInit, OnDestroy {

  parseDate: string;
  outputs: LivescoreOutput[] = [];
  subscriptions: Subscription[] = [];
  items: any[] = [];

  now$ = new BehaviorSubject<Date>(new Date());
  now = new Date();

  constructor(
    private http: HttpService,
    private datePipe: DatePipe,
    private signalr: SignalrService) {
  }

  ngOnInit(): void {
    this.parseDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');

    this.subscriptions.push(this.signalr.livescoreOutputCreated
      .pipe(
        tap(o => {
          this.addOutput(o.id);
        })
      )
      .subscribe()
    );

    this.subscriptions.push(this.signalr.livescoreEventMessage
      .pipe(
        tap(m => {
          let output = this.outputs.find(o => o.id === m.id);
  
          if (output) {
            output.messages.push(m.message);
            output.currentEvent = m.message;
          }
        })
      )
      .subscribe()
    );

    this.subscriptions.push(this.signalr.livescoreEventProgress
      .subscribe(data => {
        let output = this.outputs.find(o => o.id === data.id);
        if (output) {
          output.progress = data.progress;
        }
      })
    );

    this.signalr.connect();

    this.getRunningTasks()
      .pipe(
        tap(response => {
          if (response) {
            response.forEach(taskId => {
              this.addOutput(taskId);
            });
          }
        })
      )
      .subscribe();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  parseDay() {
    let date = this.parseDate; // this.datePipe.transform(this.parseDate, 'yyyy-MM-dd');

    this.outputs.push({ id: date, messages: [] });

    this.http.get(`api/livescore/parse/${date}`)
      .subscribe(response => {
        if (response?.alreadyRunning) {
          let idx = this.outputs.findIndex(o => o.id == date);
          if (idx)
            this.outputs.splice(idx, 1);
        }
      });
  }

  getRunningTasks() {
    return this.http.get(`api/livescore/current`);
  }

  addOutput(id: string) {
    if (this.outputs.findIndex(o => o.id == id) === -1) 
      this.outputs.push({ id: id, currentEvent: 'Initial', progress: 0, messages: [] });
  }

  trackById(o: any): string {
    return o.id;
  }
}
