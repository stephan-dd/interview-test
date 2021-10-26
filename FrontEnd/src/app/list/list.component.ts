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

    this.heroEvolve.action = "action";

    if (this.heroEvolve) {
      this.apiService
        .evolveHero(this.heroEvolve)
        .subscribe(hero => {
            //find the hero selected and update the values, then update heroEvolve object so new values can be displayed
            const heroSelectedIndex = this.heroes.findIndex(h => h.name === hero.name);
            this.heroes[heroSelectedIndex] = hero;
            this.updateHeroEvolved(hero)
          });
    }
  }

  updateHeroEvolved(hero: Hero): void{
    this.heroEvolve = hero;
    
    //only display hero info above table if the heroEvolve has been updated
    document.getElementById("heroEvolvedInfo")
      .innerHTML = `${this.heroEvolve.name} updated with 
                    ${this.heroEvolve.stats[0].key} : ${this.heroEvolve.stats[0].value}, 
                    ${this.heroEvolve.stats[1].key} : ${this.heroEvolve.stats[1].value} and  
                    ${this.heroEvolve.stats[2].key} : ${this.heroEvolve.stats[2].value}`;
  }


}