import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from "@angular/common/http";
import { HeroesModel } from '../model/heroesModel';
import { HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private getContactsUrl = environment.interviewTestAPiBase;

  constructor(   private http: HttpClient) { }

  getHeroes(): Observable<HeroesModel> {
    // return this.http.get<HeroesModel>('assets/database/heroes.Database.json');
    return this.http
        .get<HeroesModel>(this.getContactsUrl);
 }

 public updateHeroes(name: string, evolve: string): Observable<any> {
   debugger;
  const httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*'
      })
  }
  const results = this.getContactsUrl + '/' + name + '?value='+ evolve;
  console.log('results', results);
  return this.http.post<any>(this.getContactsUrl + '/' + name + '?value='+ evolve, httpOptions);
}

}
