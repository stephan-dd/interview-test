import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor(private http: HttpClient) {

   }

   apiUrl = environment.apiEndpoint;

   
   get(action: string) {
    let options = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    console.log(this.apiUrl + action);
    return this.http.get(this.apiUrl + action, options)
}

post(action: string, parameters: object) {
    console.log(parameters);
    let options = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    console.log(this.apiUrl);
    return this.http.post(this.apiUrl + action, JSON.stringify(parameters), options);
}
}
