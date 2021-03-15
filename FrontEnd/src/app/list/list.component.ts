import { Component, OnInit } from '@angular/core';
import {ApiService} from '../api.service'

@Component({
  selector: 'list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public heroes:any = [];

  public updatedheroes:any = [];
  public hero:any;
  public updated: boolean = false;


//********************Random color selection */
  public randomenumber:any = Math.floor(Math.random() * 4);
  public randomclasses = ["randomeclass1", "randomeclass2", "randomeclass3", "randomeclass4"];
  public selectedclass = this.randomclasses[this.randomenumber];


  //Post parameters
  public action:string= "";
  public heroname:String="";


  constructor(private _employeeservice: ApiService) { }

  ngOnInit(): void {
    this._employeeservice.getHeroList().subscribe(data=> this.heroes = data);   

  }

  //****************evolve button click handler */
  evolvehero(hero:any)
  {
    this.heroname = hero.name;
    this.action = "evolve"
    this._employeeservice.postHero(this.heroname, this.action).subscribe(data => this.updatedheroes = data);
    //this.hero = this.updatedheroes[0];
    this.updated = true;
  }

}


