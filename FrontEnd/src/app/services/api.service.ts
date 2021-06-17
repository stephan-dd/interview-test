import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Hero } from '../models/hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

   getHeroes(){
     return this.http.get<Hero[]>(this.baseUrl+'heroes');
   }

   updateHeroStats(hero:Hero){
       return this.http.post<Hero>(this.baseUrl+'Heroes',hero);
   }


}
