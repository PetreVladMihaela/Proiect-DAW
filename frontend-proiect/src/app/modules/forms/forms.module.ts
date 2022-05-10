import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditLandmarkComponent } from './add-edit-landmark/add-edit-landmark.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ButtonHoverDirective } from 'src/app/button-hover.directive';
import { AddEditCountryComponent } from './add-edit-country/add-edit-country.component';

@NgModule({
  declarations: [
    AddEditLandmarkComponent,
    ButtonHoverDirective,
    AddEditCountryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  entryComponents: [
    AddEditLandmarkComponent
  ],
  exports: [
    ButtonHoverDirective
  ]
})
export class FormsModule { }
