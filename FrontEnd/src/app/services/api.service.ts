import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { Hero } from '../interfaces/hero';
import { Observable } from 'rxjs';
import { Action } from '../interfaces/action';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url: string = 'http://localhost:4201/api/heroes'

  constructor(
    private http: HttpClient
  ) { }

  getHeroes(): Observable<any> {
    return this.http.get(this.url)
  }

  evolveHeroe(action: Action): Observable<any> {
    return this.http.post(
      this.url,
      action,
      { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }
    )
  }
}
