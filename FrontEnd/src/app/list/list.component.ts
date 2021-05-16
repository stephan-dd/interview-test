import { Component, OnInit } from '@angular/core';
import {Api} from 'src/service/api'
import { Hero } from 'src/models/hero';
import { Observable, of, Subject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Action } from 'src/models/action';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private heroesSubject = new Subject<Hero[]>();
  public error : any;
  heroes$: Observable<Hero[]>;
  colorsHeroes = ["blue","black","orange","green"];
  colorForHeroes:string;
  UpdatedHero:Hero;
  public heroes:Array<Hero>;
  hero$:Observable<Hero>
  constructor (private api: Api) {}

  ngOnInit() {
    this.heroes = [];
    this.SetColor();
    this.heroes$= this.heroesSubject.asObservable();
    this.GetHeroes();
  }

  //Getting the list of all heroes in the api and return it to the UI
  private GetHeroes()
  {
    this.api.getHeroes().subscribe((data)=>{
    this.heroes = data;
    this.heroesSubject.next(this.heroes);
  })
    this.heroes$.pipe(map((heroes) => {heroes.forEach(hero => { hero = this.GetStats(hero)});
    this.heroes = heroes
    return this.heroes
  }),
  catchError((err) => {
      this.error = err.error
      return of(this.heroes);
    })
    ).subscribe()  
  }
  //Onclick event for the button evolved and return evolve resuts from the api to the UI
  OnEvolveClick (hero: Hero,action:string){

    const body: Action={
      actionName:action,
      heroName:hero.name
    }
    this.hero$ = this.api.heroesEvolved(body);
    console.log(action);
    this.hero$.pipe(
      map((HeroEvolved: Hero) => {
        const index: number = this.heroes.findIndex((currentHero: Hero) => hero.name === currentHero.name)
        this.heroes[index] = this.GetStats(HeroEvolved)
        this.UpdatedHero = HeroEvolved
        return HeroEvolved
      }),
      catchError((error) => {
        this.error = error.error

        return of(this.heroes);
      })
    )
      .subscribe()
  }
  //Getting hero stats in and loop through
  private GetStats(hero: Hero){
    var stats = hero.stats;
    hero.stats.forEach((item)=>{
      switch (item.key)
      {
        case 'strength':
              hero.strength = item.value
              break
        case 'intelligence':
              hero.intelligence = item.value
              break
        case 'stamina':
        hero.stamina = item.value
        break
      }
    })
    return hero;
  }
  //setting random color to for the list.
   private SetColor(){
    var colorIndex  = Math.floor(Math.random()* this.colorsHeroes.length);
    this.colorForHeroes = this.colorsHeroes[colorIndex];
  }
}
