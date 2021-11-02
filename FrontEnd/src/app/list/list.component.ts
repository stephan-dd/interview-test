import { Component, OnInit } from "@angular/core";
import { HeroService } from "../api/api.service";



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

export class ListComponent  implements OnInit{

  heroList:any;
  constructor(private _hero: HeroService){
  }

  ngOnInit(){
    this.getHero();
  }

  getHero(){
    this._hero.getHero().subscribe( hero =>{

      this.heroList = hero;
    },
    () => alert('Error Please check if the api is up!!'));
  }

  postHero(){
    this._hero.postHero()
  }
}
