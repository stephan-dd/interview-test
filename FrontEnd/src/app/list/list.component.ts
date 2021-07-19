import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit, EventEmitter, Output} from '@angular/core';
import { $ } from 'protractor';
import {ApiHttpService} from '../api.service';
import { Hero } from '../Hero/hero.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  providers: [
      ApiHttpService
    ]
})
export class ListComponent implements OnInit {
    postData: {Id:number, Action:string} = {Id:-99, Action:'test'};    
    heroes : Hero[] = []; 
    public lastUpdatedHero: Hero = new Hero("","",null);    
    public hasLastUpdated :boolean = false;
    public showLoader:boolean = false;
    public themeId:number = -99;
    constructor(private service: ApiHttpService) { }
  
    ngOnInit(){
        this.themeId =Math.floor((Math.random()*4) + 1);
        this.showLoader = true;
        this.getHeroes(); 
    }

    getHeroes(){
        this.heroes = [];
        this.service.get()
        .subscribe(posts => {
            this.heroes = posts;
            this.lastUpdatedHero = this.heroes.find(h  => h.lastUpdated === true);   
            if(this.lastUpdatedHero.name !== "")
            {
                this.hasLastUpdated = true;
                this.showLoader = false;
            } 
        });
    }

    evolveHero(postData :{Id: number,Action: string}){
        this.service.evolve(postData).subscribe();    
        setTimeout(() => this.ngOnInit(),500);
    }

    evolveChosenHero(idVal: number, actionVal: string){    
        this.clearPrevPostData();    
        this.postData.Id = idVal;
        this.postData.Action = actionVal;
        this.evolveHero(this.postData);
    }

    clearPrevPostData(){
        this.postData.Action = null;
        this.postData.Id = null;
    }  
    
}



