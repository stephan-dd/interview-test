import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _http: HttpClient) { 

  }

  /**
   * getContacts
   */
  public getContacts(): Observable<any> {
    return this._http.get<any>('http://localhost:4201/api/heroes')
  }

  public postContacts(): Observable<any> {
    return this._http.post<any>('http://localhost:4201/api/heroes',{})
  }
}