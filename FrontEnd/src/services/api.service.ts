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
  baseURL: string = "http://localhost:4201/api/heroes"; //Internal variable for API address

  //Get all contacts from API list and create an Observable Collection
  GetAllContacts(): Observable<Contactmodel[]> {  
    return this.http.get<Contactmodel[]>('http://localhost:4201/api/heroes').pipe(map(((res =>res))));  
  }  

  //POST method to 'evolve' on the API side (This works in POSTMAN, but not in code).
  evolve(contact:Contactmodel[]): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(contact);
    console.log(body)
    return this.http.post(this.baseURL + 'post', body,{'headers':headers})
  }
}


