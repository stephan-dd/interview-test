import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';

import { Configuration } from './shared/configuration';
import { Hero } from './api';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Accept': 'application/json'
    }),
    withCredentials: true
  };

  constructor(private http: HttpClient, private configuration: Configuration) {
  }

  public getHeroesFromServer(): Observable<Hero[]> {
    const url = this.configuration.ServerWithApiUrl + 'heroes';
    return this.http.get<Hero[]>(url, this.httpOptions);
  }
  /*private  urlHero = 'http://localhost:4201/api/heroes';
  
  constructor (private http: HttpClient) {}
    
  getHeroesFromServer(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.urlHero);
  }*/
}
