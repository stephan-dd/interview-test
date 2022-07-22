import { ApiService } from './../api.service';

export interface IStats{
  
    key: string;
    value: number

}

export interface IHeroes{
  name:string;
  power:string;
  stats: IStats[];  
}

export class Heroes
{
    Hero:[
        {
            name: string;
            power: string;
            stats: [
                {
                    key: string;
                    value: number;
                }
            ]
        }
    ];

    // name:string;
    // power:string;
    // stats: [
    //     {
    //     key:string;
    //     value:number;
    // },{
    //     key:string;
    //     value:number;
    // },{
    //     key:string;
    //     value:number;
    // }
// ]
}

