import { Component, OnInit } from '@angular/core';
import {Api} from 'src/service/api'
import { Hero } from 'src/models/hero';
import { Observable, of, Subject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private heroesSubject = new Subject<Hero[]>();
  public error : any;
  heroes$: Observable<Hero[]>;
  colorsHeroes = ["blue","black","orange","yellow"];
  colorForHeroes:string;
  public heroes:Array<Hero>;
  
  constructor (private api: Api) {
  }

  ngOnInit() {
    this.heroes = [];
    this.SetColor();
    this.heroes$= this.heroesSubject.asObservable();
    this.GetHeroes();

  }

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
   private SetColor(){
    var colorIndex  = Math.floor(Math.random()* this.colorsHeroes.length);
    this.colorForHeroes = this.colorsHeroes[colorIndex];
  }
  

}
