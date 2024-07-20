import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { MenubarModule } from 'primeng/menubar';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';


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
    MenubarModule,
    TableModule,
    DialogModule,
    CalendarModule
  ]
})
export class PrimengModule { }
