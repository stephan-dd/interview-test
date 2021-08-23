import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Hero } from '../hero';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  title = "List of Heroes";
  showMessage = false;
  heroes;
  currentHero;

  

  constructor(public service: ApiService) {}

  evolve(hero: Hero) {
    if (hero.multiplier == null) {
      hero.multiplier = 0;
    }
    hero.multiplier++;

    this.service.evolve(hero).subscribe(hero2 => {     
      var index = this.heroes.findIndex(item => item.name == hero2.name);
      hero2.multiplier = hero.multiplier;

      this.currentHero = hero2;
      this.heroes[index] = hero2;
      this.showMessage = true;
    }); 
  }

  ngOnInit() {
    this.service.getHeroes().subscribe(heroes => this.heroes = heroes);
  }

}
