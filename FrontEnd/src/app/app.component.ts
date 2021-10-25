import { Component, NgZone } from '@angular/core';
import { HeroService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class List {
  title = 'frontend';
  public heroes;

  constructor(private _heroService: HeroService) { }

  ngOnInit(){
    this.getHeroes();
  }

  getHeroes(){
    this._heroService.getHeroesApi().subscribe(response =>{
      this.heroes = response;
    })
  }

  evolveHero(name){
    this._heroService.evolveHeroApi(name).subscribe(() => this.getHeroes());
  }

  getCssClass(){
    let cssClass = [
      "yellow", "purple", "green", "red"
    ]
    return cssClass[Math.floor(Math.random() * cssClass.length)];
  }
}
