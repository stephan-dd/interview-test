import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getHeroes() {      
    return this.http.get<any>('http://localhost:4201/heroes/');
  }

  evolveHero(hero) {  
    
    const headers = { 'Content-Type': 'application/json' }
    const body = { action: "evolve", hero: hero }

    return this.http.post<any>('http://localhost:4201/heroes/evolve/', body, { headers });
  }
}
