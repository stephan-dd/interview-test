import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'frontend';
  links = [
    // { 'path': '/', 'name': 'Home' },
    { 'path': '/heroes', 'name': 'Heroes' },
    { 'path': '/guide', 'name': 'Guide' }
  ]
}
