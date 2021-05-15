import {Stats} from "./stats";

export interface Hero{
    name : string
    power : string
    stats : Stats[]
    intelligence?:number
    strength?:number
    stamina?:number

}