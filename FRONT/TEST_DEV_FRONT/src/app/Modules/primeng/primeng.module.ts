import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InputTextModule,
    FormsModule
  ],
  exports: [
    InputTextModule,
    FormsModule
  ]
})
export class PrimengModule { }
