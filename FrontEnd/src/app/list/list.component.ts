import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { ApiService } from '../api.service';
import { timer } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes: Hero[];
  updateStats = true;
  updatedHero = {};
  colorRandom = '';

  colorScheme = ['color-scheme-red','color-scheme-blue','color-scheme-green','color-scheme-gray']

  constructor(private ApiService: ApiService) { }

  ngOnInit() {
    this.getHeroes();
    this.colorRandom = this.colorScheme[(Math.floor(Math.random() * this.colorScheme.length))];
  }

  getHeroes() {
    this.ApiService.getHeroes()
    .subscribe(heroes => (this.heroes = heroes));

  }

  evolve(name:string): void {
    this.ApiService.evolveHero(name)
      .subscribe(hero => {

        this.displayStatsUpdate(hero);
      });
  }

  displayStatsUpdate(hero: Hero): void {
    this.updateStats = false;
    this.updatedHero = hero;
    let idx = this.heroes.findIndex(x => x.name == hero.name)
    this.heroes[idx] = hero;
    //MJK: hide display after 5 seconds
    const source = timer(5000);
    const subscribe = source.subscribe(val => this.updateStats = true);
  }
}
