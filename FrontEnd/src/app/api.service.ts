import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from './hero';  

@Injectable({
  providedIn: 'root'
})




export class ApiService {
  url = 'http://localhost:4200/Api/Hero';
  constructor(private http: HttpClient) { }
  getAllHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.url + '/AllHeroDetails');
  }


  getContact(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.url + '/heroes');
  }




}
