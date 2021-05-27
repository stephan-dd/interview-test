import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { Hero } from '../models/hero';


@Injectable({
  providedIn: 'root',
})
export class HeroService {

  constructor(private http:HttpClient) { }

  getHeroes(action:string):Observable<Hero>{
      return this.http.post<Hero>('http://localhost:4201/api/heroes',  JSON.stringify(action), {headers: { 'Content-Type': 'application/json'}});
  }

}