import { Component, OnInit } from '@angular/core';
import { Hero } from '../models/hero';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes: Hero[];
  hero: Hero;

  title = 'Tour of Heroes';
  columns = ['Name', 'Power', 'Strength', 'Intelligence', 'Stamina', 'Action'];
  colorClass = ['randomClass1', 'randomClass2', 'randomClass3', 'randomClass4'];

  rndInt = Math.floor(Math.random() * 3) + 0;

  randomClass = this.colorClass[this.rndInt];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes() {
    return this.apiService.getHeroes().subscribe((data: Hero[]) => {
      this.heroes = data;
    });
  }

  evolveHero(name: string) {
    this.apiService.evolveHero(name).subscribe((data: Hero) => {
      this.heroes.forEach((item, index) => {
        if (item.name === name) {
          this.heroes.splice(index, 1);
          this.heroes.push(data);
        }
      });
    });
  }
}
