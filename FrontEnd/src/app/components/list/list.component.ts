import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/models/hero';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes: Hero[] = [];
  hero: Hero = null;
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes(): void {
    this.apiService.getHeroes().subscribe(heroes => this.heroes = heroes);
  }

  evolve(name: string) {
    this.apiService.evolve(name).subscribe(hero => this.hero = hero)
  }

}
