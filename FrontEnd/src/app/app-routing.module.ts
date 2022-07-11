import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EvolveComponent } from './components/evolve/evolve.component';
import { ListComponent } from './components/list/list.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'list',
  },
  {
    path: 'components/list',
    component: ListComponent
  },
  {
    path: 'evolve/:name',
    component: EvolveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
