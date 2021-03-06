import { Component, OnInit } from '@angular/core';
import { container } from '@angular/core/src/render3';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Action } from 'src/app/interfaces/action';
import { Hero } from 'src/app/interfaces/hero';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes$: Observable<Hero[]>

  loading: boolean = true
  heroes: Hero[]
  error: any;

  heroColors = ['red', 'gray', 'white', 'blue']
  heroColor: string;
  heroe$: any;
  selectedHero: Hero;


  constructor(
    private apiService: ApiService
  ) { }

  ngOnInit() {
    this.loading = true
    this.setHeroColor()
    this.heroes$ = this.apiService.getHeroes()

    this.heroes$.pipe(
      map((heroes) => {
        this.loading = false
        this.heroes = heroes
        console.log(this.heroes, 'j')
        return heroes
      })
    ).subscribe()
  }

  onEvolveHeroeClick(hero: Hero, action: string) {
    this.loading = true
    const body: Action = {
      name: hero.name,
      action
    }
    this.heroe$ = this.apiService.evolveHeroe(body)

    this.heroe$.pipe(
      map((evolvedHeroe: Hero) => {
        const index: number = this.heroes.findIndex((currentHero: Hero) => hero.name === currentHero.name)
        this.heroes[index] = evolvedHeroe
        this.loading = false
        this.selectedHero = evolvedHeroe
        setTimeout(() => {
          this.selectedHero = undefined
        }, 5000);
        return evolvedHeroe
      }),
      catchError((err) => {
        this.error = err.error
        alert(err.error[''][0])
        this.loading = false
        return of(this.heroes);
      }))
      .subscribe()
  }

  setHeroColor() {
    const index = Math.floor(Math.random() * this.heroColors.length)
    this.heroColor = this.heroColors[index]
  }

}
