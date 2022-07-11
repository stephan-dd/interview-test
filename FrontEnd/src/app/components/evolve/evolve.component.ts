import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-evolve',
  templateUrl: './evolve.component.html',
  styleUrls: ['./evolve.component.scss']
})
export class EvolveComponent implements OnInit {

  // tslint:disable-next-line:no-string-literal

  id = this.actionRoute.snapshot.params['id'];
  Hero: any = {};

  constructor(
    public apiService: ApiService,
    public actionRoute: ActivatedRoute,
    public router: Router,
  ) { }

  ngOnInit() {
    this.apiService.getHeroes()
    .subscribe((data: {}) => {
        this.Hero = data;
      });
  }

  // Evolve hero data
  evolve() {
    if (window.confirm('Evolve Hero?')) {
      this.apiService.evolve(this.id, this.Hero).subscribe(data => {
        this.router.navigate(['/list']);
      });
    }
  }
}
