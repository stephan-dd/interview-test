import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Hero } from '../models/hero';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = 'http://localhost:4201/api';

  constructor(private http: HttpClient) { }

  getHeroes() {
    return this.http.get<Hero[]>(this.baseUrl + '/heroes'); 
  }

  evolve(name) {
    return this.http.post<Hero>(this.baseUrl + '/heroes', { name:name, action:'evolve' });
  }
}
