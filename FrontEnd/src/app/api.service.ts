import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Heroes } from './list/classes';



@Injectable({
  providedIn: 'root'
})

export class ApiService {

  private _url: string ="http://localhost:4201/api/heroes";

  constructor(private http: HttpClient) { }

  getHeroes(): Observable<any>
  {
    return this.http.get<any>(this._url);
  }

  postEvolve(body: any) : Observable<any>
  { 
    let paramsEvolve = new HttpParams().set('value', 'evolve');
    return this.http.post<any>(this._url,body,{params: paramsEvolve} );
  }
}


