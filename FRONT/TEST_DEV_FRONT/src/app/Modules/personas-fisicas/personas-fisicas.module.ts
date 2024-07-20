import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasFisicasRoutingModule } from './personas-fisicas-routing.module';
import { PersonasFisicasCatalogComponent } from './pages/personas-fisicas-catalog/personas-fisicas-catalog.component';
import { PrimengModule } from '../primeng/primeng.module';


@NgModule({
  declarations: [
    PersonasFisicasCatalogComponent
  ],
  imports: [
    CommonModule,
    PersonasFisicasRoutingModule,
    PrimengModule
  ]
})
export class PersonasFisicasModule { }
