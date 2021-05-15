import { Component } from '@angular/core';
import {Api} from 'src/service/api'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
 
})
export class AppComponent {
  title = 'frontend';

  constructor(private api:Api ) {
   
  }

  ngOnInit() {
  }
}
