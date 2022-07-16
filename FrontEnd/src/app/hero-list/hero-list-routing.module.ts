import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HeroListPage } from './hero-list.page';

const routes: Routes = [
  {
    path: '',
    component: HeroListPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HeroListPageRoutingModule {}
