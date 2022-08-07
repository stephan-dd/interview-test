import { Component, OnInit } from '@angular/core';
import { HeroApiService } from 'src/services/hero-api.service';
import { HeroModel } from 'src/models/hero.model';
import { Observable, forkJoin } from 'rxjs';
import { map, filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes: Observable<HeroModel[]>;
  heroArray = new Array();
  heroObserver = {
    next : (x) => {
      x = new HeroModel().deserialize(x);
    },
    error: () => console.log('error'),
    complete: () => console.log('complete'),
  };
  constructor(private heroApiService: HeroApiService) { }

  ngOnInit() {
    this.getHeroes();
  }

  public getHeroes(): any {
    this.heroes = this.heroApiService.getHeroes();
    this.heroes.subscribe(this.heroObserver);
  }

  public evolveHero(name: string): void {
    this.heroes = this.heroApiService.evolveHero(name);
    this.heroes.subscribe(this.heroObserver);
  }

}
