import { Component, OnInit } from "@angular/core";
import { Hero } from "../shared/models/hero.model";
import { ApiService } from "../shared/services/api.service";

@Component({
  selector: "app-list",
  templateUrl: "./list.component.html",
  styleUrls: ["./list.component.scss"],
})
export class ListComponent implements OnInit {
  hero: Hero;
  constructor(private service: ApiService) {}

  ngOnInit() {
    this.service.getHeroes();
  }

  evolve(name: string) {
    const action = "evolve";
    this.service
      .getHero(name, action)
      .subscribe((response) => (this.hero = response as Hero));
  }
}
