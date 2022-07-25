import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  apiURL = 'http://localhost:4201';

  constructor(private httpClient: HttpClient) { }

  getContacts(){
    return this.httpClient.get(`${this.apiURL}/heroes`);
  }

}
