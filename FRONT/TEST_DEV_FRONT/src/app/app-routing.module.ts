import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule } from './Modules/home/home.module';
import { HomeComponent } from './Modules/home/home/home.component';
import { ReportesModule } from './Modules/reportes/reportes.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./Modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'home',
    component: HomeComponent,
    children: [
      
      {
        path: 'personas-fisicas',
        loadChildren: () => import('./Modules/personas-fisicas/personas-fisicas.module').then(m => m.PersonasFisicasModule)
      },
      {
        path: 'reportes',
        loadChildren: () => import('./Modules/reportes/reportes.module').then(m => m.ReportesModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
