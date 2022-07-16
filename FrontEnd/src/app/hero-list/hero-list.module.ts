import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HeroListPageRoutingModule } from './hero-list-routing.module';

import { HeroListPage } from './hero-list.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HeroListPageRoutingModule
  ],
  declarations: [HeroListPage]
})
export class HeroListPageModule {}
