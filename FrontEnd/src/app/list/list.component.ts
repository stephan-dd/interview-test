import { Component, OnInit, ViewChild } from '@angular/core';
import { Hero, Stat } from '../models/hero';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes:Hero[] = [];
  updatedHero:Hero;
  isEvolve:boolean;
  CssStyle:string;

  styleArr = ['blue-theme', 'green-theme', 'dark-blue-theme', 'maroon-theme'];

  constructor(private apiService:ApiService) { }

  ngOnInit() {
    
     this.CssStyle = this.styleArr[Math.floor(Math.random() * this.styleArr.length)];
    console.log(Math.floor(Math.random() * this.styleArr.length));
    this.loadHeroes();
  }
   
     loadHeroes(){
       this.apiService.getHeroes().subscribe(result=>{
         this.heroes = result;
       })
     }

     evolve(name:string,
            power:string,
            strength:number,
            intelligence:number,
            stamina:number){
  
        var model = new Hero();
        model.name = name;
        model.power = power;
        model.stats = [];
        model.stats.push({key:"strength", value:strength});
        model.stats.push({key:"intelligence", value:intelligence});
        model.stats.push({key:"stamina", value:stamina});
        this.apiService.updateHeroStats(model).subscribe(hero=>{

          if(hero !== null || hero !== undefined) this.isEvolve = true;
            this.updatedHero = hero;
            this.loadHeroes();
        });
        console.log("updated model");
        console.log(this.updatedHero);
     }
}
