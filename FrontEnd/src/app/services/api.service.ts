import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { IHero } from '../types/interfaces';
import { IConfig } from '../types/interfaces';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

enum Action {
  None,
  Evolve
}

@Injectable({
  providedIn: 'root'
})

export class ApiService implements HttpInterceptor {

  config: IConfig = {
    url: `${environment.apiUrl}/api/Heroes`,
    body: null,
    options: {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json; charset=utf-8',
          'Access-Control-Allow-Origin': environment.corsOrigin,
          'ApiKey': environment.apiKey,
          'Access-Control-Allow-Methods': 'GET, POST',
          'Access-Control-Allow-Headers': 'Accept, Content-Type, Access-Control-Allow-Origin, Authorization',
        },
      ),
      observe: 'body',
      responseType: 'json',
    }
  }

  constructor(private http: HttpClient) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        Authorization: `Api-Key YOUR_KEY_HERE`
      }
    })
    return next.handle(req)
  }

  getHeroes() {
    return this.http.get<IHero[]>(this.config.url)
  }

  postHero(name: string, action: Action) {

    this.config.body = { name, action }

    return this.http.post<any>(this.config.url, this.config.body, this.config.options)
      .toPromise<IHero>().then(r => r)
  }
}
