import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { Hero } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  heroContacts: Hero[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.setList();
  }

  setList() {
    this.apiService.getHeroes().subscribe(
      (data: Hero[]) => {
        this.heroContacts = data;
      });
  }

  evolveHero(id: number) {
    this.apiService.evolveHero(id);
  }
  getRandomColor(RandomColor: any) {
    const color = Math.floor(0x1000000 * Math.random()).toString(16);
    return '#' + ('000000' + color).slice(-6);
  }

}
