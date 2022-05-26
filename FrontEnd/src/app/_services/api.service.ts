import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  baseUrl: string = 'http://localhost:4201/api/heroes';
  results: any;
  constructor(private http: HttpClient) {}

  evolve(name, action): Observable<any> {
    return this.http.post(this.baseUrl + '/post?name=' + `${name}&action=${action}`, httpOptions);
  }

  getHeroes(): Observable<any> {
    return this.http.get(this.baseUrl, httpOptions);
  }
}