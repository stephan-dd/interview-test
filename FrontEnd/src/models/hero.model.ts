import { HeroStats } from './hero-stats.model';

export class HeroModel {
    Name: string;
    Power: string;
    stats: HeroStats;

    deserialize(input: any){
        Object.assign(this, input);
        let obj = {};
        if(Array.isArray(input.stats))
        {
            input.stats.forEach((x) => {
                obj[x.key] = x.value;
            });
            this.stats = new HeroStats().deserialize(obj);
        }
        return this;
    }
}
