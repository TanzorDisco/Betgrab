import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './services/http.service';

@Component({
  template: ''
})
export class ComponentBase implements OnInit {

  data: any;
  url: string;

  constructor(public http: HttpService) {
  }

  ngOnInit(): void {
    this.getData()
      .subscribe(response => this.data = response);
  }

  getData(): Observable<any> {
    return this.http.get(this.url);
  }
}
