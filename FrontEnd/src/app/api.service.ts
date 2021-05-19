import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError} from 'rxjs/operators';
import { HeroEvolveRequest } from './hero-evolve-request';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl:string = 'http://localhost:4201/api/heroes';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  getHeros() {
    console.log("calling "+ `${this.apiUrl}`);
    return this.http.get(`${this.apiUrl}`).pipe(
      
    );
  }

  evolveHero(data: HeroEvolveRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}`, data, {
      headers: this.headers
    }).pipe(
      catchError(this.error)
    )
  }

  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
  


}
