import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HttpService } from '../services/http.service';
import { SignalrService } from '../signalr.service';
import { LivescoreOutput } from './livescore.models';

@Component({
  selector: 'app-livescore',
  templateUrl: './livescore.component.html',
  styleUrls: ['./livescore.component.scss']
})
export class LivescoreComponent implements OnInit, OnDestroy {

  parseDate: string;
  outputs: LivescoreOutput[] = [];
  newOutput: Subscription;
  livescoreOutput: Subscription;

  constructor(
    private http: HttpService,
    private datePipe: DatePipe,
    private signalr: SignalrService) {
  }

  ngOnInit(): void {
    this.parseDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');

    this.signalr.connect();

    this.livescoreOutput = this.signalr.livescoreOutput
      .subscribe(m => {
        let output = this.outputs.find(o => o.id === m.id);

        if (output)
          output.messages.push(m.message);
      });

    this.newOutput = this.signalr.newLivescoreCreated
      .subscribe(o => {
        this.addOutput(o.id);
      });

    this.getRunningTasks()
      .subscribe(response => {
        if (response) {
          response.forEach(taskId => {
            this.addOutput(taskId);
          });
        }
      });
  }

  ngOnDestroy() {
    this.livescoreOutput.unsubscribe();
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
      this.outputs.push({ id: id, messages: [] });
  }

  outputDate() {
    console.log(this.parseDate);
  }
}
