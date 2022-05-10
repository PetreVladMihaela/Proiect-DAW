import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { CountriesModule } from './modules/countries/countries.module';
import { FormsModule } from './modules/forms/forms.module';
import { MatDialogModule } from '@angular/material/dialog';
import { VisitorsComponent } from './modules/visitors/visitors/visitors.component';
// import { TableRowHoverDirective } from './table-row-hover.directive';
// import { ButtonHoverDirective } from './button-hover.directive';
// import { ReactiveFormsModule } from '@angular/forms';
// import {MatInputModule} from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    VisitorsComponent,
    //ButtonHoverDirective
  ],
  imports: [
    // CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CountriesModule,
    FormsModule,
    MatDialogModule,
    // ReactiveFormsModule,
    // MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [
    //ButtonHoverDirective
  ]
})
export class AppModule { }

//json-server --watch countries.json --id Id