import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { HeroModel } from '../_models/hero.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  hero: HeroModel;
  heroes: any;
  updateResponse = false;
  constructor(private apiService: ApiService) { }

  ngOnInit() {

    this.hero = new HeroModel();
    this.getHeroes();

  }
  getHeroes() {

    this.apiService.getHeroes().subscribe((response) => {

      this.heroes = response;

    });
  }

  randomizeColor() {

      var min = Math.ceil(1);
      var max = Math.floor(5);
      var res = Math.floor(Math.random() * (max - min)) + min;
      return 'colorClass' + res;
    
  }


  evolve(theHero: string) {
      
      this.apiService.evolveHero(theHero).subscribe((response) => {       
        
        
        console.log(response);
        this.updateResponse = true;
        this.hero = response.body;

      });
    

  }
}
