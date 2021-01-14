
import { Component } from '@angular/core';
import { ApiService } from './api.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private svc: ApiService) { }
  ngOnInit() { 

  }
  title = 'frontend';
}
