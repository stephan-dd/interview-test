import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { map } from "rxjs/operators"; 
import { Contactmodel } from 'src/app/model/contactmodel';
import {Observable} from 'rxjs/Rx';
import { Hero } from 'src/app/hero';

@Injectable({
  providedIn: 'root'
})
export class ApiService
{
  
  baseURL: string = "http://localhost:4201/api/heroes"; //Internal variable for API address

  constructor(private http: HttpClient) {  } 

  //Get all contacts from API list and create an Observable Collection
  GetAllHeroes(): Observable<Hero[]> {  
    return this.http.get<Hero[]>('http://localhost:4201/api/heroes').pipe(map(((res =>res))));  
  }  

  //POST method to 'evolve' on the API side (This works in POSTMAN, but not in code).
  evolve(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.baseURL, hero)
  }
}


