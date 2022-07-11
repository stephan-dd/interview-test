import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {

  Heroes;

  constructor(private apiService:ApiService) { }

  ngOnInit(): void 
  {
      this.getHeroes();
  }

  getHeroes()
  {
      return this.apiService.GetHeroes().subscribe((data)=>
      {
        console.warn(data);
        this.Heroes = data;
      });
  }

  onEvolve(name:string)
  {
    this.apiService.PostHero(name);
    console.warn(name);
  }
}
