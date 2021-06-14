import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { Hero } from '../models/Hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:4201/api/heroes';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  HEROES: Hero[] = [
    {
      name: 'Hulk',
      power: 'Strength from gamma radiation',
      stats: [
        {
          name: 'strength',
          value: 5000
        },
        {
          name: 'intelligence',
          value: 50
        },
        {
          name: 'stamina',
          value:  2500
        }
      ]
    }];

  constructor(private http: HttpClient) { }

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl)
    .pipe(
      tap(() => console.log('get all heroes')),
      catchError(this.handleError<Hero[]>('getHeroes', []))
    );
  }

  evolveHero(name: string) {
    return this.http.post<Hero>(this.apiUrl, {heroName: name, action: 'Evolve'}, this.httpOptions)
    .pipe(
      tap(() => console.log('failed to evolve hero.')),
      catchError(this.handleError<any>('failed to evolve hero.'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
