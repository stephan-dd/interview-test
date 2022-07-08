import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [
  // {
  //   path: '',
  //   component: AppComponent
  // },
  { 
    path: 'list', 
    component: ListComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    useHash: true
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
