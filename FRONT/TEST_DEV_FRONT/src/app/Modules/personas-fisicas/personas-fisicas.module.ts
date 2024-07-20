import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasFisicasRoutingModule } from './personas-fisicas-routing.module';
import { PersonasFisicasCatalogComponent } from './pages/personas-fisicas-catalog/personas-fisicas-catalog.component';
import { PrimengModule } from '../primeng/primeng.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/app/interceptors/jwt.interceptor';


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
