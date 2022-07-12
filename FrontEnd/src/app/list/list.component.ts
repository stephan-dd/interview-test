import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroesList: any;
  name: string;
  myclass: string;
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getHeroes().subscribe((data) => {
      console.log(data);
      this.heroesList = data;
      this.name = '';
      this.myclass = 'style-0';
    });
  }

  evolve(name, index) {
    console.log(name);
    this.apiService.evolve(name).subscribe((data) => {
      console.log(data);
      this.removeAndAddItem(data, index);
    });
  }

  removeAndAddItem(hero: any, i: number) {
    this.heroesList.forEach((value, index) => {
      if (value.name == hero.name) {
        this.heroesList.splice(index, 1); //remove
        //this.heroesList.push(hero); // add
        this.heroesList.splice(i, 0, hero); // add
        this.name = hero.name;
        this.myclass = 'style-' + index;
      }
    });
  }

  reset(){
    this.ngOnInit();
  }
}
