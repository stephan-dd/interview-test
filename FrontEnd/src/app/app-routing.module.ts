import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { ListComponentComponent } from './list-component/list-component.component';
 import { ListComponent } from './list/list.component';

const routes: Routes = [
  { path: '', redirectTo: 'heroes', pathMatch: 'full'},
  { path: 'heroes', component: ListComponent },
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
