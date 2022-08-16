import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-hero-evolve',
  templateUrl: './hero-evolve.component.html',
  styleUrls: ['./hero-evolve.component.scss']
})
export class HeroEvolveComponent implements OnInit {
  // tslint:disable-next-line:no-string-literal
  id = this.actRoute.snapshot.params['id'];
  heroData: any = {};

  constructor(
    public restApi: ApiService,
    public actRoute: ActivatedRoute,
    public router: Router
  ) {
  }

  ngOnInit() {
    this.restApi.getHero(this.id).subscribe((data: {}) => {
      this.heroData = data;
    });
  }

  // Update hero data
  evolveHero() {
    if (window.confirm('Are you sure, you want to evolve?')) {
      this.restApi.evolveHero(this.id, this.heroData).subscribe(data => {
        this.router.navigate(['/list']);
      });
    }
  }
}
