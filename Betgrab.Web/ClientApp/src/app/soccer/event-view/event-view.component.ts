import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComponentBase } from '../../component-base';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-event-view',
  templateUrl: './event-view.component.html',
  styleUrls: ['./event-view.component.scss']
})
export class EventViewComponent extends ComponentBase implements OnInit {
  eventId: string;
  data: any;

  constructor(http: HttpService, private activatedRoute: ActivatedRoute) {
    super(http);
  }

  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe(p => {
        this.eventId = p.id;
        this.http.get(`api/betgrab/event?eventId=${p.id}`)
          .subscribe(response => {
            this.data = response;
          });
      })
  }

}
