import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { IHero } from '../hero';

@Component({
  selector: 'hero-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  _heroes: IHero[] = [];
  _hero: IHero = null;
  _heroId: number = 1;
  _tempHeroes: IHero[] =[];

  constructor(private _apiService: ApiService) { }

  onEvolve()
  {
       this._apiService.evolveHero(1)
                           .subscribe((responseData: IHero)=>{
                             this._hero = responseData;
                             
                             this._tempHeroes.push(responseData);
                             this._heroes = this._heroes.map(x => this._tempHeroes.find(y => y.id === x.id)||x);
                             
                           });
       
  }

  ngOnInit() {
    this._apiService.getHeroes()
        .subscribe(data => this._heroes = data);
  }

}
