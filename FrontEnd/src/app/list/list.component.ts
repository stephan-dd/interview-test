import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroes : any;
  message : string;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes(): void {
    this.apiService.getHeroes().subscribe(data => {
      this.heroes = data;
    });
  }

  evolveHero(hero) {
    this.apiService.evolveHero(hero).subscribe(data => {
      var objIndex = this.heroes.findIndex((x => x.id == data.id));

      //calculating the difference between the stats to display on the front end
      this.message = data.name + " updated with" + " +" + (data.stats[0].value - this.heroes[objIndex].stats[0].value) + " strength, +" + (data.stats[1].value - this.heroes[objIndex].stats[1].value) + " intelligence, +" + (data.stats[2].value - this.heroes[objIndex].stats[2].value) + " stamina." 

      //updating the data
      this.heroes[objIndex] = data;

    });
  }

}
