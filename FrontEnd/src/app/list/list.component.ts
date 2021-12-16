import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Hero } from '../shared/hero.model';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styles: []
})
export class ListComponent implements OnInit {
  heroes: Hero[] = [];
  constructor(public service:ApiService) { }

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

}
