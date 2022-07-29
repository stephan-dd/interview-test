import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hero } from '../classes/hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  apiUrl = 'http://localhost:4201/api/Heroes'
  constructor(private http: HttpClient) { }

  getHeroes() {
    return this.http.get(this.apiUrl).toPromise();
  }
  
  postEvolve(body: any) : Observable<any>
  { 
    let params = new HttpParams().set('action', 'evolve');
    return this.http.post<Hero>(this.apiUrl,body,{params: params} );
  }

}
