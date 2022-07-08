import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  readonly APIURL = ' http://localhost:5000/api/heroes';
  constructor(private http: HttpClient) { }

  //get contacts from endpoint: http://localhost:4201/heroes
  getContacts(){
    return this.http.get(
      this.APIURL + '/get'
    );

  }

  evolveContact(){
  const headers = new HttpHeaders();
   headers.append('Content-Type', 'application/json');
   headers.append('Accept', '*/*');

    var body = 'evolve';

    return this.http.post(
      this.APIURL + '/post', body
    )}
}
