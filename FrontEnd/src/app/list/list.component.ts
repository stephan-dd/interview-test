import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Hero } from '../shared/hero.model';
import { Observable } from 'rxjs/Observable';
import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styles: []
})
export class ListComponent implements OnInit {
  heroes: Hero[] = [];
  isExpanded : boolean = false;
  public isCollapsed = -1;
  constructor(public service:ApiService,private elRef: ElementRef, private renderer: Renderer2) { }

  ngOnInit() {
    
    console.log("List of heros")
    this.getHeroes();
  }

  getHeroes(): void {
    this.service
         .getHeroes().then(heroes =>  {
          debugger
           this.heroes = heroes;
          });
  }

  evolve(objHero) {

     console.log("hero evolved")

  }

  expand(event){

    debugger;
    this.isExpanded = !this.isExpanded;
    const nextEl = this.renderer.nextSibling(event);
   
    if (!this.isExpanded) {
      this.renderer.addClass(nextEl, 'show');
    } else {
      this.renderer.removeClass(nextEl, 'show');
    }
  }
}
