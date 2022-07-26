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
    
      this.getHero();
  }

  getHero(){
    this.dc.get('api/heroes/').subscribe((response)=>{
      this.model = response;
    });
  }

  evolveHero(name){
   
   this.dc.post('api/heroes?action=evolve',name).subscribe((response) => {
     if(response){
      this.hero = response;
      for(var i = 0; i < this.model.length; i++)
      {
        if(this.model[i].name == this.hero.name)
        {
          for(var j = 0; j < this.model[i].stats.length; j++ )
          {
            if(this.model[i].stats[j].Key === this.hero.stats[j].Key)
            {
              this.model[i].stats[j].Value = this.hero.stats[j].Value
            }
          }
        }
      }
     }
    this.heroUpdated = true;
   })
  }

}
