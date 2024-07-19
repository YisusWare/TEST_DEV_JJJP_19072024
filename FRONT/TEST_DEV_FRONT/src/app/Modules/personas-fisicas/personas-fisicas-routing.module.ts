import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonasFisicasCatalogComponent } from './pages/personas-fisicas-catalog/personas-fisicas-catalog.component';

const routes: Routes = [
  {
    path: '',
    component: PersonasFisicasCatalogComponent,
    
  },
  {
    path: '**',
    redirectTo: 'personas-fisicas'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonasFisicasRoutingModule { }
