import { Component, OnInit  } from '@angular/core';
import {ApiService} from 'src/services/api.service'; 
import { Contactmodel } from '../model/contactmodel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

// export class ListComponent implements OnInit {
  export class ListComponent {
    contacts : Contactmodel[];  
    constructor(private apiserv : ApiService, private http: HttpClient)
    {   
      //Get API data and assign it to local variable 'contacts'
        this.apiserv.GetAllContacts().subscribe((contacts:Contactmodel[]) => {   
          this.contacts = contacts;  
        }); 
    }
    //#region Experimental Code (For reviewers curiosity)   
   
  // ngOnInit()
  // {

  //   // document.getElementsByClassName('namerow')[0].classList.add('color'+ getRndInteger(1,3));
  //   // document.getElementsByClassName('powerrow')[0].classList.add('color'+ getRndInteger(1,3));
  //   // document.getElementsByClassName('strengthrow')[0].classList.add('color'+ getRndInteger(1,3));
  //   // document.getElementsByClassName('intelligencerow')[0].classList.add('color'+ getRndInteger(1,3));
  //   // document.getElementsByClassName('staminarow')[0].classList.add('color'+ getRndInteger(1,3));
  //   // document.getElementsByClassName('editbtn')[0].classList.add('color'+ getRndInteger(1,3));
  //   // let eggcount = 20;
  //   // var html = 
  //   // '<table class="table table-striped" id="heroTable"><thead><tr><th>${eggCount}</th><th>Power</th><th>Stats (Strength)</th><th>Stats (Intelligence)</th><th>Stats (Stamina)</th><th>Evolve</th></tr></thead><tbody><tr *ngFor="let contact of contacts"><td class="color"${getRndInteger(1,4)} >{{ contact?.name }}</td><td class="color">{{ contact?.power }}</td> <td class="color">{{ contact.stats[0].value }}</td> <td class="color">{{ contact.stats[1].value }}</td> <td class="color">{{ contact.stats[2].value }}</td>  <td><button class="editbtn" (click)="Evolve();">Evolve</button></td> </tr></tbody></table></div>';

  //   // //
  //   // //document.getElementById('hello').innerHTML = html;
  //   // console.log("color" + getRndInteger(1,4));
 
  // }
    ngAfterViewInit(){
      console.log("Loaded");
      //randomizeTable();
    }
     //#endregion

    //Sends Post to evolve to API, does not refresh table data
    Evolve(){ 
      this.apiserv.evolve(this.contacts);
    }

    //Change HTML foreground color with switch statement
    getRandomColor(min, max) {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "color"+ randomint;
      console.log("Random Color # : " + randomVal);
      switch(randomVal){
        case "color1":
          return "White";
        break;

        case "color2":
          return "LightGreen";
        break;

        case "color3":
          return "Orange";
        break;
      }
    }
    //Change HTML background color with switch statement
    getBackgroundRandomColor(min, max) {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "color"+ randomint;
      console.log("Random Color # : " + randomVal);
      switch(randomVal){
        case "color1":
          return "Grey";
        break;

        case "color2":
          return "Black";
        break;

        case "color3":
          return "Purple";
        break;
      }
    }
    //Change HTML font-weight with switch statement
    getRandomFont(min, max) 
    {
      var randomint = Math.floor(Math.random() * (max - min)) + min;
      var randomVal = "font"+ randomint;
      console.log("Random Font # : " + randomVal);
      switch(randomVal)
      {
        case "font1":
          return '100';
        break;

        case "font2":
          return '150';
        break;

        case "font3":
          return '200';
        break;
      }
    }
  }
 




