import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:4201/api';
  
  constructor(private client: HttpClient) {
   }

  public getBaseUrl(): string {
    return this.baseUrl;
  }

  public addPath(path: string): string {
    return this.baseUrl + path;
  }

  public getClient(): HttpClient {
    return this.client;
  }

  public get(url: string): Observable<any[]> {
    return this.client.get<any[]>(url);
  }

  public post(url: string, body: any): Observable<any> {
    return this.client.post(url, body);
  }
}
