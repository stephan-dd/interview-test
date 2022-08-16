import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hero } from '../shared/hero';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // API
  apiURL = environment.baseUrl;

  constructor(private http: HttpClient) { }

  /*========================================
    Consuming RESTful API
  =========================================*/

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // HttpClient API get() method => Fetch heroes list
  getHeroes(): Observable<Hero> {
    return this.http.get<Hero>(this.apiURL + '/api/heroes')
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  // HttpClient API get() method => Fetch hero
  getHero(name): Observable<Hero> {
    return this.http.get<Hero>(this.apiURL + '/api/heroes/' + name)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  /*
  // HttpClient API put() method => Update hero
  evolveHero(id, hero): Observable<Hero> {
    console.log('--------------------');

    console.log(id, hero);
    return this.http.put<Hero>(this.apiURL + '/api/heroes/' + id, JSON.stringify(hero), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }
  */

  // HttpClient API put() method => Update Hero
  evolveHero(id, hero): Observable<Hero> {
    return this.http.put<Hero>(this.apiURL + '/api/heroes/' + id, hero[0], this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  // HttpClient API delete() method => Delete hero
  deleteHero(id) {
    return this.http.delete<Hero>(this.apiURL + '/api/heroes/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  // Error handling
  handleError(error) {
     let errorMessage = '';
     if (error.error instanceof ErrorEvent) {
       // Get client-side error
       errorMessage = error.error.message;
     } else {
       // Get server-side error
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     window.alert(errorMessage);
     return throwError(errorMessage);
  }
}
