import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private APIUrl = "http://localhost:4201/api/heroes";

  private postValue: any = [];


  constructor(private http:HttpClient) { }

 
  getHeroList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);
  }


  postHero(thename:String, theaction:String ):Observable<any[]>
  {
    
    return this.http.post<any>(this.APIUrl+ "?name=" + thename + "&action=" + theaction , null );
  } 
}
