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

  heroContacts:Hero[]=[];

  constructor(private apiService : ApiService) { }

  ngOnInit(): void {
    this.setList();
  }



  setList(){

    // this.heroContacts = this.apiService.heroes;

    this.apiService.getHeroes().subscribe(
      (data:Hero[]) => {
        this.heroContacts = data;
    });
  }

  evolveHero(id){
      this.apiService.evolveHero(id);
  }

}
