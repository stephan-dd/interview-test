import { Component, OnInit } from '@angular/core';
import { ApiService } from '../service/api.service'


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  title = '  Tour of Heroes'
  heroes: any[];



  constructor(private apiService: ApiService) { };


  ngOnInit() {
    this.getHeroes()
  }

  getHeroes() {
    this.apiService.getHeroes().subscribe(
      response => {
        this.heroes = response;
        console.log(response);
      }

    );
  }

}

