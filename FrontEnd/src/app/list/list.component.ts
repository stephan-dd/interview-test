import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Hero } from '../models/hero';
import { HeroService } from '../service/api';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  isEvolved: boolean = false;

  constructor(private hService:HeroService) { }

  randomColor(){
    const color = ['pink', 'yellow', 'purple', 'green'];
    return color[Math.floor(Math.random() * 4 )];
  }

  heroes$: Observable<any>
  ngOnInit(){
    this.loadHero();
  }

  loadHero(action:string = "none"){
    if(action === 'evolve'){
      this.isEvolved = true;
    }
    this.heroes$ = this.hService.getHeroes(action).pipe(
      map((heroes: Hero) => 
        ({
          name: heroes.name,
          power: heroes.power,
          strength: heroes.stats.find(f => f.key === 'strength').value,
          intelligence: heroes.stats.find(f => f.key === 'intelligence').value,
          stamina: heroes.stats.find(f => f.key === 'stamina').value,
        })
      )
    );
  }

}
