import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})

export class DataService{

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
