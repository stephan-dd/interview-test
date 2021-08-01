import { Injectable } from '@angular/core';
import { HeroModel } from './hero.model';
import { HttpService } from './http.service';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor(private httpService: HttpService) { }

  route = 'http://localhost:4201/api/heroes';

  getHeroes = () => {
    return this.httpService.get(this.route).pipe(map(hero => hero as HeroModel));
  }

  evolveHero = (action: string) => {
    console.log(action);
    
    return this.httpService.post(this.route, action);
  }
}
