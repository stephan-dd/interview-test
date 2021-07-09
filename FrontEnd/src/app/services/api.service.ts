import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Hero } from '../models/hero';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiBaseUrl = 'http://localhost:4201/api/heroes';

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiBaseUrl);
  }

  evolve(hero: Hero) {
    const headers = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');
    const body = '?value=' + hero.name + '&action=evolve';

    return this.http.post(this.apiBaseUrl + body, null, { headers: headers });
  }
}
