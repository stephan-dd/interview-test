import { Component, OnInit } from "@angular/core";
import { IAction, IHero } from "../interface/IHero.interface";
import { ApiService } from "../service/api.service";

@Component({
  selector: "app-list",
  templateUrl: "./list.component.html",
  styleUrls: ["./list.component.scss"],
})
export class ListComponent implements OnInit {
  heroes: IHero[];
  heroEvolved: IHero;
  heroColours = ["green", "orange", "blue", "purple"];
  heroColour: string;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.getHeroList();
    this.setHeroColours();
  }

  /**
   * Retrieve a list of the Heroes from the backend
   */
  private getHeroList() {
    this.apiService.getHeroInformation().subscribe((result) => {
      this.heroes = result;
      this.heroes.forEach((hero) => this.setHeroStats(hero));
    }),
      (err) => {
        console.log(err);
      };
  }

  /**
   * Evolve the stats of the selected hero
   * @param name - Name of the hero
   * @param action - The relevat action to take
   */
  OnEvolveClick(hero: IHero, action: string) {
    const body: IAction = {
      heroName: hero.name,
      action: action,
    };
    let currentHero = this.heroes.findIndex((h) => h.name === hero.name);
    this.apiService.updateHeroStats(body).subscribe((result) => {
      this.heroes[currentHero] = this.setHeroStats(result);
      this.heroEvolved = result;
    }),
      (err) => {
        console.log(err);
      };
  }

  /**
   * Set each hero's stats.
   */
  private setHeroStats(hero: IHero) {
    hero.stats.forEach((stat) => {
      let statsKey = stat.key.toLowerCase();
      if (statsKey === "strength") {
        hero.strength = stat.value;
      } else if (statsKey === "intelligence") {
        hero.intelligence = stat.value;
      } else if (statsKey === "stamina") {
        hero.stamina = stat.value;
      }
    });
    return hero;
  }

  /**
   * Sets a random colour to the list on page load.
   */
  setHeroColours() {
    let index = Math.floor(Math.random() * this.heroColours.length);
    this.heroColour = this.heroColours[index];
  }
}
