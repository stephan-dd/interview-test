import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { HeroResponseModel, Stat } from '../../model/hero.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ListComponent implements OnInit {
  // Map response to display model because we dont
  // know what order the stats might be in
  heroesDisplayModel: Array<HeroDisplayModel> = [];

  // For the update message
  updatedMsgVisible = false;
  updatedHero: string;
  updatedStats: { [key in Stat]?: number } = {};

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.callHeroes();
  }

  // Get heroes and re-map result onto display object
  async callHeroes() {
    this.heroesDisplayModel = [];
    const heroesResponseList = await this.apiService.getHeroes();
    heroesResponseList.forEach((hero) => {
      // Map onto new display row here
      const newRow = {
        name: hero.name,
        power: hero.power
      }
      hero.stats.forEach(stat => {
        newRow[stat.key] = stat.value;
      });
      this.heroesDisplayModel.push(newRow);
    });
  }

  // On click of evolve button
  async doEvolve(name: string) {
    const hero: HeroResponseModel = await this.apiService.evolveHero(name, 'evolve');
    hero.stats.forEach(stat => {
      this.updatedStats[stat.key] = stat.value;
    });
    this.updatedHero = name;
    this.updatedMsgVisible = true;
  }
}

interface HeroDisplayModel {
  name: string,
  power: string,
  strength?: number,
  stamina?: number,
  intelligence?: number
}
