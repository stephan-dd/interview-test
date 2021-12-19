import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes = [];

  constructor(private apiService: ApiService) { }



  ngOnInit() {

    this.apiService.sendGetHeroes().subscribe((data: any[]) => {
      console.log(data);
      this.heroes = data;
    });
  }

  randomColorClass = ['rcol-1', 'rcol-2', 'rcol-3', 'rcol-4'];

  getRandomClass(){
    return this.randomColorClass[Math.floor(Math.random()*4)]
  }


  hero = null;

  evolve(hero: any) {
    this.apiService.sendPostHero(hero, true).subscribe((data: any) => {
      console.log(data);
      this.hero = data;

      for (var index = 0; this.heroes.length > index; index++) {
        if (this.heroes[index].name == data.name)
          this.heroes[index] = data;
      }
    });
  }
}