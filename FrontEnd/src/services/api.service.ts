import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Hero } from "src/models/hero.model";
import { environment } from "src/environments/environment";

@Injectable()
export class HeroService {
  constructor(private httpClient: HttpClient) {}

  getHeroes = (): Observable<Hero[]> => {
    return this.httpClient.get<Hero[]>(`${environment.baseUrl}/Heroes`);
  };

  evovleHero = (name: string): Observable<Hero> => {
    const params = new HttpParams().set("actions", "evolve");
    return this.httpClient.post<Hero>(`${environment.baseUrl}/Heroes/${name}`, {}, {
      params: params,
    });
  };
}
