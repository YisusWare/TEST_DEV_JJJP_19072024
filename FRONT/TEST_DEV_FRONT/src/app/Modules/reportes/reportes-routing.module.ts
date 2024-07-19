import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportCatalogComponent } from './report-catalog/report-catalog.component';

const routes: Routes = [
  {
    path: '',
    component: ReportCatalogComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportesRoutingModule { }
