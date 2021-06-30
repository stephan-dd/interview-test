export interface IHero {
  name: string;
  power: string;
  stats: IStats[];
  strength?: number;
  intelligence?: number;
  stamina?: number;
}

export interface IStats {
  key: string;
  value: number;
}

export interface IAction {
  heroName: string;
  action: string;
}
