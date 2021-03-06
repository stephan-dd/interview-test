import { Component, OnDestroy, OnInit } from '@angular/core';
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
export class ListComponent implements OnInit, OnDestroy {
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
    // start default loader
    this.loading = true

    // Set random Table color
    this.setHeroColor()

    // Make api call, update hero statictics variables and set heroes array to returned values
    this.heroes$ = this.apiService.getHeroes()
    this.heroes$.pipe(
      map((heroes) => {
        heroes.forEach(hero => {
          hero = this.setStats(hero)
        });
        this.loading = false
        this.heroes = heroes
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
    // Post name and action to api service
    this.heroe$ = this.apiService.evolveHeroe(body)
    this.heroe$.pipe(
      map((evolvedHeroe: Hero) => {
        // Get user index by name
        const index: number = this.heroes.findIndex((currentHero: Hero) => hero.name === currentHero.name)

        // update selected hero and set hero statistics
        this.heroes[index] = this.setStats(evolvedHeroe)
        this.loading = false

        // Set selected hero to show evolved hero details
        this.selectedHero = evolvedHeroe
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

  private setHeroColor() {
    const index = Math.floor(Math.random() * this.heroColors.length)
    this.heroColor = this.heroColors[index]
  }

  private setStats(hero: Hero): Hero {
    const stats = hero.stats
    stats.forEach((stat) => {
      switch (stat.key) {
        case 'strength':
          hero.strength = stat.value
          break
        case 'intelligence':
          hero.intelligence = stat.value
          break
        case 'stamina':
          hero.stamina = stat.value
          break
      }
    })
    return hero
  }

  ngOnDestroy() {

  }



}
