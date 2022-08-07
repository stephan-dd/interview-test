import { Injectable } from '@angular/core';
import { HeroModel } from 'src/models/hero.model';
import { ApiService } from './api.service';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, forkJoin } from 'rxjs';
import { map, filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HeroApiService extends ApiService {

  path = '/heroes';
  constructor(client: HttpClient) {
    super(client);
  }

  public getHeroes(): Observable<HeroModel[]> {
    return this.get(this.getHeroUrl()).pipe(map((obj) => {
      let array = new Array();
      if (Array.isArray(obj)) {
        obj.forEach((x) => {
          array.push(new HeroModel().deserialize(x));
        });
      }
      return array;
    }));
  }

  public getHeroUrl(): string {
    return this.addPath(this.path);
  }
  public evolveHero(heroName: string): Observable<HeroModel[]> {
    return this.post(this.getHeroUrl(), {action: 'evolve', name: heroName}).pipe(map((obj) => {
      const array = new Array();
      if (Array.isArray(obj)) {
        obj.forEach((x) => {
          array.push(new HeroModel().deserialize(x));
        });
      }
      return array;
    }));
  }

}
