import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable()

export class DataService{

    constructor(private http: HttpClient) {

    }
    apiUrl = environment.apiEndpoint;

    get(action: string, params: HttpParams) {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            }), params: params
        };
        console.log(this.apiUrl + action);
        return this.http.get(this.apiUrl + action, options)
    }

}
