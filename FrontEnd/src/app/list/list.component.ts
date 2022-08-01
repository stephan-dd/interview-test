import { Component, OnInit } from "@angular/core";
import { Hero } from "src/models/hero.model";
import { HeroService } from "src/services/api.service";

@Component({
  selector: "app-list",
  templateUrl: "./list.component.html",
  styleUrls: ["./list.component.scss"],
})
export class ListComponent implements OnInit {
  heroes: Hero[] = [];

  evolvedHero: Hero | null = null;

  constructor(private heroService: HeroService) {}

  ngOnInit () {
    const result = this.heroService.getHeroes();
    result.subscribe((data) => (this.heroes = data));
  };

  EvolveHero = (name: string) => {
    this.heroService.evovleHero(name).subscribe((data) => {
      this.evolvedHero = data;
    });
  };

  getTheme = (index:number) => {
    return `theme${(index % 4)+1}`;
  };
}
