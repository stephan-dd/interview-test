import * as internal from "assert";

export interface IHero {
    id: number;
    name: string;
    power: string;
    stats:
        [
            {
                key: string, 
                value: number   
            }
        ]      
  }