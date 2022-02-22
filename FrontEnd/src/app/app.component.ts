import { Component, OnInit  } from '@angular/core';
import {ApiService} from '../services/api.service'; 
import { Contactmodel } from './model/contactmodel';
import { HttpClient } from '@angular/common/http';
import { ListComponent } from './list/list.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
//export class AppComponent implements OnInit  {
export class AppComponent {
  title = 'frontend';

  contacts : Contactmodel[];  
  constructor(private apiserv : ApiService, private http: HttpClient){  
    //new ListComponent(apiserv,http);
    
  }  


  // ngOnInit() {  
  
  //   // Object data  
  //   console.log(this.contacts);  
  
  //   // Convert to JSON  
  //   this.stringifiedData = JSON.stringify(this.contacts);  
  //   console.log("With Stringify :" , this.stringifiedData);  
  
  //    // Parse from JSON  
  //   this.parsedJson = JSON.parse(this.stringifiedData);  
  //   console.log("With Parsed JSON :" , this.parsedJson);  
      
  // }  
}
