import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HeroModel } from './_models/hero.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  url = 'http://localhost:4201/heroes';

  constructor(private httpClient: HttpClient) {
  }

  public getHeroes(): Observable<any> {

    return this.httpClient.get('http://localhost:4201/heroes');

  }

  public getHeaders(): HttpHeaders {

    let head;

    head = new HttpHeaders({ Accept: 'application/json' });

    return head;

  }

  evolveHero(theHero: string): Observable<any> {

    let params = new HttpParams().set('theHero', theHero).set('action', 'evolve');
    let myreturn = this.httpClient.post(this.url, theHero, { params: params, observe: 'response', headers: this.getHeaders() });;
    return myreturn;
    
  }
}
