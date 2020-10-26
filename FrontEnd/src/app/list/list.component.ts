import { Component, OnInit } from '@angular/core';
import { stringify } from 'querystring';
import { Subscription } from 'rxjs'
import { ApiService } from '../api.service';
import { Hero } from '../models/hero';



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(private api: ApiService) { }

  private heroSub: Subscription;
  //private heroes: Hero[] = [];
  headers: string[] = ['Name', 'Power', 'Strength', 'Intelligence', 'Stamina'];
  heroes: {name: string, power: string, strength: number, intelligence: number, stamina: number}[] = []
  evolvedHeroStats: string = ''
  randomColor = ''
  

  ngOnInit() {
    this.api.getHeroes();
    this.heroSub = this.api.getHeoresUpdateListener().subscribe((heroData: { heroes: Hero[] }) => {
      this.formatHeroesForDisplay(heroData.heroes);
    });
    this.setBg();
  }

  formatHeroesForDisplay(heroes: Hero[]) {
    heroes.forEach(hero => {
      let displayHero: {name: string, power: string, strength: number, intelligence: number, stamina: number} = {
        name: hero.name,
        power: hero.power,
        strength: this.getStat(hero.stats, "strength"),
        intelligence: this.getStat(hero.stats, "intelligence"),
        stamina: this.getStat(hero.stats, "stamina"),
      }

      this.heroes.push(displayHero);
    });
  }

  getStat(stats: { key: string, value: number}[], statName: string): number {
    let value = 0
    stats.forEach(stat => {
      if (stat.key === statName) {
        value = stat.value;
      }
    });

    return value;
  }

  onEvolve(name: string) {
    console.log('in onEvolve')
    this.api.postEvolve(name);
    this.heroSub = this.api.getHeroUpdateListener().subscribe((heroData: { hero: Hero }) => {
      this.displayHeader(heroData.hero);
    });
  }

  displayHeader(hero: Hero){
    this.evolvedHeroStats = `Hero ${hero.name} has evolved! Strength: ${this.getStat(hero.stats, 'strength')}, Intelligence: ${this.getStat(hero.stats, "intelligence")}, Stamina: ${this.getStat(hero.stats, "stamina")}`;
  }

  setBg() {
    this.randomColor = '#' + Math.floor(Math.random()*16777215).toString(16);
  }
  
}
