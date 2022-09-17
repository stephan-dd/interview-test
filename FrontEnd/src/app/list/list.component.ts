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

  constructor(private _apiService: ApiService) { }

  ngOnInit() {
    this._apiService.getContacts()
    .subscribe( (contacts)=>{
      this.contacts = contacts
      console.log(contacts)
    })
  }
  updateTable(){
    this._apiService.postContacts()
    .subscribe( (contacts)=>{
      this.contacts = contacts
    })

  }
}
