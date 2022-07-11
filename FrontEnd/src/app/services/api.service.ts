import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { contacts } from '../models/contacts.model';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  //Environment API BaseURL
  apiBaseUrl = environment.apiBaseUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // Get() - get heroes list
  getHeroes(): Observable<contacts>{
    return this.http.get<contacts>(this.apiBaseUrl + '/api/heroes');
  }

  // HttpClient put() - Update hero
  evolve(id, hero): Observable<contacts> {
    return this.http.put<contacts>(this.apiBaseUrl + '/api/heroes/' + id, hero[0], this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandle)
    );
  }

  deleteHero(id) {
    return this.http.delete<contacts>(this.apiBaseUrl + '/api/heroes/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandle)
    );
  }

  // Error handling
  errorHandle(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client error
      errorMessage = error.error.message;
    } 
    else {
      // Get server error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
