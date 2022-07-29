import { ApiService } from 'src/services/api';
import { Component } from '@angular/core';
import { Observable, forkJoin } from 'rxjs';
import { HeroModel } from 'src/HeroModel';

@Component({
    selector: './app-root',
    templateUrl: './list.component.html',
    styleUrls: ['./list.component.css']
})
export class listComponent {
    heroes: Observable<HeroModel[]>;
    constructor (private apiService: ApiService){

    }

    public AppInit(){
        this.getContact();
    }

    public getContact() : any{
        this.heroes = this.apiService.getContacts();
    }

    public evolveHero(){
        this.apiService
    }
}