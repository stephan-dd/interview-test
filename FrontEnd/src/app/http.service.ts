import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  
  constructor(private httpService: HttpClient) { }

  public get = (route: string) =>{
    return this.httpService.get(route);
  }


  public post = (route: string, payload: string) => {
    const httpOptions = {
      headers: new HttpHeaders({
        'content-type':  'application/json'        
      }) 
    } 
    return this.httpService.post(route, payload);
  }

}
