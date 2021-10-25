import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { List } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeroService } from './api.service';

@NgModule({
  declarations: [
    List
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers : [HeroService],
  bootstrap: [List]
})
export class AppModule { }
