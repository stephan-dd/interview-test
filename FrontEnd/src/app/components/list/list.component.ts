import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/models/hero';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes: Hero[] = [];
  
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes(): void {
    this.apiService.getHeroes().subscribe(heroes => this.heroes = heroes);
  }

}
