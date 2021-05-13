import { Injectable } from "@angular/core";
import { Hero } from "../models/hero.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  hero: Hero;
  heroes: Array<Hero>;
  private readonly rootUrl = "http://localhost:4201/api/heroes";
  constructor(private http: HttpClient) {}

  getHeroes() {
    this.http
      .get<Array<Hero>>(this.rootUrl)
      .toPromise()
      .then((response) => (this.heroes = response as Array<Hero>));
  }

  getHero(name: string, action: string) {
    const headers = { "Content-Type": "application/json" };

    return this.http.post(
      this.rootUrl + "/evolveby/hero/" + name,
      JSON.stringify(action),
      { headers: headers }
    );
  }
}
