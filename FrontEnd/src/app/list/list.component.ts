import { Component, OnInit } from "@angular/core";
import { Hero } from "../classes/hero";
import { ApiService } from "../services/api.service";

@Component({
  selector: "app-list",
  templateUrl: "./list.component.html",
  styleUrls: ["./list.component.scss"],
})
export class ListComponent implements OnInit {
  heroes;
  isEvolveHero = false;

  colourClasses = ["blue", "green", "orange", "pink"];
  randomColour;
  constructor(public service: ApiService) {}

  ngOnInit() {
    this.getHeroes();
    this.getRandomClass();
  }

  getHeroes() {
    this.service.getHeroes().then((res) => {
      this.heroes = res as string[];
    });
  }

  evolveHero() {
    this.service.postEvolve(this.heroes).subscribe((res) => {
      console.log(res);
    });
    this.isEvolveHero = true;
  }

  getRandomClass() {
    this.randomColour = this.colourClasses[Math.floor(Math.random() * 4)];
    return this.randomColour;
  }
}
