import { HttpHeaders, HttpParams } from "@angular/common/http";

interface IConfig {
  url: string,
  body: any | null,
  options: {
    headers?: HttpHeaders | {[header: string]: string | string[]}
    observe?: 'body'
    params?: HttpParams | {[param: string]: string | string[]}
    reportProgress?: boolean
    responseType: 'json'
    withCredentials?: boolean
  }
}

interface IStatistics {
  key: string,
  value: string
}

interface IHero {
  id: string
  name: string;
  power: string;
  stats: IStatistics[];
}

export {
  IConfig,
  IHero
}