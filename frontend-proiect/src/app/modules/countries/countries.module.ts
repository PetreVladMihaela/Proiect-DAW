import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountriesRoutingModule } from './countries-routing.module';
import { CountriesComponent } from './countries/countries.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { LandmarksComponent } from './landmarks/landmarks.component';
import { FormsModule } from '../forms/forms.module';
import { TableHoverDirective } from 'src/app/table-hover.directive';
import { LandmarkInfoComponent } from './landmarks/landmark-info/landmark-info.component';
import {MatCardModule} from '@angular/material/card';
import { MarkTextPipe } from '../../markText.pipe';

@NgModule({
  declarations: [
    CountriesComponent,
    LandmarksComponent,
    TableHoverDirective,
    LandmarkInfoComponent,
    MarkTextPipe
  ],

  imports: [
    CommonModule,
    CountriesRoutingModule,
    MatTableModule,
    MatIconModule,
    FormsModule,
    MatCardModule
  ],
  exports: [
    TableHoverDirective
  ]
})
export class CountriesModule { }
