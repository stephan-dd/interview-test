import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from './api.service';
import { ListComponent } from './list/list.component';

@NgModule({
  declarations: [ApiService,
  ListComponent],
  imports: [CommonModule],
})
export class ApiModule {}
