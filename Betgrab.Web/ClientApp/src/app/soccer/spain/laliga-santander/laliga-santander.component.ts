import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../../../component-base';
import { HttpService } from '../../../services/http.service';

@Component({
  selector: 'app-laliga-santander',
  templateUrl: './laliga-santander.component.html',
  styleUrls: ['./laliga-santander.component.scss']
})
export class LaligaSantanderComponent extends ComponentBase {

  constructor(httpService: HttpService) {
    super(httpService);
    this.url = 'api/betgrab/laligasantander';
  }
}
