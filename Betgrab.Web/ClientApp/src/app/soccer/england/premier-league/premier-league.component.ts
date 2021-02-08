import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../../../component-base';
import { HttpService } from '../../../services/http.service';

@Component({
  selector: 'app-premier-league',
  templateUrl: './premier-league.component.html',
  styleUrls: ['./premier-league.component.scss']
})
export class PremierLeagueComponent extends ComponentBase {

  constructor(httpService: HttpService) {
    super(httpService);
    this.url = 'api/betgrab/premierleague';
  }
}
