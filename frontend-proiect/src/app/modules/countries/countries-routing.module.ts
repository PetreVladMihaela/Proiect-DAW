import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisitorsComponent } from '../visitors/visitors/visitors.component';
import { CountriesComponent } from './countries/countries.component';
import { LandmarkInfoComponent } from './landmarks/landmark-info/landmark-info.component';
import { LandmarksComponent } from './landmarks/landmarks.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'countries',
    pathMatch: 'full'
  },

  {
    path: 'countries',
    component: CountriesComponent
  },

  {
    path: 'countries/:id',
    component: LandmarksComponent
  },

  {
    path: 'info/:country/:id',
    component: LandmarkInfoComponent
  },

  {
    path: 'visitors',
    component: VisitorsComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CountriesRoutingModule { }
