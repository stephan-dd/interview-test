import { Component, OnInit } from '@angular/core';
import { container } from '@angular/core/src/render3';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
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


  constructor(
    private apiService: ApiService
  ) { }

  ngOnInit() {
    this.loading = true
    this.setHeroColor()
    this.heroes$ = this.apiService.getHeroes().pipe(
      tap((heroes) => {
        this.heroes = heroes
        this.loading = false
      })
    )
  }

  onEvolveHeroeClick(hero: Hero, action: string) {
    this.loading = true
    this.heroes$ = this.apiService.evolveHeroe(action).pipe(
      map((evolvedHeroe) => {
        const index = this.heroes.findIndex((currentHero: Hero) => hero.name === currentHero.name)
        this.heroes[index] = evolvedHeroe
        this.loading = false
        return this.heroes
      }),
      catchError((err) => {
        this.error = err.error
        alert(err.error[''][0])
        console.log(err)
        this.loading = false
        return of(this.heroes);
      })
    )
  }

  setHeroColor() {
    const index = Math.floor(Math.random() * this.heroColors.length)
    this.heroColor = this.heroColors[index]
  }

}
