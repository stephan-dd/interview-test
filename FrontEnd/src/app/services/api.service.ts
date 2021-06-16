import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})
export class ApiService {

    constructor(private _http: HttpClient) { }

    getHeroes(): Observable<any> {
        return this._http.get<any>(`${environment.url}/heroes`);
    }

    evolve(name: string): Observable<any> {
        const headers = new HttpHeaders().set('content-type', 'application/json');
        return this._http.post(`${environment.url}/heroes/evolve/${name}`, "'evolve'", { headers });
    }
}
