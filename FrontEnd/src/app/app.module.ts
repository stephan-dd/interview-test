import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material';
import { MatIconModule } from '@angular/material/icon'

import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { Configuration } from './shared/configuration';
import { CacheInterceptor } from './shared/cache-interceptor';
import { ApiService } from './api.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatIconModule,
  ],
  providers: [
    { provide:HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true},
    ApiService,
    Configuration
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
