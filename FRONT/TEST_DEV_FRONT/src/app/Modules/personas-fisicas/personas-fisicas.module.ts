import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasFisicasRoutingModule } from './personas-fisicas-routing.module';
import { PersonasFisicasCatalogComponent } from './pages/personas-fisicas-catalog/personas-fisicas-catalog.component';


@NgModule({
  declarations: [
    PersonasFisicasCatalogComponent
  ],
  imports: [
    CommonModule,
    PersonasFisicasRoutingModule
  ]
})
export class PersonasFisicasModule { }
