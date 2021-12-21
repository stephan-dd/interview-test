import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Hero } from './hero.model';
import 'rxjs/add/operator/toPromise';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http: HttpClient) {

   }

  readonly baseUrl = 'http://localhost:4201/api/heroes/'

  hero: Hero = new Hero();

  getHeroes (): Promise<Hero[]> {

    return this.http.get(this.baseUrl)
           .toPromise()
           .then(response =>  {
            
             return response as Hero[]
           })
  }

  evolveHero(heroName) : Promise<Hero> {

    return this.http.post(this.baseUrl,JSON.stringify({HeroName : heroName}),{headers : this.headers})
    .toPromise()
    .then((response => {
      return response as Hero
    }))
  }
}
