import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IHero } from './hero';
import { postBody } from './postBody';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private _baseUrl: string = "http://localhost:4201/api/heroes"

  private _hero: IHero;

  private _body: postBody = new postBody();

  constructor(private _http: HttpClient) { }

  evolveHero(id: number):Observable<any>
  {
    this._body.action = "evolve";
     return this._http.post(this._baseUrl, this._body.action)
            .pipe(catchError(this.errorHandler)); 
  }

  getHeroes(): Observable<IHero[]>
  {
    return this._http.get<IHero[]>(this._baseUrl);
                   //  .pipe(catchError(this.errorHandler));
  }

  errorHandler(error:HttpErrorResponse){
    return throwError(error.message || 'server Error');
  }
}
