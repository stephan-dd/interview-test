import { HttpErrorResponse } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IHero } from '../types/interfaces';
import { ApiService } from '../services/api.service';
import { Action } from '../types/enums';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  providers: []
})

export class ListComponent implements OnInit {
  heroes: IHero[] = []
  colours: string[] = ['colour-one', 'colour-two', 'colour-three', 'colour-four']
  updatedHero: IHero = undefined
  columns: string[] = ['Name', 'Power', 'Stat (strenght)', 'Stat (intelligence)', 'Stat (stamina)']
  rndColour: string = ""

  constructor(private apiService: ApiService) { }

  ngOnInit() {

    this.apiService.getHeroes()
      .pipe(
        catchError(this.handleError)
      )
      .subscribe((heroes: IHero[]) => {
        Object.assign(this.heroes, { ...heroes })
      })
      this.getRandomColour()
  }

  private postHero(hero: IHero) {
    this.apiService.postHero(hero.name, Action.Evolve).then(hero => {
      this.updatedHero = hero
    })
  }

  private getRandomColour() {
    let min = 0, max = 3
    this.rndColour = this.colours[Math.floor(Math.random() * (max - min + 1) + min)]
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }

}


