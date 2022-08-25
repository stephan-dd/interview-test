import { Component, OnInit } from "@angular/core";
import { HeroService } from "../service/api.service";



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

export class ListComponent  implements OnInit{

  heroList:any;

  listCSSClass = ['reb-color','green-color','yellow-color','orange-color']

  constructor(private _hero: HeroService){
  }

  ngOnInit(){
    this.getHero();
  }

  /**
   * Gets heroes list
   */
  getHero(){
    this._hero.getHero().subscribe( hero =>{

      this.heroList = hero;
    },
    () => alert('Error Please check if the api is up!!'));
  }

  /**
   * This post the hero to the backend
   * @param hero
   *
   */
  evolveEvent(hero){
    this._hero.postHero(hero).subscribe( results =>{
      this.heroList = results;
    },
    (error) => alert(error));
  }
}