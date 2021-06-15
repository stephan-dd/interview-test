interface Statistic {
    key: string;
    value: number;
}

export interface Hero {
    name: string;
    power: string;
    stats: [Statistic]
}