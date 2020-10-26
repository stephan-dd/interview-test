import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { observable, Observable, Subject } from 'rxjs'
import { map } from "rxjs/operators";

import { Hero } from '../app/models/hero'

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private url = 'http://localhost:4201/api/heroes/';
  private heroes: Hero[] = []
  private hero: Hero;
  private heroesUpdated = new Subject<{ heroes: Hero[] }>();
  private heroUpdated = new Subject<{ hero: Hero }>();

  constructor(private http: HttpClient) { }
  
  getHeroes() {
    this.http.get<Hero[]>(this.url)
    .pipe(
      map(heroData => {
        return {
          heroes: heroData.map(hero => {
            return {
              name: hero.name,
              power: hero.power,
              stats: hero.stats.map(stat => {
                return {
                  key: stat.key,
                  value: stat.value
                }
              })
            };
          })
        }
      })
    )
    .subscribe(transformedHeroData => {
      this.heroes = transformedHeroData.heroes;
      this.heroesUpdated.next({
        heroes: this.heroes
      })
    });
  }

  getHeoresUpdateListener() {
    return this.heroesUpdated.asObservable();
  }

  getHeroUpdateListener() {
    return this.heroUpdated.asObservable();
  }

  postEvolve(name: string) {
    console.log('in postEvolve')
    console.log(this.url + name)
    this.http.post<Hero>(this.url + name, {action: "evolve"}).pipe(
      map(heroData => {
        return {
            name: heroData.name,
            power: heroData.power,
            stats: heroData.stats.map(stat => {
              return {
                key: stat.key,
                value: stat.value
              }
            })
          }
        }
      )
    )
    .subscribe(transformedHeroData => {
      this.hero = transformedHeroData;
      this.heroUpdated.next({
        hero: this.hero
      })
    });
  }
}
          

           
             
