import { environment } from './../../environments/environment.prod';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})
export class BaseService {
  constructor(public _http: HttpClient){
    this.rootApi = `${environment.rootApi}`
  }
  private rootApi: string;

  public httpOptions: any = { headers: new HttpHeaders({ 'Contnent-Type': 'application/json'})};

  public urlBuilder(urlString: string, params: Object = null) :string {
    let url = `${this.rootApi}${urlString}`;
    let s = '?';

    if (params != null)
      Object.entries(params).forEach(([key, val]) => {
        if (val != null) {
          url = `${url}${s}${key}=${val}`;
          s = '$';
        }
      })
    
    return url;
  }
}