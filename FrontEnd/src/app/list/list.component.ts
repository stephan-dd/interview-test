import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.sass']
})
export class ListComponent implements OnInit {

  superHeroes;
  selectedhero;
  
  evolveHero(hero: Hero) {
  this.service.evolveHero(hero).subscribe(heroes =>
    { 
     this.superHeroes = heroes;
     this.selectedhero = this.superHeroes.find(x => x.name == hero.name);
    }); 
  }
  constructor(public service: ApiService) { }
  ngOnInit() {
    this.service.getSuperHeroes().subscribe(heroes => this.superHeroes = heroes);
  }

}
