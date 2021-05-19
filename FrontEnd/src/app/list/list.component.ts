import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Hero } from '../hero';
import { HeroEvolveRequest } from '../hero-evolve-request';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  
  heroes: Hero[];
  updatedHero: Hero;
  randomClass:string;

  constructor(private apiService: ApiService){}

  ngOnInit() {
    this.apiService.getHeros()
    .subscribe((response: Hero[]) => {
      this.heroes = response;
      console.log(this.heroes);
    })

    this.getRandomClass();  
  }
  evolveHero(hero: Hero){
    console.log("Evolving my hero",hero)

    let evolveRequest: HeroEvolveRequest = {
      actionName : "evolve",
      heroName: hero.name
    }
    this.apiService.evolveHero(evolveRequest)
        .subscribe((response: Hero) => {

          let index = this.heroes.indexOf(hero);
          this.heroes[index] = response;
          this.updatedHero = response;
        });
  }
getRandomClass(){
  var items = ['black', 'skyblue', 'green'];
  this.randomClass = items[Math.floor(Math.random()*items.length)];
}

}
