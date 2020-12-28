import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HeroResponseModel } from '../model/hero.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getHeroes(): Promise<HeroResponseModel[]> {
    return this.http.get<Array<HeroResponseModel>>('http://localhost:4201/api/heroes')
      .toPromise()
      .catch(e => console.error(e)) as Promise<HeroResponseModel[]>;
  }

  evolveHero(name: string, action: string): Promise<HeroResponseModel> {
    return this.http.post<HeroResponseModel>('http://localhost:4201/api/heroes', { name: name, action: action })
      .toPromise()
      .catch(e => console.error(e)) as Promise<HeroResponseModel>;
  }
}
