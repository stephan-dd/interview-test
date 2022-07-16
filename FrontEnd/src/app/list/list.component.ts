import { Component, OnInit } from '@angular/core';
import { ApiService, IHero } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private heroes: IHero[];
  public updatedHero: IHero;
  public showStatsUpdate: boolean = false;
  public currentColorClass: string = "";

  constructor(private apiService: ApiService) {
  }

  ngOnInit() {
    this.setRandomColorClass();
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
            this.showStatsUpdate = true;
            setTimeout(() => {this.showStatsUpdate = false}, 9000)
        })
      }

    });
  }

  setRandomColorClass(){
    let randIndex = Math.floor(Math.random() * 4);
    switch(randIndex){
      case 0 :
        this.currentColorClass =  "oceanic-teal"
        break;
      case 1 :
        this.currentColorClass = "ember-red"
        break;
      case 2 :
        this.currentColorClass = "emerald-green"
        break;
      default :
        this.currentColorClass = "galactic-purple"
        break;
    }
  }

}
