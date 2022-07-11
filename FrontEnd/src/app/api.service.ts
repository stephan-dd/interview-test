import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public GetHeroes()
  {
    return this.httpClient.get("http://localhost:4201/api/heroes");
  }

  public PostHero(name: string)
  {
  return this.httpClient.post("http://localhost:4201/api/heroes",name);
  }
}
