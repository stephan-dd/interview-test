import { Injectable } from '@angular/core';

import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Hero } from './hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // Used URL instead of http://localhost:4201/heroes as in ReadMe doc
  private apiUrl = 'http://localhost:4201/api/heroes'; 
  
  constructor(private http: HttpClient) { }

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl);
  }

  evolveHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.apiUrl, hero)
  }

}
