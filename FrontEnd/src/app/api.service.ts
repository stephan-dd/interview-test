import { Injectable } from '@angular/core';
import { Hero } from './hero';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private heroesUrl = 'http://localhost:4201/api/heroes';

  constructor( private http: HttpClient) { }

  getHeroes():Observable<Hero[]>{
    return this.http.get<Hero[]>(this.heroesUrl)
    .pipe(
      catchError(this.handleError<Hero[]>('getHeroes', []))
    );
  }

  evolveHero(name:string): Observable<Hero> {
    let params = new HttpParams().set('action', 'evolve');
    let body = { name: name};
    return this.http.post<Hero>(this.heroesUrl,body,{params: params})
      .pipe(
        catchError(this.handleError<Hero>('evolveHero',null))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // log to console instead
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }


}
