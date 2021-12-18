import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { Hero } from 'src/app/models/hero.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  listData: MatTableDataSource<Hero>;
  displayColumns: string[] = ['Name', 'Power', 'Strength', 'Intelligence', 'Stamina', 'actions'];
  isVisible: boolean = false;
  heroData: Hero[];
  hero: Hero;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.GetHeroes();
  }

  public GetHeroes() {
    this.apiService.GetHeroes('http://localhost:4201/api/heroes')
      .then((response: Hero[]) => {
        this.heroData = response;
        this.listData = new MatTableDataSource(response);
      });
  }

  public EvolveStats(value: Hero){
    let randomNumber = Math.floor((Math.random() * 50) + 1);
    this.apiService.EvolveHeroStats(`http://localhost:4201/api/heroes?statIncrease=${randomNumber}&hero=${value.Name}`, 'evolve')
    .then((response: Hero) => {
      this.isVisible = true;
      this.hero = response;
    });
  }

}
