import { Stats } from "./stats";

export interface Hero {
    name: string
    power: string
    stats: Stats[]
    strength?: number
    stamina?: number
    intelligence?: number

}
