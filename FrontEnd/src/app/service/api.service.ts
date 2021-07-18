import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export default class ApiService {
  private baseUrl = 'http://localhost:4201/api/';
  params: HttpParams = new HttpParams().set('action', 'evolve');

  constructor(private http: HttpClient) { }

  getHeroes = () => this.http.get<any[]>(this.baseUrl + 'heroes');
  evolveHero = (hero: any) => this.http.post(this.baseUrl + 'heroes', hero, { params: this.params });
}



