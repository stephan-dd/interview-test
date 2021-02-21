import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
     url="http://localhost:4201/api/v1/hero/"

  constructor(private http:HttpClient) { }

  getheroes(method:string)
  {
    return this.http.get(this.url+method);
  }
}
