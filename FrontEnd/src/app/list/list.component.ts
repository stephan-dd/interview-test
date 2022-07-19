import { ApiService } from './../services/api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  contacts: any[] = [];
  htmlToAdd = '';
  myClasses: string[] = ['cc1', 'cc2', 'cc3', 'cc4'];
  myRandomClass = this.myClasses[this.getClass()];

  constructor(private apiServ: ApiService) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.apiServ.getContacts().then((contacts: any) => {
      this.contacts = contacts;
    });
  }

  onEvolve(contact: any) {
    this.apiServ.postContact(contact).then((resp: any) => {
      let stats = '';
      resp.stats.forEach((elm: any) => {
        stats += elm.key + ': ' + elm.value + ' ';
      });

      let myHtml = `<p>${resp.name} updated with ${stats}</p>`;
      this.htmlToAdd += myHtml;
    });
  }

  getClass() {
    return Math.floor(Math.random() * 4);
  }
}
