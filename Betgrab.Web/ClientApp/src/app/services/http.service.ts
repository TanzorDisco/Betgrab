import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpService {

  private headers: HttpHeaders = new HttpHeaders();

  constructor(@Inject('BASE_URL') private baseUrl: string, private _http: HttpClient) {
    this.headers.append('content-type', 'application/json');
  }

  get(url: string): Observable<any> {
    return this._http.get(`${this.baseUrl}${url}`);
  }

  post(url: string, body: any): Observable<any> {
    return this._http.post(`${this.baseUrl}${url}`, body, { headers: this.headers });
  }
}
