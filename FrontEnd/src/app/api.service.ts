import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private REST_API_SERVER = "http://localhost:4201/api";
  
  constructor(private httpClient: HttpClient ) { }

  public sendGetHeroes(){
    return this.httpClient.get(this.REST_API_SERVER + "/heroes");
  }
}
