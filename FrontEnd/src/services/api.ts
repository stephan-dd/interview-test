import {Injectable} from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { HeroModel} from 'src/HeroModel';
import { Options } from 'selenium-webdriver/chrome';


const baseAddress = 'http://localhost:4201/heroes';

@Injectable ()
export class ApiService {
    constructor(private http: HttpClient){

    }
    public heroes: Observable<HeroModel[]> = of([]);

    public getContacts() : Observable<HeroModel[]> {
        
        return this.http.get<HeroModel[]>(baseAddress);
    }

    public evolveHero(heroId: number) : Observable<HeroModel[]>{
        this.heroes = this.http.get<HeroModel[]>(baseAddress + '/evolve/' + heroId);
        return this.heroes;
    }
}