import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';


@Injectable({
 providedIn: 'root'
})



export class HeroService {

  private appUrl = "http://localhost:4201/api/heroes";

  constructor(private _httpClient: HttpClient){

  }
  /**
   * Get Hero
   *
   **/
  getHero(){
    return this._httpClient.get(this.appUrl);
  }

  postHero(){

  }

}
