import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Hero } from './hero.model';
import 'rxjs/add/operator/toPromise';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  constructor(private http: HttpClient) {

   }

  readonly baseUrl = 'http://localhost:4201/api/heroes/'

  hero: Hero = new Hero();

  getHeroes (): Promise<Hero[]> {

    return this.http.get(this.baseUrl)
           .toPromise()
           .then(response =>  {
             debugger;
             return response as Hero[]
           })
  }
}
