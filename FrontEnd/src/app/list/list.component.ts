import { Component, OnInit } from '@angular/core';
import { ApiService, IHero } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private heroes: IHero[];

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes() {
    this.apiService.getAllHeroes().subscribe(data => {
      this.heroes = data;
      console.log(JSON.stringify(this.heroes, null, 1))
    });
  }

  evolveHero(){
    this.apiService.evolveHero().subscribe(data => {
      this.heroes = data;
      console.log(JSON.stringify(this.heroes, null, 1))
    });
  }

}
