import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Hero } from '../models/hero';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getHeroes() {
    return this.http.get<Hero[]>('http://localhost:4201/heroes'); 
  }
}
