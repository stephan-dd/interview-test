import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-heroes-list',
  templateUrl: './heroes-list.component.html',
  styleUrls: ['./heroes-list.component.scss']
})
export class HeroesListComponent implements OnInit {

  public heroes;

  constructor(private _apiService: ApiService) { }

  ngOnInit() {
    this._apiService.getHeroes().subscribe((res) =>{
      this.heroes = res;
      console.log(this.heroes);
    })
  }

  public getStatValue(index: number, stat: string): string
  {
    if(this.heroes && this.heroes[index].stats){
      return  this.heroes[index].stats.find(x => x.key == stat).value;
    }

    return '';
  }

  public evolve(name: string)
  {
    alert(name);
    this._apiService.evolve(name).subscribe((res) => {
      console.log(res);
    })
  }

}
