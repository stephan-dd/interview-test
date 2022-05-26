import { Component, OnInit } from '@angular/core';
import { ApiService } from '../_services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes: any[];
  constructor(private apiService: ApiService,) { }

  ngOnInit() {
    this.LoadHeroes();
  }

  Evolve(name) {
    this.apiService.evolve('evolve', name).subscribe(
      response => {      
        console.log(response);
      },
      err => {
        console.log(err);
      }
    );
  }

  LoadHeroes() {
    this.apiService.getHeroes().subscribe(
      response => {      
        this.heroes = response;
      },
      err => {
        console.log(err);
      }
    );
  }
}
