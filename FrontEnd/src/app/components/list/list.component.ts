import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/app/models/hero';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  heroes: Hero[] = [];
  message: string;
  randomClass: string;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getRandomClass();
    
    this.apiService.getContacts().subscribe(data => {
      this.heroes = data;
    });
  }

  evolve(hero: Hero) {
    let evolvedHero;
    let stats = '';

    this.apiService.evolve(hero).subscribe(data => {
      evolvedHero = data;

      evolvedHero.stats.forEach(item => {
        stats += item.key + ': ' + item.value + ', '; 
      });
  
      stats = stats.trim().slice(0, -1);
  
      this.message = evolvedHero.name + ' updated with ' + stats;
    });
  }

  getRandomClass() {
    let classes = ['green', 'red', 'purple', 'yellow'];

    this.randomClass = classes[Math.floor(Math.random()*4 | 0)];
  }
}
