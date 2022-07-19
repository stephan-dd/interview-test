import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  async getContacts() {
    const req = this.http.get(environment.apiURL);
    const result = await lastValueFrom(req);
    return result;
  }

  async postContact(name: string) {
    const req = this.http.post(environment.apiURL, {
      value: 'evolve',
      name: name,
    });
    const result = await lastValueFrom(req);
    return result;
  }
}
