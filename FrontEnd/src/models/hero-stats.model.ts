export class HeroStats {
    strength: number;
    stamina: number;
    intelligence: number;

    deserialize(input: any){
        Object.assign(this, input);
        return this;
    }
}
