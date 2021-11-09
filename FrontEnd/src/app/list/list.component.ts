import { importType } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';


import { ApiService } from "../api.service";
import { Hero } from '../hero';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  providers: [ ApiService]
})
export class ListComponent implements OnInit {
  title = 'Tour of Heroes';
  heroes: Hero[] = [];
  heroEvolve: Hero;
  
  constructor(private apiService: ApiService) {}
     
  ngOnInit() {
    this.getHeroes();
  }
  
  getHeroes(): void {
    this.apiService
      .getHeroes()
      .subscribe(heroes => (this.heroes = heroes));
  }

  evolveHero(hero: Hero) {
    this.heroEvolve = hero;

    this.heroEvolve.action = "evolve";

    if (this.heroEvolve) {
      this.apiService
        .evolveHero(this.heroEvolve)
        .subscribe(hero => {
            const heroSelectedIndex = this.heroes.findIndex(h => h.name === hero.name);
            this.heroes[heroSelectedIndex] = hero;
            this.updateHeroEvolved(hero)
          });
    }
  }

  updateHeroEvolved(hero: Hero): void{
    this.heroEvolve = hero;
    
    document.getElementById("heroEvolvedInfo")
      .innerHTML = `${this.heroEvolve.name} updated with 
                    ${this.heroEvolve.stats[0].key} : ${this.heroEvolve.stats[0].value}, 
                    ${this.heroEvolve.stats[1].key} : ${this.heroEvolve.stats[1].value} and  
                    ${this.heroEvolve.stats[2].key} : ${this.heroEvolve.stats[2].value}`;
  }

  getCssClass(){
    let cssClass = [
      "info", "danger", "success", "primary"
    ]
    return cssClass[Math.floor(Math.random() * (cssClass.length + 0))];
  }


}