import { Component, OnInit  } from '@angular/core';
import {ApiService} from 'src/services/api.service'; 
//import { Contactmodel } from '../model/contactmodel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';


interface  Contactmodel {
  name : string;  
  power : string;  
  stats :
  {
      strength: number;
      intelligence: number;
      stamina: number;
  }
}

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

export class ListComponent implements OnInit {
  contacts : Contactmodel[];  
  stringifiedData: any;  
  parsedJson: any;    
  objectKeys : Object;
  data = [{"status":57}];
  constructor(private apiserv : ApiService, private http: HttpClient)
  {  
      console.log(this.contacts);  
      this.apiserv.GetAllContacts().subscribe((contacts:Contactmodel[]) => {   
        this.contacts = contacts;  
        this.objectKeys = Object.keys(contacts);
      }); 
  }

  public contacts2: any = this.apiserv.GetAllContacts();
  ngOnInit(): void
  {
  }

  typeToString(value: any[]){
    console.log("Original : " + value);
    this.stringifiedData = JSON.stringify(value);
    this.parsedJson = JSON.parse(this.stringifiedData);  
    console.log("Parsed : " + this.parsedJson);
    return this.parsedJson;
  }

  Evolve(){ 
    this.apiserv.evolve(this.contacts);
  }

  // this.http.post<any>('http://localhost:4201/api/heroes/post', { title: 'Angular POST Request Example' }).subscribe(data => {
  // })
 

}



