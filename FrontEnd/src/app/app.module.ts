import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Configuration } from './shared/configuration';
import { CacheInterceptor } from './shared/cache-interceptor';

import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { ApiService } from './api.service';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule 
  ],
  providers: [
    { provide:HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true},
    ApiService,
    Configuration 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
