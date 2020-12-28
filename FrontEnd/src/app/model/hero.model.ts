export interface HeroResponseModel {
  name: string;
  power: string;
  stats: Array<{'key': Stat, 'value': number}>
}

export enum Stat {
  Strength = 'strength',
  Stamina = 'stamina',
  Intelligence = 'intelligence'
}
