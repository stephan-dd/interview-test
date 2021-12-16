import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Hero } from '../shared/hero.model';
import { Observable } from 'rxjs/Observable';
import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls:  ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes: Hero[] = [];
  updateHero: Hero = null;
  isExpanded : boolean = false;
  public isCollapsed = -1;
  constructor(public service:ApiService,private elRef: ElementRef, private renderer: Renderer2) { }

  colors = ['color-one','color-two','color-three','color-four']
  ngOnInit() {
    
    console.log("List of heros")
    this.getHeroes();
  }

  getHeroes(): void {
    this.service
         .getHeroes().then(heroes =>  {
           this.heroes = heroes;
          });
  }

  evolve(hero,event) {
    this.updateHero = null;
    debugger
    this.service.evolveHero(hero.name).then(response=> {
      this.updateHero = response;
    });

     console.log("hero evolved")
    
  }

  getRandonColor(){
    
    var index =  this.getRandomINumber(0,3)

    return this.colors[index];
  }

 getRandomINumber(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
 
}
