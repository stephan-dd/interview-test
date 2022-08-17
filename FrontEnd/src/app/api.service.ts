import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

export interface Hero {
  name: string;
  power: string;
  stats: Stats;
}

export interface Stats {
  strength: number;
  intelligence: number;
  stamina: number;
}

const heroURL = 'http://localhost:4201/heroes';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  public queryParams = new HttpParams();

  constructor(private http: HttpClient) { }

  public evolveHero(id: number): Observable<Hero> {
    this.queryParams = this.queryParams.set("id", id);
    return this.http.get<Hero>(heroURL + "/evolve/", { params: this.queryParams });
  }

  public getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(heroURL);
  }
}
4  
