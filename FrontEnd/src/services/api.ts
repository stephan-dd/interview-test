import {Injectable} from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HeroModel} from 'src/HeroModel';
import { Options } from 'selenium-webdriver/chrome';


const baseAddress = 'http://localhost:4201/heroes';

@Injectable ()
export class ApiService {
    constructor(private http: HttpClient){

    }

    public getContacts() : Observable<HeroModel[]> {
        
        return this.http.get(baseAddress);
    }

    public evolveHero(heroId: number) : Observable<HeroModel>{
        let response = this.http.get(baseAddress + '/evolve/' + heroId);
        return response;
    }
}