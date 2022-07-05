import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private webApi = 'http://localhost:4201/api/heroes'; 

  constructor(private http: HttpClient) { }

  
}
