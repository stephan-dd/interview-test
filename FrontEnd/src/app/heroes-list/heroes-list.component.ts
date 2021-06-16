import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-heroes-list',
  templateUrl: './heroes-list.component.html',
  styleUrls: ['./heroes-list.component.scss']
})
export class HeroesListComponent implements OnInit {

  public heroes;
  public message = "";
  public Math = Math;

  constructor(private _apiService: ApiService) { }

  ngOnInit() {
    this._apiService.getHeroes().subscribe((res) => {
      this.heroes = res;
    })
  }

  public getStatValue(index: number, stat: string): string {
    if (this.heroes && this.heroes[index].stats) {
      return this.heroes[index].stats.find(x => x.key == stat).value;
    }

    return '';
  }

  public evolve(index: number, name: string): void {
    this._apiService.evolve(name).subscribe((res) => {
      if (res) {
        this.heroes[index].stats = res.stats;
        this.message = `${name} updated with stats Strength:${this.heroes[index].stats.find(x => x.key == 'strength').value} 
                        Intelligence:${this.heroes[index].stats.find(x => x.key == 'intelligence').value} 
                        Stamina:${this.heroes[index].stats.find(x => x.key == 'stamina').value}`;
      }
    })
  }
}
