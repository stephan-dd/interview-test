import { Component, OnInit } from '@angular/core';
import ApiService from '../service/api.service'

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  title = '  Tour of Heroes'
  heroes: any[] = [];
  evolvedHero: any = null;

  error: string;

  constructor(private apiService: ApiService) { };


  ngOnInit() {
    this.getHeroes()
  }

  getHeroes() {
    this.apiService.getHeroes().subscribe(
      response => {
        this.heroes = response;
      },
      error => {
        console.log(error);
        this.error = `Failed to get heroes -> ${error.statusText}`
      }
    );
  }

  getStats = (statKey: string, stats: any[]) => stats.find(h => h.key == statKey).value;
  evolveHero = (hero: any) => {
    this.apiService.evolveHero(hero).subscribe(
      (result: any) => {
        var indexHero = this.heroes[this.heroes.indexOf(hero)].stats = result['stats'];
        console.log(indexHero)
        var statsEvolved =
          this.evolvedHero = {
            name: result["name"],
            stats: ""
          };
        console.log(statsEvolved)
        var passResult = result["stats"].forEach(stat => this.evolvedHero.stats += `${stat.key}: ${stat.value} `);
        console.log(passResult)
      },
      error => {
        console.log(error);
        alert(`Couldn't evovle hero  ${error.statusText}`);
      }
    );
  }

  randomColor = () => {
    const color = ['first', 'second', 'third', 'fourth'];
    return color[Math.floor(Math.random() * (4 - 1 + 1)) + 1];
  }
}

