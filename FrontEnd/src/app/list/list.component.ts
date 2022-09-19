import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  public contacts: any = [];

  constructor(private service: ApiService) { }

  ngOnInit() {

    this.service.getContacts()
    .subscribe( (contacts)=>{
      this.contacts = contacts
      console.log(contacts)
    })
   
  }
  tableUpdated(){
    this.service.postContacts()
    .subscribe( (contacts)=>{
      this.contacts = contacts
    
    })

    
  }


  
  
 
}
