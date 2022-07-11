import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

interface  contacts {
  id: number;
  name : string;  
  power : string;  
  stats :
  {
      strength: number;
      intelligence: number;
      stamina: number;
  }
}

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  Hero: any = [];
  hero: any = [];
  showHeroUpdate = false;

  constructor(
    public apiService: ApiService,
    public actionRoute: ActivatedRoute,
    public router: Router,
    ) { }

  // Get heroes data
  ngOnInit() {
    this.apiService.getHeroes()
    .subscribe((data: {}) => {
        this.Hero = data;
      });
  }

  //EvolveHero
  evolve(name){
    if (window.confirm('Evolve Hero?')) {
      this.apiService.evolve(name, this.Hero).subscribe(data => {
        console.log(data);
        this.hero = data;
        this.showHeroUpdate = true;
        this.router.navigate(['/list']);
      });
    }
  }


  getRandomColor(RandomColor) {
    const color = Math.floor(0x1000000 * Math.random()).toString(16);
    return '#' + ('000000' + color).slice(-6);
  }

}
