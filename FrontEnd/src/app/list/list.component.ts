import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "../api.service";


@Component({
  selector: "app-list",
  templateUrl: "./list.component.html",
  styleUrls: ["./list.component.scss"],
})
export class ListComponent implements OnInit {
  public contacts: any = [];

  constructor(private service: ApiService) {}

  ngOnInit() {
    this.service.getContacts().subscribe((contacts) => {
      this.contacts = contacts;
    });
  }
  tableUpdated() {
    this.service.postContacts().subscribe((contacts) => {
      this.contacts = contacts;
    });
  }

  getRandomColor2() {
    var rendom = Math.floor(Math.random() * (Math.floor(3) - Math.ceil(0)) + Math.ceil(0));
    var colors = ["class1", "class2", "class3", "class4"];
    console.log(colors[rendom]);
    return colors[rendom];
  }
}
