import { Component, OnInit } from '@angular/core';

import { timer } from 'rxjs/observable/timer';
import { AnonymousSubscription } from 'rxjs/Subscription';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import {DataSource} from '@angular/cdk/collections';

import { Hero } from '../api';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  dataSource = new DataHeroes(this.apiService);
  displayedColumns = ['name', 'power', 'stats', 'evolveAction'];

  constructor(private apiService: ApiService) { }
  
  ngOnInit() {
  }
}

export class DataHeroes extends DataSource<any> {
  constructor(private apiService: ApiService) {
    super();
  }
  connect(): Observable<Hero[]> {
    return this.apiService.getHeroesFromServer();
  }
  disconnect() {}

  /*entries: Hero[];
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
  }*/
}

