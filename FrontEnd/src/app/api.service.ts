import { Injectable} from '@angular/core'; 
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Hero } from './Hero/hero.model';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
  })
export class ApiHttpService { 
    private apiUrl = 'http://localhost:4201/api/heroes';


    constructor(private httpClient: HttpClient) { }
    heroes : Hero[] = [];    

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };  
    
    public get(){ 
       return this.httpClient.get<Hero[]>(this.apiUrl)
       .pipe(
           map(responseData => {
                const heroArray:Hero[] = [];
                for( const key in responseData){
                    if(responseData.hasOwnProperty(key)){
                        heroArray.push({ ...responseData[key]})                        
                    }
                }
            return heroArray;
            })
        );   
    } 

    public evolve(postData:{Id: any,Action: string}){
        return this.httpClient.post<Hero>(this.apiUrl ,postData);
    }    
   
}





