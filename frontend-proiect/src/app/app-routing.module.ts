import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from './authorization.guard';
import { VisitorsGuard } from './visitors.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthorizationGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('src/app/modules/countries/countries.module').then(m => m.CountriesModule)
      }
    ]
  },

  {
    path: 'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule)
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
