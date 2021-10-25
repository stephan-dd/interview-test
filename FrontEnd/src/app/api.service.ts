import {Injectable} from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable()
export class HeroService {

    private url = "http://localhost:4201/api/";
    constructor(private http:HttpClient) {}

    getHeroesApi() {
        return this.http.get(this.url + "heroes");
    }

    evolveHeroApi(name){
      return this.http.post(this.url + "heroes?name=" + name + "&action=evolve", {});
    }
}
