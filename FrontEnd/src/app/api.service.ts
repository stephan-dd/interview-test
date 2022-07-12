import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getHeroes(){
    return this.httpClient.get('http://localhost:4201/api/heroes');
  }

  public evolve(name){
    return this.httpClient.post('http://localhost:4201/api/heroes', { 'name': name, 'action': 'evolve'});
  }
}
