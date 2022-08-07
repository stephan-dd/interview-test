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

  evolveObserver = {
    next: (x) => {
      x = new HeroModel().deserialize(x);
      console.log(x);
      this.heroes.forEach(h => {
        h.map((value, index)=> {
          h[index] = x;
        });
        console.log(h);
      });
    }
  };
  heroObserver = {
    next : (x) => {
      x = new HeroModel().deserialize(x);
      
      this.updateHero(x);
    },
    error: () => console.log("error"),
    complete: () => console.log("complete"),
  };
  constructor(private heroApiService: HeroApiService) { }

  ngOnInit() {
    this.getHeroes();
  }
  
  public getHeroes(): any {
    this.heroes = this.heroApiService.getHeroes();
    // this.heroes.subscribe(res => res.forEach((hero) => {
    //   console.log(hero);
    //   let newHero = new HeroModel().deserialize(hero);
    //   return newHero;
    // }));
    this.heroes.subscribe(this.heroObserver);
    // console.log(this.heroes);
  }

  public evolveHero(name: string): void {
    var response = this.heroApiService.evolveHero(name).subscribe(this.evolveObserver);
    console.log(response);
    //response.pipe(map(res => console.log(res)));
    this.heroes.subscribe(x => {
      console.log(x);
    });
    // return response;
  }
/**
 * updateHero
 */
public updateHero(hero: HeroModel){
  // this.heroes.forEach((h) => {
  //   if (Array.isArray(h))
  //   {
  //     console.log(h);
  //     h.forEach((oldHero,i) => {
  //       if(oldHero.Name === hero.Name)
  //       {
  //         h[i] = hero;
  //         oldHero = hero;
  //         //console.log(oldHero);
  //       }
  //     });
  //   }
    
  // });
  
}

}
