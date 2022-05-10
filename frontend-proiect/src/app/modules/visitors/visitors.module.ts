import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VisitorsRoutingModule } from './visitors-routing.module';
import { MatCardModule } from '@angular/material/card';
import { VisitorsComponent } from './visitors/visitors.component';


@NgModule({
  declarations: [
    VisitorsComponent,
  ],
  imports: [
    CommonModule,
    VisitorsRoutingModule,
    MatCardModule,
  ]
})
export class VisitorsModule { }
