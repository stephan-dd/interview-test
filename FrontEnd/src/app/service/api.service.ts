import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";
import { IHero, IAction } from "../interface/IHero.interface";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  heroes: Observable<IHero[]>;

  constructor(private http: HttpClient) {}

  getHeroInformation() {
    return this.http.get<IHero[]>(environment.mainApi + "/api/heroes");
  }

  updateHeroStats(action: IAction): Observable<any> {
    let headers: any = new HttpHeaders({ "Content-Type": "application/json" });
    const options = { headers: headers };
    return this.http.post<IHero>(
      environment.mainApi + "/api/heroes",
      action,
      options
    );
  }
}
