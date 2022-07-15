import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from '../models/hero';

@Injectable({
  providedIn : 'root'
})

export class HeroService {
  private url = 'http://localhost:4201/api/heroes';

  constructor(private httpClient: HttpClient) {}

  getPost(action:string):Observable<Hero> {
    return this.httpClient.post<Hero>(this.url, JSON.stringify(action), {headers: { 'Content-Type': 'application/json'}});
  }
}
