import { Component, OnInit } from '@angular/core';
import { Hero } from '../shared/models/Hero';
import { HeroService } from '../shared/services/hero.service';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.page.html',
  styleUrls: ['./hero-list.page.scss'],
})
export class HeroListPage implements OnInit {
    heroList: [];
    public evolvedH: Hero;
    hero: [];

    public title: string;
  constructor(private heroService: HeroService) { }

  ngOnInit() {
    this.title = 'Tour of Heroes';
  
    this.heroService.getHeroList().then(res =>
      {
        //  this.heroList = res as Hero[];
        this.heroList = res as [];
      });
      
    }
    
    evolve(heroName) {
      const body = {
        heroName: heroName,
        userAction: 'evolve'
      };

      
      this.heroService.evolve(body).subscribe((res) => {
        // this.evolvedH = res as Hero;
        this.heroList = res as [];

      });
    }
  
}