import { StaticSymbolCache } from "@angular/compiler";

export interface KeyValuePair{
    key:string;
    value:number;
}

export class Hero{
    public lastUpdated: boolean;
    public id?:string;
    public name:string;
    public power:string;
    public stats: KeyValuePair[];
    constructor( heroName: string, heroPower:string, stats: KeyValuePair[])
    {
        this.name = heroName;
        this.power = heroPower;
        this.stats = stats;
    }    
}

