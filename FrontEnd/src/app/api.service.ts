/*import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import * as Rx from "rxjs/Rx";
import { from, Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Heroes } from './heroes';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) {}

  getHeroes() {
    return this.httpClient.get('http://localhost:44312/api/heroes').
        pipe(
           map((data: Heroes[]) => {
             return data;
           }), catchError( error => {
             return throwError( 'Something went wrong!' );
           })
        )
    }
}*/

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';

import { Configuration } from './shared/configuration';
import { Heroes } from './heroes';

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

  public getHeroesFromServer(): Observable<Heroes[]> {
    const url = this.configuration.ServerWithApiUrl + 'heroes';
    return this.http.get<Heroes[]>(url, this.httpOptions);
  }
}
