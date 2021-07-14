import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service'


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  title = '  Tour of Heroes'
  isEvolved: boolean = false;


  constructor(private apiService: ApiService) { };


  ngOnInit() {

  }

  getHeroes() {
    this.apiService.getHeroes().subscribe(
      heroes => {
        this.heroes = heroes;
      }
    );
  }

}

