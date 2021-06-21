import { Api } from '../../services/api.service';
import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.compoent.html',
  styleUrls: ['./list.component.scss']
})
export class List implements OnInit {
  constructor (private _api: Api) { }

  loading: boolean = false;
  heroes: any[] = [];
  error: string = null;
  evolvedHero: any = null;

  ngOnInit(): void {
    this.loading = true;
    this._api.getHeroes().subscribe(
      results => {
        this.heroes = results;
        this.loading = false;
      },
      error => {
        console.log(error);
        this.error = `Couldn't get heroes`;
        this.loading = false;
      }
    );
  }

  getHeroStat = (statKey: string, stats: any[]) => stats.find(x => x.key == statKey).value;

  evolveHero = (hero: any) => {
    this._api.evovleHero(hero).subscribe(
      results => {
        this.heroes[this.heroes.indexOf(hero)].stats = results['stats'];
        this.evolvedHero = {
          name: results["name"], 
          stats: ""
        };
        results["stats"].forEach(stat => this.evolvedHero.stats += `${stat.key}: ${stat.value} `);
      },
      error => {
        this.evolvedHero = null;
        console.log(error);
        alert(`Couldn't evovle hero`);
      }
    );
  }

  randomColor = () => `color-${Math.floor(Math.random() * (4 - 1 + 1)) + 1}`;
}