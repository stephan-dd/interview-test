import { Component, OnInit } from '@angular/core';
import { ApiService, IHero } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private heroes: IHero[];
  private updatedHero: IHero;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes() {
    this.apiService.getAllHeroes().subscribe(data => {
      this.heroes = data;
    });
  }

  evolveHero(name: string){
    this.apiService.evolveHero(name).subscribe(data => {
      if(data != undefined){
        this.updatedHero = data;
        this.heroes.forEach((hero)=>{
          if(hero.name === name)
            hero.stats = this.updatedHero.stats;
        })
      }

    });
  }

}
