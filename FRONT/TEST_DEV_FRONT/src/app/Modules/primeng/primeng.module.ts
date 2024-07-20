import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { MenubarModule } from 'primeng/menubar';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InputTextModule,
    FormsModule,
    MenubarModule
  ],
  exports: [
    InputTextModule,
    FormsModule,
    MenubarModule
  ]
})
export class PrimengModule { }
