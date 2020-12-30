import { Component, OnInit } from '@angular/core';

import { timer } from 'rxjs/observable/timer';
import { AnonymousSubscription } from 'rxjs/Subscription';

import { Heroes } from '../heroes';
import { ApiService } from '../api.service'
import { from } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
   entries: Heroes[];
   loading: false;

   private timerSubscription: AnonymousSubscription;

  constructor( private apiService: ApiService) { }

  ngOnInit(): void {
    this.SubscribeToData();
  }

  SubscribeToData() {
    this.timerSubscription = timer(2000, 5000).subscribe(() => this.getHeroes())
  }

  getHeroes() {
    if(!this.loading) {
      this.apiService.getHeroesFromServer().subscribe(
        rows => this.entries = rows,
        (err) => console.error(err),
        () => this.finalize(this.entries));
    }
  }

  finalize(data) {
  }

   
}

