import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Hero } from '../models/Hero';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
private enviPath = environment.apiURL + '/Heroes';
  constructor(private http: HttpClient) { }

  evolve(data: any) {
    return this.http.post(environment.apiURL + '/Heroes', data);
  }

  getHeroList() {
    return this.http.get(this.enviPath).toPromise();
  }

  getHeroByName(name): Observable<any> {
    return this.http.get(environment.apiURL + '/Heros' +  name); 
  }

}
