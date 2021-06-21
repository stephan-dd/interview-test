import { BaseService } from './base.service';
import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})
export class Api extends BaseService {
  getHeroes = () => this._http.get<any[]>(this.urlBuilder('heroes'));
  evovleHero = (hero: any) => this._http.post<any>(this.urlBuilder('heroes', {action: 'evolve'}), hero, this.httpOptions);
}