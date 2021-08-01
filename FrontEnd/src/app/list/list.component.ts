import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { HeroModel } from '../hero.model';
import { StatsModel } from '../stats.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heros: HeroModel;
  statsUpdatedMessage: string;
  status: StatsModel[];
  randomNumber: number;
  numb: number;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.randomNumber = Math.floor(Math.random() * 4) + 1;
    this.statsUpdatedMessage = null;
    
    this.apiService.getHeroes().subscribe(payload => {
      this.heros = payload;
    });
  }

  evolveHero(name: string){
    this.apiService.evolveHero("evolve");
    
    this.apiService.getHeroes().subscribe(payload => {
      this.heros = payload;
    });

    this.statsUpdatedMessage = name + " updated with: strength, intelligence, stamina" ;
    
  }

}
