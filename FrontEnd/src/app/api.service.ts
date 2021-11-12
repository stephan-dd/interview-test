import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from './hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
 
  private baseurl = 'http://localhost:4201';

  constructor(private http: HttpClient) { }
  
  getSuperHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.baseurl + '/heroes');

  }
  
  evolveHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.baseurl + '/heroes/?' +  'action=evolve' +'&hero=' + hero.name  , null);
  }

}
