import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHero } from './Model/Heroes';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
    baseUrl = 'http://localhost:4201/api/heroes';
    Url = "http://localhost:4201/api/heroes?action=evolve";

    constructor(private http: HttpClient) { }

    getHeroes(): Observable<any>{
        return this.http.get(this.baseUrl)
            
           
    }
    evolve(): Observable<any> {
        return this.http.post(this.Url, null);
        }
}
