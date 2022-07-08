import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  contactsList: any;

  constructor(private apiService: ApiService) 
  { 
    this.getContacts();
  }

  ngOnInit() {
  }

  getContacts(){
    this.apiService.getContacts().subscribe((data: any) => {
      //log 
      console.log(data);
      this.contactsList = data
    });
  }

  evolve(){
    //evolve the object (NB: no ID)
    this.apiService.evolveContact().subscribe((data: any) => {
      //check response
      console.log(data)
    })
    
    //refresh the page
     this.getContacts();
  }

}
