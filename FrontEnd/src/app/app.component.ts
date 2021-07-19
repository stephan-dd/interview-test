import { Component, OnInit } from '@angular/core';
import { Hero } from './Hero/hero.model';
import { ListComponent } from './list/list.component';
import {ApiHttpService} from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
    title = 'frontend';  
    constructor() {}

   ngOnInit(){       
    }
   
}
