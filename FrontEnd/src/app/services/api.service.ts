import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { Hero } from '../interfaces/hero';
import { Observable } from 'rxjs';

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

  evolveHeroe(action: string): Observable<any> {
    let body = JSON.stringify(action)
    return this.http.post(
      this.url,
      body,
      { headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' }) }
    )
  }
}
