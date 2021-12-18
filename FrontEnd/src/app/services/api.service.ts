import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Hero } from '../models/hero.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

constructor(public httpClient: HttpClient) { }


public async EvolveHeroStats(url: string, info: string): Promise<Hero> {
  const requestInfo = JSON.stringify(info);
  return await this.httpClient.post<Hero>(url, requestInfo,
    {headers: new HttpHeaders().set('content-type', 'application/json')}).toPromise();
}

public async GetHeroes(url: string): Promise<Hero[]> {
  return await this.httpClient.get<Hero[]>(url,
    {headers: new HttpHeaders().set('content-type', 'application/json')}).toPromise();
}

}
