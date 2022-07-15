import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes() {
    this.apiService.getAllHeroes().subscribe(data => {
      console.log(JSON.stringify(data));
    });
  }

}
