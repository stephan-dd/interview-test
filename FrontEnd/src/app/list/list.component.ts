import { Component, OnInit  } from '@angular/core';
import {ApiService} from 'src/services/api.service'; 
import { Contactmodel } from '../model/contactmodel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Hero } from '../hero';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

// export class ListComponent implements OnInit {
  export class ListComponent {
    heroes: Hero[] = []; 
    evolveHero: Hero;
    constructor(private apiserv : ApiService, private http: HttpClient){}


    ngOnInit() {
      this.getHeroes();
    }

    getHeroes(): void {
      this.apiserv
        .GetAllHeroes()
        .subscribe(heroes => (this.heroes = heroes));
    }

    EvolveHero(hero: Hero) {
      this.evolveHero = hero;
  
      this.evolveHero.action = "action";
  
      if (this.evolveHero) {
        this.apiserv
          .evolve(this.evolveHero)
          .subscribe(hero => {
              //Get the selected hero and then update the values, after that update evolveHero to reflect the changes
              const heroSelectedIndex = this.heroes.findIndex(h => h.name === hero.name);
              this.heroes[heroSelectedIndex] = hero;
              this.UpdateHeroEvolved(hero); // Show which hero evolved on top of the table.
            });
      }
    }
      //When a Hero has evolved it displays it at the top of the Table, generating 'innerHTML' values.
    UpdateHeroEvolved(hero: Hero): void{
      this.evolveHero = hero;
      document.getElementById("evolvedHeroInfo")
        .innerHTML = `${this.evolveHero.name} updated to = 
                      ${this.evolveHero.stats[0].key} : ${this.evolveHero.stats[0].value}, 
                      ${this.evolveHero.stats[1].key} : ${this.evolveHero.stats[1].value}, 
                      ${this.evolveHero.stats[2].key} : ${this.evolveHero.stats[2].value}`;
    }


    //Change HTML foreground color with switch statement
    getRandomColor(min, max) {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "color"+ randomint;
      console.log("Random Color # : " + randomVal);
      switch(randomVal){
        case "color1":
          return "White";
        break;

        case "color2":
          return "LightGreen";
        break;

        case "color3":
          return "Orange";
        break;
      }
    }
    //Change HTML background color with switch statement
    getBackgroundRandomColor(min, max) {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "color"+ randomint;
      console.log("Random Color # : " + randomVal);
      switch(randomVal){
        case "color1":
          return "Grey";
        break;

        case "color2":
          return "Black";
        break;

        case "color3":
          return "Purple";
        break;
      }
    }
    //Change HTML font-weight with switch statement
    getRandomFont(min, max) 
    {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "font"+ randomint;
      console.log("Random Font # : " + randomVal);
      switch(randomVal)
      {
        case "font1":
          return '100';
        break;

        case "font2":
          return '150';
        break;

        case "font3":
          return '200';
        break;
      }
    }
  }
 




