import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getAllHeroes(): Observable<IHero[]> {
    return this.http.get<IHero[]>("http://localhost:4201/api/heroes");
  }

  evolveHero(name: string): Observable<IHero[]> {
    const headers = { 'content-type': 'application/json'};
    let payload = `"${name}, evolve"`
    return this.http.post<IHero[]>("http://localhost:4201/api/heroes", payload, {"headers":headers});
  }

}
export interface IHero { 
  name: string, 
  power: string, 
  stats: [
    { key: string, value: number }, 
    { key: string, value: number }, 
    { key: string, value: number }] 
  }