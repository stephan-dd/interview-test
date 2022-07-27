import { element } from 'protractor';
import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';
import { IHeroes } from './classes';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})  

export class ListComponent implements OnInit {

  title = "Tour of Heroes";
  
  hero : IHeroes[];
  objHero : IHeroes[];
  oBody : any;
  public evolverHero = false;

  constructor(private service: ApiService) {}

  ngOnInit() {
    //get    
    this.displayHero();
    this.random();
  }

  displayHero():any {
    this.service.getHeroes().subscribe(
      result => {
        this.hero = result;
        const body = result;
        console.log(body);        
      }
    );
  }

  evolve(): any {

    this.oBody = {
      "name": "Hulk",
      "power": "Strength from gamma radiation",
      "stats": [
          {
              "key": "strength",
              "value": 5000
          },
          {
              "key": "intelligence",
              "value": 50
          },
          {
              "key": "stamina",
              "value": 2500
          }
      ]
  };

  console.log(this.oBody);
    this.service.postEvolve(this.oBody).subscribe(
        (response) =>{
        console.log(response);
        this.objHero = response;
        this.displayHero();
      }
    );

    this.evolverHero = true;
  }

  random(): any
  {
    let min = 1;
    let max = 4
    var index = Math.floor(Math.random()* (max - min + 1) + min)
    
    //console.log("r"+index);
    return "r"+ index;
  }
}
