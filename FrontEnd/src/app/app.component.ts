import { Component, NgModule } from '@angular/core';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


@NgModule({
  declarations: [
    ListComponent
  ]
})
export class AppComponent {
  title = 'frontend';
}
