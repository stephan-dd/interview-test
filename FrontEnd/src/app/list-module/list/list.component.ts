import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  datasourceHeroes;
  evolve:Boolean=false;
  constructor(private apidata:ApiService) { }

  ngOnInit() {
    this.apidata.getheroes("AllHeroes").subscribe(
      result=>{
     this.datasourceHeroes=result;
    },error=>{
      console.log(error);
    })
  }

  evolveclick()
  {
    this.evolve=true;
    this.apidata.getheroes("EvolveAllHeroes?evolve="+this.evolve).subscribe(
      result=>{
        this.datasourceHeroes=result;
        this.evolve=false;
      },
      error=>{
        console.log(error);
      }
    )
  }

}
