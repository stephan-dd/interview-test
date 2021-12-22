import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { GuideComponent } from './guide/guide.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [
  {path: 'app', component: AppComponent},
  {path: 'guide', component: GuideComponent},
  {path: 'heroes', component: ListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
