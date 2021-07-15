import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'http://localhost:4201/api/';

  constructor(private http: HttpClient) { }

  getHeroes = () => this.http.get<any[]>(this.baseUrl + 'heroes');

  //call the api to post the evolve of a hero
  // postEvolve = (heroId: number) => this.http.post(this.baseUrl + 'heroes/' + heroId + '/evolve');
}
