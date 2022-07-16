import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = "http://localhost:4201/api";

  constructor(private http: HttpClient) { }

  getAllHeroes(): Observable<IHero[]> {
    return this.http.get<IHero[]>(`${this.baseUrl}/heroes`);
  }

  evolveHero(name: string): Observable<IHero[]> {
    const headers = { 'content-type': 'application/json'};
    let payload = `"${name}, evolve"`
    return this.http.post<IHero[]>(`${this.baseUrl}/heroes`, payload, {"headers":headers});
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