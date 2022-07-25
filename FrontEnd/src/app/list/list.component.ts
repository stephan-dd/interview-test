import { Component, OnInit } from '@angular/core';
import{DataService} from '../service/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  model: any;
  hero: any;
  heroUpdated: boolean = false;
  constructor(public dc: DataService) { }

  ngOnInit() {
    if(!this.model){
      this.getHero();
    }
   
  }

  getHero(){
    this.dc.get('api/heroes/').subscribe((response)=>{
      console.log(response);
      this.model = response;
    });
  }

  evolveHero(name){
   console.log(name); 
   
   this.dc.post('api/heroes?action=evolve',name).subscribe((response) => {
     console.log(response);
     if(response){
      this.hero = response;
     }
    
    this.heroUpdated = true;
   })
  }

}
