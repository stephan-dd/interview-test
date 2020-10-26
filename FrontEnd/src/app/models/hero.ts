export class Hero {
    constructor(name: string, power: string, stats: {key: string, value: number}[]) {
        this.name = name;
        this.power = power;
        this.stats = stats
    }

    name: string;
    power: string;
    stats:{key: string, value: number}[];
}



