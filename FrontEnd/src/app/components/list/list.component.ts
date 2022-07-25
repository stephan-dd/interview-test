import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  myDataList;

  constructor(private api: ApiService) { }

  ngOnInit(): void {

    this.getList();

  }

getList(){
  this.api.getContacts().subscribe( 
    (res) =>{

      this.myDataList = res["data"];

    }

  )
}

}
