import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hero } from './hero';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private webApi = 'http://localhost:4201/api/heroes'; 

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getContacts(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.webApi)
      .pipe(
        tap(_ => console.log('contacts retrieved')),
        catchError(this.onError<any>('getContacts()'))
      );
  }

  addContact(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.webApi, hero, this.httpOptions).pipe(
      tap((newHero: Hero) => console.log(`hero  id=${newHero.id} added`)),
      catchError(this.onError<Hero>('addHero'))
    );
  }

  private onError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error); 
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }


  
}
