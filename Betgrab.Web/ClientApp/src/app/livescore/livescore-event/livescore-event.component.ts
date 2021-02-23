import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-livescore-event',
  templateUrl: './livescore-event.component.html',
  styleUrls: ['./livescore-event.component.scss']
})
export class LivescoreItemComponent implements OnInit {

  @Input()
  data: LivescoreDatePasingData;

  constructor() { }

  ngOnInit(): void {
  }

}


export interface LivescoreDatePasingData {
  // [id]="o.id" [currentEvent]="o.currentEvent" [progress]="o.progress"
  id?: string;
  currentEvent?: string;
  progress?: number;
}