import { Component, OnInit } from '@angular/core';
import { IHero  } from '../Model/Heroes';
import { ApiService } from '../api.service';
import { Ievolve } from '../Model/Ievolve';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
   

    constructor(private apiService: ApiService) { }
    hero: IHero[];
 
    ngOnInit()
    {

        this.apiService
            .getHeroes()
            .subscribe
            (data =>
            {
                this.hero = data;
               
            }
        );
       

    }
    
    evolve() {
        this.apiService
            .evolve()
            .subscribe
            (data => {
                this.hero = data;

            }
            );

    }
    RandomColor() {
        var Randomcolor = Math.floor(0x1000000 * Math.random()).toString(16);
        return '#' + ('000000' + Randomcolor).slice(-6);
    }

}
