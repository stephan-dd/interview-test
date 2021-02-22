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
  value:number=0;
  lblclass:string="";
  constructor(private apidata:ApiService) { }

  ngOnInit() {
    
    this.apidata.getheroes("AllHeroes").subscribe(
      result=>{
     this.datasourceHeroes=result;
    },error=>{
      console.log(error);
    })
    this.getRandomColor();
    console.log(this.value);
  }

  getRandomColor(){
     this.value=Math.floor(Math.random()*3);

    if(this.value==0)
    {
      this.lblclass="first";
    }
    else if(this.value==1)
    {
      this.lblclass="second";
    }if(this.value==2)
    {
      this.lblclass="third";
    }
    else if(this.value==3)
    {
      this.lblclass="fourth";
    }
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
