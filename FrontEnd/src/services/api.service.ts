import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { map } from "rxjs/operators"; 
import { Contactmodel } from 'src/app/model/contactmodel';
import {Observable} from 'rxjs/Rx';

@Injectable()
export class ApiService
{
  constructor(private http: HttpClient) {  
  }
  baseURL: string = "http://localhost:4201/api/heroes";
  GetAllContacts(): Observable<Contactmodel[]> {  
    return this.http.get<Contactmodel[]>('http://localhost:4201/api/heroes').pipe(map(((res =>res))));  
  }  

  evolve(contact:Contactmodel[]): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(contact);
    console.log(body)
    return this.http.post(this.baseURL + 'post', body,{'headers':headers})
  }
}


