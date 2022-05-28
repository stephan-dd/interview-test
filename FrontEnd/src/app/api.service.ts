import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { MessageService } from './message.service';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { Contact } from './contact';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:4201/api/heroes'; 

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.apiUrl)
      .pipe(
        tap(_ => this.log('contacts retrieved')),
        catchError(this.handleError<any>('getContacts()'))
      );
  }

  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact, this.httpOptions).pipe(
      tap((newHero: Contact) => this.log(`added contact w/ id=${newHero.id}`)),
      catchError(this.handleError<Contact>('addHero'))
    );
  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error); 
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    //this.messageService.add(`ContactService: ${message}`);
  }
}
