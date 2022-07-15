import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getAllHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>("http://localhost:4201/api/heroes");
  }

}
interface Hero { 
  name: string, 
  power: string, 
  stats: [
    { key: string, value: number }, 
    { key: string, value: number }, 
    { key: string, value: number }] 
  }