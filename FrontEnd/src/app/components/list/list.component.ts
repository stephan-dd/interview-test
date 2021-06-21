import { Component, OnInit } from '@angular/core';
import { HeroesModel } from 'src/app/model/heroesModel';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroesResults: HeroesModel;
  updatedStatResults: HeroesModel;


  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.onGetHeroesList();
  }

  onGetHeroesList(){
    this.apiService.getHeroes().subscribe( data =>{
      if(data){
        this.heroesResults = data;
      }
    }
    )
  }

  onUpdatesHeroName(name: string, evolve: string){
    this.apiService.updateHeroes(name, evolve).subscribe (data =>{
      if(data){
        this.updatedStatResults= data;
      }
    })
  }
}
