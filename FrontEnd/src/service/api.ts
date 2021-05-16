import {Injectable} from '@angular/core'
import {Hero} from '../models/hero'
import {Action} from '../models/action'
import {HttpClient,HttpHeaders,HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
    providedIn:'root'
})

export class Api{

    constructor(private httpClient:HttpClient){}
    apiUrl = 'http://localhost:4201/api/heroes'
    

    
    getHeroes():Observable<any>
    {
        return this.httpClient.get(this.apiUrl);
    }

    heroesEvolved(action:Action):Observable<any>
    {
        return this.httpClient.post(this.apiUrl,action,{headers:new HttpHeaders({'Content-Type':'application/json; charset=utf-8'})})
    }

}