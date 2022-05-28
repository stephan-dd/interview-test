import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-list',  
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  contacts: Contact[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts(): void {
    this.apiService.getContacts()
      .subscribe(contacts => this.contacts = contacts);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.apiService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

}
