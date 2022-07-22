import { Component, OnInit } from '@angular/core';

import { Hero } from 'src/app/shared/model/hero';
import { HeroService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  selectedHero?: Hero;

  heroes: Hero[] = [];

  updateHero?: Hero;

  constructor(private heroService: HeroService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  onSelect(hero: Hero): void {
    this.selectedHero = hero;
  }

  getHeroes(): void {
    this.heroService.getHeroes()
        .subscribe(heroes => this.heroes = heroes);
  }

  evolve(hero: Hero): void {
    this.heroService.updateHero(hero, 'evolve')
    .subscribe(heroe => {
      this.updateHero = heroe;
      this.heroes.forEach(item => {
        if (hero.name === item.name) {
          this.heroes.splice(this.heroes.indexOf(item), 1);
        }
      });
    
      this.heroes.push(this.updateHero);
    });

  }
}
